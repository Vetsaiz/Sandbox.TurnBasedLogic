using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Logic.Static;

namespace MetaLogic.Data
{
    public interface IFormulaLogic
    {
        double Calculate(IFormula data);
        double Calculate(IFormula data, int unit);
        void RegisterCalculator<T>(IFormulaCalculator<T> checker) where T : IFormula;
    }
}
