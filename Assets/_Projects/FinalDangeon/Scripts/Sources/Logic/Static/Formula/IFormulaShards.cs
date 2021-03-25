using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaShards : IFormula
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("full")]
        bool Full { get; }
    }
}
