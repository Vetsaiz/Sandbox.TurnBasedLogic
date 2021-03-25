using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IImpactMoveTeamData : IImpact
    {
        [SerializableId("room_id")]
        int RoomId { get; }

        [SerializableId("move_effect")]
        int MoveEffect { get; }

        [SerializableId("point_id")]
        string Point { get; }
        
        [SerializableId("direction")]
        DirectionType Direction { get; }
    }

}
