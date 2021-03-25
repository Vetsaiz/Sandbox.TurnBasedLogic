using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactLogEvent : IImpact
    {
        [SerializableId("event_id")]
        int EventId { get; }

        [SerializableId("event_value")]
        int EventValue { get; }
    }
}
