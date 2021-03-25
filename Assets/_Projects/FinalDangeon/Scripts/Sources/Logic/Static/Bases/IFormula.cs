using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    [BaseContainer("template_id")]
    public interface IFormula
    {
        [SerializableId("template_id")]
        FormulaType TemplateLabel { get; }
    }

     public interface IFormulaBase : IFormula
    {
        [SerializableId("type")]
        IFormula Formula { get; }
    }
}
