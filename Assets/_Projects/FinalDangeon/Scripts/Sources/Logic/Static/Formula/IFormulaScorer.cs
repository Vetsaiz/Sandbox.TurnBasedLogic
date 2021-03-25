using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaScorer : IFormula
    {
        [SerializableId("scorer")]
        int Scorer { get; }

        [SerializableId("stage_id")]
        int StageId { get; }
    }
}
