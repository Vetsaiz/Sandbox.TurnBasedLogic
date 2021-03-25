using System;
using VetsEngine.MetaLogic.Contracts;
using MetaLogic.Logic.Static;
using MetaLogic.Data;
namespace MetaLogic
{
    public interface ILogicAPI
    {
        ContextAbilityData GetPublicContext();
        void BatchAction(Action callback);
        CutSceneResult[] GetCutSceneResults();
        BattleTurnResult[] GetCallbacks();
        IFormulaLogic GetStateFormula();
        Double Calculate(IFormula data, Int32 unit);
        IFormulaLogic CreateClientFormula();
        void RegisterTrigger<T>(ITriggerChecker<T> checker) where T: ITrigger;
        void UnregisterTrigger(TriggerType id);
        Boolean CheckUnit(ICondition condition, Int32 unit);
        void RegisterCondition<T>(IConditionChecker<T> checker) where T: ICondition;
        void UnregisterCondition(ConditionType id);
        void RegisterImpact<T>(IImpactExecutor<T> executor) where T: IImpact;
        void UnregisterImpact(ImpactType id);
        Boolean ExecuteImpact(IImpact impact, Boolean checkCondition);
    }
}
