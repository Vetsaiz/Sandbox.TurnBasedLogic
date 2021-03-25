using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;
using UnityEngine;
using Logger = VetsEngine.MetaLogic.Core.Logger;

namespace MetaLogic.Logic.Impacts
{
    class ImpactManaExecutor : ImpactExecutor<IImpactChangeMana>
    {
        private readonly ExplorerAccessor _explorer;
        private readonly ScorersAccessor _scorers;
        private readonly BattleAccessor _battle;
        private readonly FormulaLogic _logic;
        private readonly SettingsAccessor _settings;

        public ImpactManaExecutor(FormulaLogic logic, ExplorerAccessor explorer, ScorersAccessor scorers, BattleAccessor battle, SettingsAccessor settings)
        {
            _logic = logic;
            _scorers = scorers;
            _battle = battle;
            _explorer = explorer;
            _settings = settings;
        }

        public override void Execute(IImpactChangeMana data)
        {
            //if (_battle.State.Data == null)
            //{
            //    throw new Exception("ImpactManaExecutor Битва не запущена");
            //}
            var manaId = _scorers.ManaId;
            var value = (int) _logic.Calculate(data.Value);
            if (!_explorer.State.IsRun)
            {
                Logger.Error("Attempting to record mana for stage outside of explorer", this);
                return;
            }
            var stage = _explorer.GetStage(_explorer.CurrentStage);
            stage.Values.TryGetValue(manaId, out var scorer);

            if (data.Oversize)
            {
                value = (int)scorer + value;
            }
            else
            {
                value = Mathf.Min((int)scorer + value, _settings.Settings.PlayerSettings.ManaMax);
                value = Mathf.Max(value, 0);
            }
            stage.Values[manaId] = value;
        }

        public override ImpactType Id => ImpactType.ImpChangeMana;
    }
}
