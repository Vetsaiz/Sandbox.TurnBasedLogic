using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaPow : IFormula
    {
        [SerializableId("power")]
        float Power { get; }

        [SerializableId("root")]
        IFormula Root { get; }
    }
}
