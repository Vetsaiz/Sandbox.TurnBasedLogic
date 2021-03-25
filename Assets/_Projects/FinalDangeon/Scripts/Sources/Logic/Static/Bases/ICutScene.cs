using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface ICutSceneType
    {
        [SerializableId("type")]
        ICutSceneFrame Data { get; }
    }

    [BaseContainer("template_label")]
    public interface ICutSceneFrame
    {
        [SerializableId("template_id")]
        CutSceneType TemplateLabel { get; }
    }

    [BaseContainer("template_label")]
    public interface ICutSceneEvent
    {
        [SerializableId("template_id")]
        CutSceneEventType TemplateLabel { get; }
    }
}
