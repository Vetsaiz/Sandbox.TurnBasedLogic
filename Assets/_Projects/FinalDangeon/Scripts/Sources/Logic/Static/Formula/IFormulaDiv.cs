using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaDiv : IFormula
    {
        [SerializableId("div")]
        IReadOnlyDictionary<int, IFormula> ArgsDiv { get; }
    }
}
