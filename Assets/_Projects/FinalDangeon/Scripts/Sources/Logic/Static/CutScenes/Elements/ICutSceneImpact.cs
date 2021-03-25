using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface ICutSceneImpact : ICutSceneFrame
    {
        [SerializableId("impact")]
        IImpact Impact { get; }
    }
}
