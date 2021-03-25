using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Controllers
{
    [LogicElement(ElementType.AccessorTechnical)]
    internal class FormulaController : BaseFormulaController<IFormula>
    {
        public override int[] ContainersTemplateId => new int[]
        {
            (int)FormulaType.Formula,
        };

        public override string GetStrTemplate(int templateId)
        {
            return ((FormulaType) templateId).ToString();
        }

        public double Calculate(IFormula condition)
        {
            return Calculate(new FormulaData(condition));
        }
    }

    internal class FormulaData : BaseFormulaData<IFormula>
    {
        public FormulaData(IFormula condition)
        {
            Data = condition;
            TemplateId = (int)(condition?.TemplateLabel ?? FormulaType.None);
        }
    }
}
