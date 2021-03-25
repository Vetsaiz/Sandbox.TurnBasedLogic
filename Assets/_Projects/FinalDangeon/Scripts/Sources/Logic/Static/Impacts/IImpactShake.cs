using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactShake : IImpact
    {
        [SerializableId("delay")]
        float Delay { get; }

        [SerializableId("intensityPosition")]
        float IntensityPosition { get; }

        [SerializableId("intensityRotation")]
        float IntensityRotation { get; }

        [SerializableId("vibration")]
        bool Vibration { get; }
    }
}
