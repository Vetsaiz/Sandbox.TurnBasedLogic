using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactSoundControl : IImpact
    {
        [SerializableId("unity_id")]
        string UnityObjectId { get; }
        [SerializableId("state")]
        int State{ get; }
    }
}
