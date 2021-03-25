using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface ICutSceneTutorial : ICutSceneFrame
    {
        [SerializableId("icon_unity_id")]
        string IconUnityId { get; }

        [SerializableId("speaker_position")]
        SpeakerPositionType SpeakerPosition {get;}

        [SerializableId("item_unity_id")]
        string ControlId { get; }

        [SerializableId("phrase")]
        string Phrase { get; }

        [SerializableId("mode")]
        TutorialType Mode { get;}
    }
}
