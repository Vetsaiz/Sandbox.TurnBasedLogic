using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IInteractiveObject
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("room_id")]
        int RoomId { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("availibility")]
        AvailibilityType Availibility { get; }

        [SerializableId("backlight")]
        bool Backlight { get; }

        [SerializableId("icon_type")]
        IconType IconType { get; }

        [SerializableId("minimap_visibility")]
        bool MinimapVisability { get; }

        [SerializableId("battle_view")]
        bool BattleVisibility { get; }

        [SerializableId("impassable")]
        bool Impassable { get; }

        [SerializableId("activations")]
        IReadOnlyDictionary<int, IExplorerActivation> Activations { get; }
        
        [SerializableId("description")]
        string Description { get; }

        [SerializableId("jump_direction")]
        JumpDirectionType JumpDirection { get; }

        [SerializableId("danger")]
        bool Danger { get; }

        [SerializableId("revert")]
        bool Revert { get; }

        [SerializableId("autorotate")]
        bool AutoRotate { get; }
    }
}
