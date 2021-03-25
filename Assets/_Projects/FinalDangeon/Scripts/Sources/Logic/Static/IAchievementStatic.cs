using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface IAchievementStatic
    {
        IReadOnlyDictionary<int, IAchievement> Achievements { get; }
    }
}
