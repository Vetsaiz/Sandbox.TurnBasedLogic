using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaModObjects : IFormula
    {
        [SerializableId("mod_objects")]
        IReadOnlyDictionary<int, IFormula> ArgsMod { get; }
    }
}
