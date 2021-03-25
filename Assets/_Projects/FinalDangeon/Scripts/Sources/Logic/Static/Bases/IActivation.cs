using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    [BaseContainer("template_id")]
    public interface ITrigger
    {
        [SerializableId("template_id")]
        TriggerType Type { get; }
    }

    public interface IActivationEvent
    {
        [SerializableId("target")]
        TargetActivationType Target { get; }

        [SerializableId("events")]
        IReadOnlyDictionary<int, IActivationEventTypes> Events { get; }

        [SerializableId("template_id")]
        TriggerType Type { get; }
    }

    public interface IActivationEventTypes
    {
        [SerializableId("type")]
        ITrigger Activation { get; }
    }
}
