using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Impacts;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class ImpactLogic {
        public ScorersAccessor _scorers;
        public PlayerAccessor _player;
        public InventoryAccessor _inventory;
        public ExplorerAccessor _explorer;
        public UnitsAccessor _units;
        public BattleAccessor _battle;
        public SettingsAccessor _settings;
        public AchievementAccessor _achievement;

        public BattleLogic _battleLogic;
        public FormulaLogic _formulaLogic;
        public ConditionController _condition;
        public ApplyChangeLogic _applyChangeLogic;
        public BuffLogic _buff;
        public ScorersLogic _scorersLogic;
        public ContextLogic _contextLogic;

        public ImpactController _impactController;

        public LogicData _data;

        [ClientAPI]
        public void RegisterImpact<T>(IImpactExecutor<T> executor) where T : IImpact
        {
            _impactController.RegisterImpact(new ClientImpactExecutor<T>(executor));
        }

        [ClientAPI]
        public void UnregisterImpact(ImpactType id)
        {
            _impactController.UnregisterImpact(id);
        }

        [ClientAPI]
        public bool ExecuteImpact(IImpact impact, bool checkCondition = true)
        {
            return _impactController.ExecuteImpact(impact, checkCondition);
        }

        
        [PostInit]
        public void PostInit() {

            _impactController.Init(_contextLogic, _condition, () => _scorers.State.ImpactValues.Clear());

            _impactController.RegisterImpact(new ImpactLogEventExecutor());

            _impactController.RegisterImpact(new ImpactBaseExecutor(_impactController, ImpactType.Impacts));
            _impactController.RegisterImpact(new ImpactBaseExecutor(_impactController, ImpactType.UnitImpacts));
            _impactController.RegisterImpact(new ImpactEmbedExecutor(_impactController, _settings));
            _impactController.RegisterImpact(new ImpactExecutor(_impactController));
            _impactController.RegisterImpact(new ImpactContainerExecutor(_impactController));
            _impactController.RegisterImpact(new ImpactSetTargetExecutor(_applyChangeLogic, _contextLogic, _battle));
            _impactController.RegisterImpact(new ImpactBuffExecutor(_formulaLogic, _explorer));

            _impactController.RegisterImpact(new UnitImpactExecutor(_contextLogic, _impactController, _condition, _units));
            _impactController.RegisterImpact(new UnitImpactContainerExecutor(_impactController));
            _impactController.RegisterImpact(new ImpactFinishBattleExecutor(_battle));

            _impactController.RegisterImpact(new ImpactUnitSetExecutor(_units, _formulaLogic._formula));
            _impactController.RegisterImpact(new ImpactUnitRemoveExecutor(_units, _explorer));
            _impactController.RegisterImpact(new ImpactItemDataExecutor(_formulaLogic, _inventory, _explorer));
            _impactController.RegisterImpact(new ImpactScorerDataExecutor(_formulaLogic, _scorersLogic, _explorer));
            _impactController.RegisterImpact(new ImpactRandomWeightExecutor(_formulaLogic, _condition, _impactController, _settings, ImpactType.ImpRandomWeight));
            _impactController.RegisterImpact(new ImpactRandomWeightExecutor(_formulaLogic, _condition, _impactController, _settings, ImpactType.UnitImpRandomWeight));
            _impactController.RegisterImpact(new ImpactUnitShardExecutor(_units, _formulaLogic));
            _impactController.RegisterImpact(new ImpactFamiliarUnlockExecutor(_units));
            _impactController.RegisterImpact(new ImpactPlayerExpExecutor(_impactController, _formulaLogic, _player));
            _impactController.RegisterImpact(new ImpactUnitAddExecutor(_impactController, _contextLogic, _battleLogic, _formulaLogic._formula, _units,_explorer, _settings, _battle));
            _impactController.RegisterImpact(new UnitImpactUnsummonExecutor(_contextLogic, _battle, _units, _explorer));
            _impactController.RegisterImpact(new ImpactStageAccessExecutor(_explorer, _settings));
            _impactController.RegisterImpact(new ImpactManaExecutor(_formulaLogic, _explorer, _scorers, _battle, _settings));
            _impactController.RegisterImpact(new ImpactStaminaExecutor(_formulaLogic, _explorer, _scorers));
            _impactController.RegisterImpact(new ImpactPerkChargesExecutor(_formulaLogic, _units));
            _impactController.RegisterImpact(new ImpactAttackMobExecutor(_contextLogic,_battleLogic, _battle, _explorer));
            _impactController.RegisterImpact(new ImpactChangeMoneyExecutor(_formulaLogic, _scorers, _explorer));
            _impactController.RegisterImpact(new ImpactInteractiveObjectExecutor(_explorer));
            _impactController.RegisterImpact(new UnitImpactHpExecutor(_contextLogic, _formulaLogic._formula, _battle, _units));
            _impactController.RegisterImpact(new UnitImpactAbilityExecutor(_impactController, _applyChangeLogic, _contextLogic, _units));
            _impactController.RegisterImpact(new UnitImpactBuffExecutor(_impactController, _contextLogic, _formulaLogic, _buff, _battle));
            _impactController.RegisterImpact(new UnitImpactBuffTypeExecutor(_impactController, _contextLogic, _formulaLogic, _buff, _battle));
            _impactController.RegisterImpact(new UnitImpactSummonExecutor(_contextLogic, _battle, _battleLogic));
            _impactController.RegisterImpact(new UnitImpactExpExecutor(_impactController, _formulaLogic._formula, _contextLogic, _units, _player, _battle));
            _impactController.RegisterImpact(new UnitImpactAnimFrameExecutor(_applyChangeLogic, _formulaLogic));
            _impactController.RegisterImpact(new UnitImpactLeaveExecutor(_contextLogic, _battle));

            _impactController.RegisterImpact(new ImpactConditionExecutor(_impactController, _condition, _contextLogic, _battle, ImpactType.ImpCondition));
            _impactController.RegisterImpact(new ImpactConditionExecutor(_impactController, _condition, _contextLogic, _battle, ImpactType.UnitImpCondition));
            _impactController.RegisterImpact(new ImpactWhileExecutor(_impactController, _condition, ImpactType.ImpWhile));
            _impactController.RegisterImpact(new ImpactWhileExecutor(_impactController, _condition, ImpactType.UnitImpWhile));
            _impactController.RegisterImpact(new ImpactEmptyExecutor(ImpactType.UnitImpComment));
            _impactController.RegisterImpact(new ImpactEmptyExecutor(ImpactType.ImpComment));

            _impactController.RegisterImpact(new ImpactPauseExecutor(_applyChangeLogic, _formulaLogic._formula, _contextLogic));
            _impactController.RegisterImpact(new ImpactAchievementRemoveExecutor(_achievement));
        }
    }
}
