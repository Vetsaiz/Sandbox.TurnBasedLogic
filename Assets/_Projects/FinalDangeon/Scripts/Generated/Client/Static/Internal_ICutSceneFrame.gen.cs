using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ICutSceneFrame : ICutSceneFrame 
    ,ICutSceneAction 
    ,ICutSceneDialog 
    ,ICutSceneImpact 
    ,ICutSceneMove 
    ,ICutSceneTutorial 
    {
        public void PostSerialize()
        {
            ROD_Events = _Events != null ? _Events.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ICutSceneContainer;
            }
            ) : null;
            _Impact?.PostSerialize();
        }

        #region Interface

        public CutSceneType TemplateLabel => _TemplateLabel;

        public String UnityId => _UnityId;

        public String IconBackId => _IconBackId;

        public  IReadOnlyDictionary<Int32, ICutSceneContainer> Events => ROD_Events;

        public IImpact Impact => _Impact;

        public String IconUnityId => _IconUnityId;

        public SpeakerPositionType SpeakerPosition => _SpeakerPosition;

        public String ControlId => _ControlId;

        public String Phrase => _Phrase;

        public TutorialType Mode => _Mode;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public CutSceneType _TemplateLabel;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("back_unity_id")]
        public String _IconBackId;
        [JsonName("events")]
        public Dictionary<String, Internal_ICutSceneContainer> _Events;
        private Dictionary<Int32, ICutSceneContainer> ROD_Events;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("icon_unity_id")]
        public String _IconUnityId;
        [JsonName("speaker_position")]
        public SpeakerPositionType _SpeakerPosition;
        [JsonName("item_unity_id")]
        public String _ControlId;
        [JsonName("phrase")]
        public String _Phrase;
        [JsonName("mode")]
        public TutorialType _Mode;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
