using System;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class ScorersLogic
    {
        public BattleAccessor _battle;
        public ScorersAccessor _scorers;
        public ExplorerAccessor _explorer;

        public ILogicDictionary<int, long> GetScrorerMap(int id, int stageId)
        {
            var staticData = _scorers.Static.Scorers[id];
            if (staticData == null)
            {
                Logger.Error($"No scorer for id = {id}", this);
                return null;
            }
            id = staticData.Id;
            ILogicDictionary<int, long> values;
            switch (staticData.Domain)
            {
                case ScorerType.Common:
                    values = _scorers.State.Values;
                    break;
                case ScorerType.Impact:
                    values = _scorers.State.ImpactValues;
                    break;
                case ScorerType.Battle:
                    values = _scorers.State.BattleValues;
                    break;
                case ScorerType.Level:
                    if (stageId == 0)
                    {
                        stageId = _explorer.CurrentStage;
                    }
                    if (stageId == -1)
                    {
                        Logger.Error($"Trying to read counter for stage outside explorer. id = {id}", this);
                        return null;
                    }
                    var stage = _explorer.GetStage(stageId);
                    values = stage.Values;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (!values.ContainsKey(staticData.Id))
            {
                values[staticData.Id] = 0;
            }
            return values;
        }

        public long GetScorer(int id, int stageId)
        {
            var dataScorer = _scorers.Static.Scorers[id];
            switch (dataScorer.Domain)
            {
                case ScorerType.Battle:
                    if (_scorers.State.BattleValues.TryGetValue(id, out var scorerB))
                    {
                        return scorerB;
                    }
                    break;
                case ScorerType.Impact:
                    if (_scorers.State.ImpactValues.TryGetValue(id, out var scorerI))
                    {
                        return scorerI;
                    }
                    break;
                case ScorerType.Common:
                    if (_scorers.State.Values.TryGetValue(id, out var scorer))
                    {
                        return scorer;
                    }
                    break;
                case ScorerType.Level:
                    if (stageId == 0)
                    {
                        stageId = _explorer.CurrentStage;
                    }
                    if (stageId == -1)
                    {
                        Logger.Error($"Trying to read counter for stage outside explorer. id = {id}", this);
                    }
                    else
                    {
                        if (_explorer.GetStage(stageId).Values.TryGetValue(id, out var scorer1))
                        {
                            return scorer1;
                        }
                    }
                    break;
            }
            //Logger.Error($"No scorer for id = {id}", this);
            return 0;
        }

        public void ClearTemporaryScorers()
        {
            foreach (var scorer in _scorers.Static.Scorers)
            {
                if (scorer.Value.Temporary)
                {
                    if (scorer.Value.Domain == ScorerType.Level)
                    {
                        _explorer.State.Stages[_explorer.CurrentStage].Values.Remove(scorer.Key);
                    }
                    else if (scorer.Value.Domain == ScorerType.Common)
                    {
                        _scorers.State.Values.Remove(scorer.Key);
                    }
                }
            }
        }

        public bool HasLog(int dataId)
        {
            return _scorers.Static.Scorers[dataId].Log;
        }
    }
}
