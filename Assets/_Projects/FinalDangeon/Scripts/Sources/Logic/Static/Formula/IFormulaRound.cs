using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaRound : IFormula
    {
        [SerializableId("fraction_digits")]
        int FractionDigits { get; }

        [SerializableId("digit_type")]
        DigitType DigitType { get; }

        [SerializableId("round_value")]
        IFormula Value { get; }
    }
}
