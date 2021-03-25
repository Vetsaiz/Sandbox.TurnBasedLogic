using System;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class AchievementModule
    {
        public AchievementAccessor _accessor;

        public ScorersLogic _scorersLogic;
        public DropLogic _dropLogic;

        public FormulaController _formula;
        public ImpactController _impacts;

        [Command]
        public void UpdateTime(int achievementId)
        {
            //var current = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            //var groupData = _shop.State.Groups[groupId];

            //var group = _shop.GetGroup(groupId);
            //if (current < groupData.FinishTime)
            //{
            //    throw new Exception("no time for refresh");
            //}
            //_shopLogic.UpdateGroups(groupId, current + group.Period);
        }

        [Command]
        public void CompleteAchievement(int achievementId)
        {
            var achievement = _accessor.Static.Achievements[achievementId];
            var value = _scorersLogic.GetScorer(achievement.ScorerId, 0);
            var maxValue = _formula.Calculate(achievement.Value);
            if (value < maxValue)
            {
                throw new Exception($"error update achievement. value = {value} maxValue = {maxValue}");
            }
            _impacts.ExecuteImpact(achievement.Impact);
            foreach (var temp in achievement.Items)
            {
                _dropLogic.Drop(temp.Value);
            }
            _accessor.State.Achievements[achievementId].Complete = true;
            LogicLog.CompleteAchievement(achievementId);
        }
    }
}
