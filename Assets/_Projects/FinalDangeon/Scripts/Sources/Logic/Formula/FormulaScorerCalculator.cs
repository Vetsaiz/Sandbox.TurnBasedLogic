using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    internal class FormulaScorerCalculator : FormulaCalculator<IFormulaScorer>
    {
        private ScorersLogic _scorers;
        
        public FormulaScorerCalculator(ScorersLogic scorers)
        {
            _scorers = scorers;
        }

        public override double Calculate(IFormulaScorer formulaData)
        {
            return _scorers.GetScorer(formulaData.Scorer, formulaData.StageId);
        }

        public override FormulaType Id => FormulaType.FormulaScorer;
    }
}
