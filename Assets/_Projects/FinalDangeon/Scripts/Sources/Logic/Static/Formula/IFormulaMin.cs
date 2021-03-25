using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaMin : IFormula
    {
        [SerializableId("min")]
        IReadOnlyDictionary<int, IFormula> ArgsMin { get; }
    }
}
