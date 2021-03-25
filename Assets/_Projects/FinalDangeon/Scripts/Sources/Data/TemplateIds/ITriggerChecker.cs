using MetaLogic.Logic.Static;

namespace MetaLogic.Data
{
    public interface ITriggerChecker<in T> where T: ITrigger
    {
        bool CheckTrigger(TriggerUnitData triggerData, T data);
        TriggerType Id { get; }
    }
}
