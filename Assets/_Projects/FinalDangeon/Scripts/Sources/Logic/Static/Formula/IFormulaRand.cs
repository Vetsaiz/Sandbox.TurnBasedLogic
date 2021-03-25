using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaRand : IFormula
    {
        [SerializableId("rand_max")]
        IFormula Max { get; }

        [SerializableId("rand_min")]
        IFormula Min { get; }
    }
}
