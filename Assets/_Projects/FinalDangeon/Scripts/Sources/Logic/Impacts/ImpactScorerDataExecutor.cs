using System;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactScorerDataExecutor : ImpactExecutor<IImpactScorerData>
    {
        private readonly ScorersLogic _scorers;
        private readonly FormulaLogic _logic;
        private readonly ExplorerAccessor _explorer;

        public ImpactScorerDataExecutor(FormulaLogic logic, ScorersLogic scorers, ExplorerAccessor explorer) {
            _scorers = scorers;
            _logic = logic;
            _explorer = explorer;
        }

        public override void Execute(IImpactScorerData data)
        {
            var value = (long)_logic.Calculate(data.Value);
            var values = _scorers.GetScrorerMap(data.Id, data.StageId);
            if (values == null)
            {
                return;
            }
            long delta = 0;
            switch (data.Operator)
            {
                case OperationType.Add:
                    delta = value;
                    values[data.Id] += value;
                    break;
                case OperationType.Set:
                    delta = value - values[data.Id];
                    values[data.Id] = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (delta > 0)
            {
                var staticData = _scorers._scorers.Static.MoneyTypes.Values.FirstOrDefault(x=> x.ScorerId == data.Id);
                if (staticData != null && staticData.AchievScorerId != 0)
                {
                    values = _scorers.GetScrorerMap(staticData.AchievScorerId, 0);
                    if (values != null)
                    {
                        values[staticData.AchievScorerId] += delta;
                    }
                }
            }

            if (_scorers.HasLog(data.Id))
            {
                var logStage = data.StageId;
                if (logStage == 0)
                {
                    if (_explorer.State.IsRun)
                    {
                        logStage = _explorer.CurrentStage;
                    }
                }
                LogicLog.ChangeScorer(data.Id, data.Operator, value, logStage);
            }
        }

        public override ImpactType Id => ImpactType.ImpChangeData;
    }
}
