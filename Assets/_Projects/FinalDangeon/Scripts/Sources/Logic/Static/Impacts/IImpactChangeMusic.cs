using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactChangeMusic : IImpact
    {
        [SerializableId("unity_id")]
        string UnityObjectId { get; }

        [SerializableId("transition")]
        int Transition { get; }

        [SerializableId("priority")]
        int Priority { get; }
    }
}