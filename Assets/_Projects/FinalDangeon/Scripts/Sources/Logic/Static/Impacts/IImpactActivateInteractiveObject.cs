using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactActivateInteractiveObject : IImpact
    {
        [SerializableId("interactive_object_id")]
        int InteractiveObjectId { get; }
    }
}
