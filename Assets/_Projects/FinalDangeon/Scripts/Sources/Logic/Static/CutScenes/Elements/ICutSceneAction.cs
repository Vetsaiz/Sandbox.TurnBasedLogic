using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface ICutSceneAction : ICutSceneFrame
    {
        [SerializableId("unity_id")]
        string UnityId { get; }
    }
}
