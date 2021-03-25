using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface ICutSceneMove : ICutSceneFrame
    {
        [SerializableId("unity_id")]
        string UnityId { get; }

    }
}
