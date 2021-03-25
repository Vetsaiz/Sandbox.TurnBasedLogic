using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactAbility : IImpact
    {
        [SerializableId("ability_id")]
        int AbilityId { get; }
    }
}
