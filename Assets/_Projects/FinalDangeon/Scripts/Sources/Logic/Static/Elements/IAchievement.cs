using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IAchievement
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("availibility")]
        ICondition Avaibility { get; }

        [SerializableId("type")]
        AchievementType Type { get; }

        [SerializableId("end_time")]
        IFormula Time { get; }

        [SerializableId("scorer_limit")]
        IFormula Value { get; }

        [SerializableId("scorer_id")]
        int ScorerId { get; }
        
        [SerializableId("impact")]
        IImpact Impact { get; }

        [SerializableId("items")]
        IReadOnlyDictionary<int, IDropItem> Items { get; }

        [SerializableId("window_id")]
        string WindowId { get; }

        [SerializableId("notif_prepare")]
        int NotificationPrepare { get; }
    }
}
