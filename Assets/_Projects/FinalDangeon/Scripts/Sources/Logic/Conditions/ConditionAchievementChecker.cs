using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class ConditionAchievementChecker : ConditionChecker<IConditionAchievement>
    {
        private AchievementAccessor _logic;

        public ConditionAchievementChecker(AchievementAccessor logic)
        {
            _logic = logic;
        }
        
        public override bool Check(IConditionAchievement data)
        {
            return _logic.State.Achievements[data.AchievementId].Complete;

        }

        public override ConditionType Id => ConditionType.CondAchievement;
    }
}
