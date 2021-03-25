using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ICutSceneEvent : ICutSceneEvent 
    ,IChangePortraitEvent 
    ,IMovePortraitEvent 
    ,IPauseEvent 
    ,IRemovePortraitEvent 
    ,ITextDialogEvent 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public CutSceneEventType TemplateLabel => _TemplateLabel;

        public Int32 SlotId => _SlotId;

        public String IconId => _IconId;

        public EnableSlotEffect EnableSlot => _EnableSlot;

        public Int32 Priority => _Priority;

        public String Speaker => _Speaker;

        public SlotDirection Direction => _Direction;

        public Int32 SlotTo => _SlotTo;

        public Int32 SlotFrom => _SlotFrom;

        public Single Time => _Time;

        public Single Timeout => _Timeout;

        public Int32 NeededTap => _NeededTap;

        public DisableSlotEffect DisableSlot => _DisableSlot;

        public String Phrase => _Phrase;

        public Single Speed => _Speed;

        public String AnimUnityId => _AnimUnityId;

        public String SoundId => _SoundId;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public CutSceneEventType _TemplateLabel;
        [JsonName("slot")]
        public Int32 _SlotId;
        [JsonName("unity_id")]
        public String _IconId;
        [JsonName("anim_type")]
        public EnableSlotEffect _EnableSlot;
        [JsonName("priority")]
        public Int32 _Priority;
        [JsonName("title")]
        public String _Speaker;
        [JsonName("direction")]
        public SlotDirection _Direction;
        [JsonName("slot_to")]
        public Int32 _SlotTo;
        [JsonName("slot_from")]
        public Int32 _SlotFrom;
        [JsonName("time")]
        public Single _Time;
        [JsonName("timeout")]
        public Single _Timeout;
        [JsonName("tap")]
        public Int32 _NeededTap;
        [JsonName("anim_type_remove")]
        public DisableSlotEffect _DisableSlot;
        [JsonName("phrase")]
        public String _Phrase;
        [JsonName("speed")]
        public Single _Speed;
        [JsonName("anim_unity_id")]
        public String _AnimUnityId;
        [JsonName("sound_unity_id")]
        public String _SoundId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
