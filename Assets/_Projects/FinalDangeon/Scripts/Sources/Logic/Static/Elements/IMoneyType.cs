using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IMoneyType
    {
        int Id { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("unity_id")]
        string IconId { get; }
        [SerializableId("limit")]
        int Limit { get; }
        [SerializableId("scorer_id")]
        int ScorerId { get; }

        [SerializableId("achiev_scorer_id")]
        int AchievScorerId { get; }
    }
}
