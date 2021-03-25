using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IImpactStageAccess : IImpact
    {
        [SerializableId("stage_id")]
        int StageId { get; }
        [SerializableId("access")]
        AccessType Access { get; }
    }
}
