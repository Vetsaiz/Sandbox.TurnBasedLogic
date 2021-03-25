using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactShowOffer : IImpact
    {
        [SerializableId("offer_id")]
        int OfferId { get; }
    }
}
