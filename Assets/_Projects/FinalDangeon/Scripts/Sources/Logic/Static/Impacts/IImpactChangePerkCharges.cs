using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactChangePerkCharges : IImpact
    {
        [SerializableId("perk_id")]
        int PerkId { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
