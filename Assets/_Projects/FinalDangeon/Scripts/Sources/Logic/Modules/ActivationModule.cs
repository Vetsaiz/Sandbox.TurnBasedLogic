using System;
using System.Linq;
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class ActivationModule {

        public FormulaController _formulaLogic;
        public ImpactController _impactLogic;

        public ExplorerAccessor _explorer;
        public ScorersAccessor _scorers;
        public PlayerAccessor Player;
        public UnitsAccessor _units;

        public ApplyChangeLogic _changeLogic;

        [Command]
        public void Activation(ExplorerImpactType type, int impactId, ExplorerPositionData position) {
            if (type != ExplorerImpactType.StageInit)
            {
                _explorer.State.Position = position;
            }

            IImpact impact = null;
            switch (type) {
                case ExplorerImpactType.StageInit:
                    impact = _explorer.GetStageImpact(impactId, true);
                    break;
                case ExplorerImpactType.StageFinish:
                    //impact = _explorer.GetStageImpact(impactId, false);
                    break;
                case ExplorerImpactType.RoomsInit:
                    impact = _explorer.GetRoomImpact(impactId);
                    break;
                case ExplorerImpactType.PlayerLevels:
                    impact = Player.GetImpact(impactId);
                    break;
                default:
                    throw new Exception($"Unknown activationType = {type}");
            }
            if (impact != null)
            {
                _impactLogic.ExecuteImpact(impact);
            }
        }

        [Command]
        public void ActivationObject(int id, int index, PerkExecuteData data, ExplorerPositionData position) {
            _changeLogic.SetMode(ApplyMode.Manual);
            LogicLog.Activate(id, index);
            var activation = _explorer.GetActivation(id, index);
            _explorer.State.Position = position;
            _impactLogic.ExecuteImpact(activation.Impact);
            var staminaId = _scorers.StaminaId;
            if (data != null)
            {
                var perk = _units.Static.Perks[data.PerkId];
                if (perk.ClassId != activation.Source.PerkClassId)
                {
                    throw new Exception($"Perk cannot be applied. UnitId = {data.UnitId} perkId = {data.PerkId} perk class id = {perk.ClassId}  activation perkClassId = {activation.Source.PerkClassId}");
                }
                if (activation.Source.UnitId != 0 && activation.Source.UnitId != data.UnitId)
                {
                    throw new Exception($"Perk cannot be applied. UnitId = {data.UnitId} need unit id = {activation.Source.UnitId}");
                }
                var (unit, _) = _units.GetUnit(data.UnitId);
                if (!unit.PerkStars.TryGetValue(data.PerkId, out var stars) || stars < activation.Source.PerkLevel)
                {
                    throw new Exception($"Not enough stars to use the perk. UnitId = {data.UnitId} perkId = {data.PerkId} perkStars = {stars} activation stars = {activation.Source.PerkLevel} ");
                }
                if (!unit.PerkCharges.TryGetValue(data.PerkId, out var value) || value == 0)
                {
                    throw new Exception($"НNot enough stars to use the perk. UnitId = {data.UnitId} perkId = {data.PerkId}");
                }
                unit.PerkCharges[data.PerkId]--;
            }
            else
            {
                if (activation.Source.PerkClassId != 0)
                {
                    throw new Exception($"Can't complete activation without perk. activation perkClassId = {activation.Source.PerkClassId}");
                }
            }
            //_explorer.SpendScorer(staminaId, (int)_formulaLogic.Calculate(activation.Cost.Stamina));
            //_explorer.ActivateInteractiveObject(id);
            _explorer.State.LastInteractiveId = id;


            _changeLogic.BatchCutScene(0);
            _changeLogic.SetMode(ApplyMode.Auto);
        }

        [Command]
        public void SetRoom(int roomId)
        {
            _explorer.State.RoomId = roomId;
        }
    }
}
