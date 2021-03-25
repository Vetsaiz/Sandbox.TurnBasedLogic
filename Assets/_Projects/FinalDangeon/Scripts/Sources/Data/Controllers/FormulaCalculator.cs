using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Logic.Static;

namespace MetaLogic.Data
{
    public abstract class FormulaCalculator<T> : IFormulaCalculator<T> where T : class, IFormula
    {
        public int TemplateId => (int)Id;
        public abstract double Calculate(T formulaData);
        public abstract FormulaType Id { get; }
    }
}
