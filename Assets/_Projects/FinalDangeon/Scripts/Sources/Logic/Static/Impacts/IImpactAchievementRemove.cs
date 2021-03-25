using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactAchievementRemove : IImpact
    {
        [SerializableId("achievement_id")]
        int AchievementId { get; }
    }
}
