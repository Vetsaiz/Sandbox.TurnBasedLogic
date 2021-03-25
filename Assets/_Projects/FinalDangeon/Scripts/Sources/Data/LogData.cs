using System.Collections.Generic;
using System.Linq;
using Pathfinding.Serialization.JsonFx;

namespace MetaLogic.Data
{
    public class LogData
    {
        [JsonName("time")]
        public long Time;
        [JsonName("params")]
        public Dictionary<string, object> Params;

        public override string ToString()
        {
            return $"time:{Time}|params:{string.Join(",", Params.Select(x => $"{x.Key}:{x.Value}"))}";
        }
    }

    public enum LogSessionType
    {
        OpenGame = 1,
        UnlockScreen = 2,
        LockScreen = 3,
        CloseGame = 4,
        ErrorProgress = 5,
        ErrorFailed =6,
        UpdateCritical = 7,
        UpdateRecomended = 8,
        ContentDefault = 9,
        NeedLoadResource = 10,
        CompleteLoadResource = 11,
        ForceLoadResource = 12,
    }

    public enum LogBattleType
    {
        Start = 1,
        Win = 2,
        Lose = 3,
        Timeout = 4,
        Leave = 5,
    }

    public enum LogExplorerType
    {
        Start = 1,
        FinishStamina = 2,
        FinishLose = 3,
        FinishInterface = 4,
        FinishImpact = 5,
        BuyStamina = 6,
        AutoWin = 7,
    }

    public enum LogTutorialType
    {
        Execute = 1,
        Complete = 2,
        Skip = 3,
        Retry = 4
    }
}
