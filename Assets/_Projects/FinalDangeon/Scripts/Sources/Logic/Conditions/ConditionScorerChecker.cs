using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionScorerChecker : ConditionChecker<IConditionScorer> {
        private readonly ScorersLogic _scorers;
        private FormulaLogic _logic;

        public ConditionScorerChecker(FormulaLogic logic, ScorersLogic scorers) {
            _scorers = scorers;
            _logic = logic;
        }

        public override bool Check(IConditionScorer restictionData)
        {
            var currentCount = _scorers.GetScorer(restictionData.Scorer, restictionData.StageId);
            var value = (int)_logic.Calculate(restictionData.Value);
            return restictionData.Operator.Check(currentCount, value);
        }

        public override ConditionType Id => ConditionType.CondScorer;
    }
}
