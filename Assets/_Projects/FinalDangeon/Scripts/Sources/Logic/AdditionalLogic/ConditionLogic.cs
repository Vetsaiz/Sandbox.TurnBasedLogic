using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Condition;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Conditions;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Formula;
using MetaLogic.Logic.Impacts;
using MetaLogic.Logic.Restrictions;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class ConditionLogic 
    {
        public InventoryAccessor _inventoryAccessor;
        public ScorersAccessor _scorersAccessor;
        public PlayerAccessor _profileAccessor;
        public UnitsAccessor _unitAccessor;
        public BattleAccessor _battleAccessor;
        public ExplorerAccessor _explorerAccessor;
        public SettingsAccessor _settingsAccessor;
        public AchievementAccessor _achievementAccessor;

        public FormulaLogic _formulaLogic;
        public ContextLogic _contextLogic;

        public ScorersLogic _scorerLogic;
        public LogicData _data;

        public ConditionController _controller;

        [ClientAPI]
        public bool CheckUnit(ICondition condition, int unit)
        {
            _contextLogic.SetContextCondition(unit, unit, false);
            var result = _controller.Check(condition);
            _contextLogic.SetContextCondition(-1, -1, true);
            return result;
        }

        [ClientAPI]
        public void RegisterCondition<T>(IConditionChecker<T> checker) where T: ICondition
        {
            _controller.RegisterCondition(new ClientConditionChecker<T>(checker));
        }

        [ClientAPI]
        public void UnregisterCondition(ConditionType id)
        {
            _controller.UnregisterCondition((int)id);
        }

        [PostInit]
        public void RegisterRestrictions() {
            _controller.RegisterCondition(new ConditionBaseChecker(_controller, ConditionType.Conditions));
            _controller.RegisterCondition(new ConditionBaseChecker(_controller, ConditionType.ConditionsUnit));

            _controller.RegisterCondition(new ConditionChecker(_controller, _contextLogic, _battleAccessor));
            _controller.RegisterCondition(new ConditionUnitChecker(_controller, _contextLogic, _battleAccessor, _unitAccessor));
            
            _controller.RegisterCondition(new ConditionConjunctionChecker(_controller, ConditionType.CondConjunction));
            _controller.RegisterCondition(new ConditionDisjunctionChecker(_controller, ConditionType.CondDisjunction));
            _controller.RegisterCondition(new ConditionNegationChecker(_controller, ConditionType.CondNegation));
            _controller.RegisterCondition(new ConditionFormulaChecker(_formulaLogic._formula));

            _controller.RegisterCondition(new ConditionConjunctionChecker(_controller, ConditionType.CondUnitConjunction));
            _controller.RegisterCondition(new ConditionDisjunctionChecker(_controller, ConditionType.CondUnitDisjunction));
            _controller.RegisterCondition(new ConditionNegationChecker(_controller, ConditionType.CondUnitNegation));

            _controller.RegisterCondition(new ConditionScorerChecker(_formulaLogic, _scorerLogic));
            _controller.RegisterCondition(new ConditionIntentoryChecker(_formulaLogic, _inventoryAccessor));
            _controller.RegisterCondition(new ConditionUnitExistChecker(_unitAccessor, _formulaLogic));
            
            _controller.RegisterCondition(new ConditionFamiliarChecker(_unitAccessor));
            _controller.RegisterCondition(new ConditionPlayerLevelChecker(_formulaLogic, _profileAccessor));
            
            _controller.RegisterCondition(new ConditionUnitClassChecker(_unitAccessor, _contextLogic));
            _controller.RegisterCondition(new ConditionUnitFamiliarChecker(_contextLogic, _unitAccessor));
            _controller.RegisterCondition(new ConditionUnitMobChecker(_contextLogic, _battleAccessor));
            _controller.RegisterCondition(new ConditionUnitHaveChecker(_battleAccessor, _contextLogic, _formulaLogic, _unitAccessor));
            _controller.RegisterCondition(new ConditionUnitHpChecker(_formulaLogic._formula, _contextLogic));
            _controller.RegisterCondition(new ConditionUnitMostHpChecker(_contextLogic, _formulaLogic._formula, _battleAccessor, _unitAccessor));
            _controller.RegisterCondition(new ConditionUnitSlotChecker(_contextLogic, _formulaLogic, _battleAccessor));
            _controller.RegisterCondition(new ConditionUnitWorldChecker(_unitAccessor, _contextLogic));
            _controller.RegisterCondition(new ConditionUnitBuffChecker(_contextLogic, _formulaLogic));
            _controller.RegisterCondition(new ConditionRandChecker(_formulaLogic, _data));
            _controller.RegisterCondition(new ConditionZoneChecker(_explorerAccessor));
            _controller.RegisterCondition(new ConditionStageChecker(_explorerAccessor));
            _controller.RegisterCondition(new ConditionUnitBuffTypeChecker(_contextLogic, _formulaLogic, _battleAccessor));
            _controller.RegisterCondition(new ConditionInteractiveObjectChecker(_explorerAccessor, _formulaLogic));
            _controller.RegisterCondition(new ConditionUnitTargetChecker(_contextLogic));

            _controller.RegisterCondition(new ConditionServerChecker(_settingsAccessor));

            _controller.RegisterCondition(new ConditionAchievementChecker(_achievementAccessor));
        }
    }
}
