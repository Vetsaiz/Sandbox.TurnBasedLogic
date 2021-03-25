using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using Pathfinding.Serialization.JsonFx;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface IExplorerState {

        [SerializableId("current_stage_id")]
        int StageId { get; set; }
        
        [SerializableId("current_room_id")]
        int RoomId { get; set; }

        [SerializableId("stages")]
        ILogicDictionary<int, IStageData> Stages { get; }

        [SerializableId("inventory")]
        ILogicDictionary<int, int> Inventory { get; }

        [SerializableId("position")]
        ExplorerPositionData Position { get; set; }

        [SerializableId("last_interactive_id")]
        int LastInteractiveId { get; set; }

        [SerializableId("player_buffs")]
        ILogicDictionary<int, int> PlayerBuffs { get; }

        [JsonIgnore]
        bool IsRun { get; set; }

        [SerializableId("refresh_number")]
        int RefreshNumber { get; set; }

        //[SerializableId("last_team")]
        //ILogicDictionary<int, int> LastTeam { get; }
    }
    
    internal interface IStageData
    {
        [SerializableId("stage_id")]
        int StageId { get; }
        
        [SerializableId("unlock")]
        bool IsUnlock { get; set; }
        
        [SerializableId("scorers")]
        ILogicDictionary<int, long> Values { get; }
        
        [SerializableId("interactive_objects")]
        ILogicDictionary<int, InteractiveObjectData> ObjectAvailibility { get; }
        
        [SerializableId("rooms")]
        ILogicDictionary<int, int> Rooms { get; }

        [SerializableId("daily_number")]
        int DailyNumber { get; set; }

        [SerializableId("refresh_number")]
        int RefreshNumber { get; set; }
    }
}
