using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaSum : IFormula
    {
        [SerializableId("sum")]
        IReadOnlyDictionary<int, IFormula> ArgsSum { get; }
    }
}
