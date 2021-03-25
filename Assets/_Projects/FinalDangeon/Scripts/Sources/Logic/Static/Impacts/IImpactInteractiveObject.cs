using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{

    public interface IImpactInteractiveObject : IImpact
    {
        [SerializableId("interactive_object_id")]
        int InteractiveObjectId { get; }

        [SerializableId("availibility")]
        AvailibilityType Availibility { get; }

        [SerializableId("backlight")]
        bool Backlight { get; }

        [SerializableId("minimap_visability")]
        bool MinimapVisability { get; }

        [SerializableId("impassable")]
        bool Impassable { get; }

        [SerializableId("danger")]
        bool Danger { get; }
    }
}
