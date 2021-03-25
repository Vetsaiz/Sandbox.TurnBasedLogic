using MetaLogic.Logic.Static;

namespace MetaLogic.Data
{
    public class TriggerUnitData
    {
        public int OwnerId;
        public int TargetId;
    }

    public class ContextTurnData 
    {
        public bool IsEnemy;
        public int OwnerId;
        public int? InterfaceTargetId;
    }

    public class ContextAbilityData
    {
        public int OwnerId;
        public int CurrentTarget;
        public bool IsEnemy;

        public ContextAbilityData Copy()
        {
            return new ContextAbilityData
            {
                OwnerId = OwnerId,
                CurrentTarget = CurrentTarget,
                IsEnemy = IsEnemy,
            };
        }
    }

    //public interface IImpactExecutor<in T> where T : IImpact
    //{
    //    void Execute(T data);
    //    ImpactType Id { get; }
    //}
}