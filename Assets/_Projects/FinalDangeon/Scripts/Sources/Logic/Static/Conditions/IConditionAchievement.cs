using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IConditionAchievement : ICondition
    {
        [SerializableId("achievement_id")]
        int AchievementId { get; }
    }
}
