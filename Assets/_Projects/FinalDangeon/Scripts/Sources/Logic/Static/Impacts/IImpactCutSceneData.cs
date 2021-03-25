using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactCutSceneData : IImpact
    {
        [SerializableId("cutscene_id")]
        int CutSceneId { get; }
    }

}
