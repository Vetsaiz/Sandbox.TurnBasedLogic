using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactAchievementRemoveExecutor : ImpactExecutor<IImpactAchievementRemove>
    {
        private readonly AchievementAccessor _achievement;

        public ImpactAchievementRemoveExecutor(AchievementAccessor achievement)
        {
            _achievement = achievement;
        }

        public override void Execute(IImpactAchievementRemove data)
        {
            if (_achievement.State.Achievements.TryGetValue(data.AchievementId, out var value))
            {
                value.Complete = false;
            }
            else
            {
                Logger.Error($"no achievement id = {data.AchievementId}",this);
            }
        }

        public override ImpactType Id => ImpactType.ImpAchievementRemove;
    }
}
