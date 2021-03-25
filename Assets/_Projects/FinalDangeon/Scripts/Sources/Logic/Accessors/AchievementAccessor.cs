using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal class AchievementAccessor
    {
        public IAchievementStatic Static { get; set; }
        
        public IAchievementState State { get; set; }

        public IStateFactory Factory { get; set; }

        public IAchievementData CreateAchievementData(int tempKey)
        {
            var data = State.Achievements[tempKey] = Factory.CreateAchievement();
            return data;
        }

        //[Query]
        public List<int> GetActualAchievements(AchievementType type)
        {
            return Static.Achievements.Where(x => x.Value.Type == type).Select(x=> x.Key).ToList();
        }
    }
}
