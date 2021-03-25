using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class PlayerAccessor
    {
        public IPlayerState State { get; set; }
        [Query]
        public IPlayerStatic Static { get; set; }

        public IImpact GetImpact(int level)
        {
            var levelData = Static.Levels.Values.FirstOrDefault(x => x.Level == State.Level);
            return levelData?.Impact;
        }

        [Query]
        public IReadOnlyDictionary<int, IPlayerLevel> Levels => Static.Levels;

        public void UpgradeLevel(int exp)
        {
            State.Exp = State.Exp + exp;
        }

        public int UpgradeLevel()
        {
            var newExp = State.Exp;

            if (State.Level == Static.Levels.Count)
            {
                return State.Level;
            }
            var neededLevel = State.Level + 1;
            var level = Static.Levels.Values.FirstOrDefault(x => x.Level == neededLevel);
            while (level != null && newExp >= level.ExpMin && neededLevel < Static.Levels.Count + 1)
            {
                neededLevel++;
                LogicLog.UpdatePlayerLevel(State.Level, newExp);
                level = Static.Levels.Values.FirstOrDefault(x => x.Level == neededLevel);
            }
            State.Level = neededLevel - 1;
            var expMin = GetLevel(State.Level).ExpMin;
            State.Exp = level == null ? expMin : newExp;
            return State.Level;
        }

        public IPlayerLevel GetLevel(int stateLevel)
        {
            return Static.Levels.Values.FirstOrDefault(x => x.Level == stateLevel);
        }
    }
}
