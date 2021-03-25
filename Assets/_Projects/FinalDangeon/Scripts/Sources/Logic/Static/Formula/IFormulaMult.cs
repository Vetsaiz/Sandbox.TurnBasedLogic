using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaMult : IFormula
    {
        [SerializableId("mult")]
        IReadOnlyDictionary<int, IFormula> ArgsMult { get; }
    }
}
