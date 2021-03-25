using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using UnityEngine;

namespace MetaLogic.Logic.Static
{
    public interface IStage
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("zone_id")]
        int ZoneId { get; }
        [SerializableId("stage_number")]
        int StageNumber { get; }
        [SerializableId("plot_chapter")]
        int PlotChapter { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("plot_phrase")]
        string PlotPhrase { get; }
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("start_room_id")]
        int StartRoomId { get; }
        [SerializableId("start_room_position_id")]
        string StartRoomPositionId { get; }
        [SerializableId("impact_init")]
        IImpact ImpactInit { get; }
        [SerializableId("impact_finish")]
        IImpact ImpactFinish { get; }
        [SerializableId("star_1_description")]
        string Star1Description { get; }
        [SerializableId("star_2_description")]
        string Star2Description { get; }
        [SerializableId("star_3_description")]
        string Star3Description { get; }
        [SerializableId("goal_description")]
        string GoalDescription { get; }
        [SerializableId("interactive_object_list")]
        IReadOnlyDictionary<int, int> InteractiveObjectList { get; }
        [SerializableId("unity_id")]
        string UnityId { get; }
        [SerializableId("reward_money_types")]
        IReadOnlyDictionary<int, int> RewardMoneyTypes { get; }
        [SerializableId("reward_units")]
        IReadOnlyDictionary<int, int> RewardUnits { get; }
        [SerializableId("reward_items")]
        IReadOnlyDictionary<int, int> RewardItems { get; }
        [SerializableId("price")]
        IPrice Price { get; }
        [SerializableId("repeatable")]
        bool Repeatable { get; }
        [SerializableId("transfer")]
        bool IsTransfer { get; }
        [SerializableId("no_exit")]
        bool NoExit { get; }
        [SerializableId("impact_autowin")]
        IImpact ImpactAutowin { get; }
        [SerializableId("coming_soon")]
        bool ComingSoon { get; }
        [SerializableId("ui_specialgoal_desc")]
        string SpecDiscription { get;}
        [SerializableId("ui_specialgoal_title")]
        string SpecTitle { get; }
    }
}
