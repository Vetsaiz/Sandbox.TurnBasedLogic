using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaDiff : IFormula
    {
        [SerializableId("diff")]
        IReadOnlyDictionary<int, IFormula> ArgsDiff { get; }
    }
}
