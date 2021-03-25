using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static.Formula
{
    public interface IFormulaIf : IFormula
    {
        [SerializableId("if_label")]
        ICondition If { get; }
        
        [SerializableId("than_label")]
        IFormula Than { get; }

        [SerializableId("else_label")]
        IFormula Else { get; }

    }
}
