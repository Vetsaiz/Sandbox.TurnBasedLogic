using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaMax : IFormula
    {
        [SerializableId("max")]
        IReadOnlyDictionary<int, IFormula> ArgsMax { get; }
    }
}
