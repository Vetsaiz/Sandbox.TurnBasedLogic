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
    internal class Internal_IImpact : IImpact 
    ,IImpactBase 
    ,IImpactExecute 
    ,IUnitImpactExecute 
    ,IUnitImpactContainer 
    ,IImpactContainer 
    ,IImpactEmbed 
    ,IImpactAchievementRemove 
    ,IImpactActivateInteractiveObject 
    ,IImpactAssistUncommon 
    ,IImpactBubble 
    ,IImpactBubbleIntObject 
    ,IImpactBuff 
    ,IImpactChangeMana 
    ,IImpactChangeMoney 
    ,IImpactChangeMusic 
    ,IImpactChangePerkCharges 
    ,IImpactChangeStamina 
    ,IImpactCompleteStage 
    ,IImpactCondition 
    ,IImpactCutSceneData 
    ,IImpactDelay 
    ,IImpactFamiliarUnlock 
    ,IImpactFinishBattle 
    ,IImpactInteractiveObject 
    ,IImpactItemData 
    ,IImpactLogEvent 
    ,IImpactMobAttack 
    ,IImpactMoveTeamData 
    ,IImpactPlayerExp 
    ,IImpactPushOff 
    ,IImpactPushOn 
    ,IImpactPushRequest 
    ,IImpactRandomWeight 
    ,IImpactScorerData 
    ,IImpactSetTarget 
    ,IImpactShake 
    ,IImpactShowOffer 
    ,IImpactSoundControl 
    ,IImpactStageAccess 
    ,IImpactTutorial 
    ,IImpactUnitAdd 
    ,IImpactUnitRemove 
    ,IImpactUnitSetSlot 
    ,IImpactUnitShard 
    ,IImpactWhile 
    ,IUnitImpactAbility 
    ,IUnitImpactAnimFrame 
    ,IUnitImpactAnimState 
    ,IUnitImpactBubble 
    ,IUnitImpactBuff 
    ,IUnitImpactBuffType 
    ,IUnitImpactColorFilter 
    ,IUnitImpactExp 
    ,IUnitImpactHp 
    ,IUnitImpactLeave 
    ,IUnitImpactSummon 
    {
        public void PostSerialize()
        {
            _Condition?.PostSerialize();
            _ImpactType?.PostSerialize();
            _Impact?.PostSerialize();
            _ImpactUnit?.PostSerialize();
            ROD_Impacts = _Impacts != null ? _Impacts.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IImpact;
            }
            ) : null;
            _Value?.PostSerialize();
            ROD_Mobs = _Mobs != null ? _Mobs.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IImpactMobData;
            }
            ) : null;
            _ImpactWin?.PostSerialize();
            _ImpactLose?.PostSerialize();
            _ImpactInit?.PostSerialize();
            ROD_PushIds = _PushIds != null ? _PushIds.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            _TimeFormula?.PostSerialize();
            ROD_Weights = _Weights != null ? _Weights.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IWeightImpact;
            }
            ) : null;
            _Unit?.PostSerialize();
            _Shards?.PostSerialize();
            ROD_BuffTypeIds = _BuffTypeIds != null ? _BuffTypeIds.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
        }

        #region Interface

        public ImpactType TemplateLabel => _TemplateLabel;

        public ICondition Condition => _Condition;

        public IImpact ImpactType => _ImpactType;

        public IImpact Impact => _Impact;

        public IImpact ImpactUnit => _ImpactUnit;

        public ConditionTargetType ConditionType => _ConditionType;

        public ContextTargetType Target => _Target;

        public UnitImpactType UnitImpactType => _UnitImpactType;

        public  IReadOnlyDictionary<Int32, IImpact> Impacts => ROD_Impacts;

        public Int32 ImpactId => _ImpactId;

        public Int32 AchievementId => _AchievementId;

        public Int32 InteractiveObjectId => _InteractiveObjectId;

        public Int32 UnitId => _UnitId;

        public String Emoji => _Emoji;

        public String Phrase => _Phrase;

        public Int32 BuffId => _BuffId;

        public IFormula Value => _Value;

        public Boolean Oversize => _Oversize;

        public Int32 MoneyTypeId => _MoneyTypeId;

        public OperationType Operator => _Operator;

        public String UnityObjectId => _UnityObjectId;

        public Int32 Transition => _Transition;

        public Int32 Priority => _Priority;

        public Int32 PerkId => _PerkId;

        public Int32 CutSceneId => _CutSceneId;

        public Boolean IsVictory => _IsVictory;

        public AvailibilityType Availibility => _Availibility;

        public Boolean Backlight => _Backlight;

        public Boolean MinimapVisability => _MinimapVisability;

        public Boolean Impassable => _Impassable;

        public Boolean Danger => _Danger;

        public Int32 ItemId => _ItemId;

        public Boolean IsExplorer => _IsExplorer;

        public Int32 EventId => _EventId;

        public Int32 EventValue => _EventValue;

        public  IReadOnlyDictionary<Int32, IImpactMobData> Mobs => ROD_Mobs;

        public IImpact ImpactWin => _ImpactWin;

        public IImpact ImpactLose => _ImpactLose;

        public IImpact ImpactInit => _ImpactInit;

        public String Description => _Description;

        public Int32 RoomId => _RoomId;

        public Int32 MoveEffect => _MoveEffect;

        public String Point => _Point;

        public DirectionType Direction => _Direction;

        public  IReadOnlyDictionary<Int32, Int32> PushIds => ROD_PushIds;

        public Int32 PushId => _PushId;

        public IFormula TimeFormula => _TimeFormula;

        public  IReadOnlyDictionary<Int32, IWeightImpact> Weights => ROD_Weights;

        public Int32 Id => _Id;

        public Int32 StageId => _StageId;

        public Single Delay => _Delay;

        public Single IntensityPosition => _IntensityPosition;

        public Single IntensityRotation => _IntensityRotation;

        public Boolean Vibration => _Vibration;

        public Int32 OfferId => _OfferId;

        public Int32 State => _State;

        public AccessType Access => _Access;

        public Int32 TutorialId => _TutorialId;

        public IUnitAdd Unit => _Unit;

        public Int32 SlotId => _SlotId;

        public Boolean Replace => _Replace;

        public IFormula Shards => _Shards;

        public Int32 AbilityId => _AbilityId;

        public Boolean FamiliarAnimStart => _FamiliarAnimStart;

        public String ShellDuration => _ShellDuration;

        public Single Numbler => _Numbler;

        public  IReadOnlyDictionary<Int32, Int32> BuffTypeIds => ROD_BuffTypeIds;

        public String Color => _Color;

        public Int32 MobId => _MobId;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public ImpactType _TemplateLabel;
        [JsonName("condition")]
        public Internal_ICondition _Condition;
        [JsonName("type")]
        public Internal_IImpact _ImpactType;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("impact_unit")]
        public Internal_IImpact _ImpactUnit;
        [JsonName("condition_type")]
        public ConditionTargetType _ConditionType;
        [JsonName("target")]
        public ContextTargetType _Target;
        [JsonName("target_type")]
        public UnitImpactType _UnitImpactType;
        [JsonName("block")]
        public Dictionary<String, Internal_IImpact> _Impacts;
        private Dictionary<Int32, IImpact> ROD_Impacts;
        [JsonName("impact_id")]
        public Int32 _ImpactId;
        [JsonName("achievement_id")]
        public Int32 _AchievementId;
        [JsonName("interactive_object_id")]
        public Int32 _InteractiveObjectId;
        [JsonName("unit_id")]
        public Int32 _UnitId;
        [JsonName("emoji")]
        public String _Emoji;
        [JsonName("phrase")]
        public String _Phrase;
        [JsonName("buff_id")]
        public Int32 _BuffId;
        [JsonName("value")]
        public Internal_IFormula _Value;
        [JsonName("oversize")]
        public Boolean _Oversize;
        [JsonName("money_type_id")]
        public Int32 _MoneyTypeId;
        [JsonName("operator")]
        public OperationType _Operator;
        [JsonName("unity_id")]
        public String _UnityObjectId;
        [JsonName("transition")]
        public Int32 _Transition;
        [JsonName("priority")]
        public Int32 _Priority;
        [JsonName("perk_id")]
        public Int32 _PerkId;
        [JsonName("cutscene_id")]
        public Int32 _CutSceneId;
        [JsonName("result")]
        public Boolean _IsVictory;
        [JsonName("availibility")]
        public AvailibilityType _Availibility;
        [JsonName("backlight")]
        public Boolean _Backlight;
        [JsonName("minimap_visability")]
        public Boolean _MinimapVisability;
        [JsonName("impassable")]
        public Boolean _Impassable;
        [JsonName("danger")]
        public Boolean _Danger;
        [JsonName("item_id")]
        public Int32 _ItemId;
        [JsonName("inventory")]
        public Boolean _IsExplorer;
        [JsonName("event_id")]
        public Int32 _EventId;
        [JsonName("event_value")]
        public Int32 _EventValue;
        [JsonName("mobs")]
        public Dictionary<String, Internal_IImpactMobData> _Mobs;
        private Dictionary<Int32, IImpactMobData> ROD_Mobs;
        [JsonName("impact_win")]
        public Internal_IImpact _ImpactWin;
        [JsonName("impact_lose")]
        public Internal_IImpact _ImpactLose;
        [JsonName("impact_init")]
        public Internal_IImpact _ImpactInit;
        [JsonName("description")]
        public String _Description;
        [JsonName("room_id")]
        public Int32 _RoomId;
        [JsonName("move_effect")]
        public Int32 _MoveEffect;
        [JsonName("point_id")]
        public String _Point;
        [JsonName("direction")]
        public DirectionType _Direction;
        [JsonName("push_types")]
        public Dictionary<String, Int32> _PushIds;
        private Dictionary<Int32, Int32> ROD_PushIds;
        [JsonName("push_type")]
        public Int32 _PushId;
        [JsonName("time")]
        public Internal_IFormula _TimeFormula;
        [JsonName("random")]
        public Dictionary<String, Internal_IWeightImpact> _Weights;
        private Dictionary<Int32, IWeightImpact> ROD_Weights;
        [JsonName("parameter")]
        public Int32 _Id;
        [JsonName("stage_id")]
        public Int32 _StageId;
        [JsonName("delay")]
        public Single _Delay;
        [JsonName("intensityPosition")]
        public Single _IntensityPosition;
        [JsonName("intensityRotation")]
        public Single _IntensityRotation;
        [JsonName("vibration")]
        public Boolean _Vibration;
        [JsonName("offer_id")]
        public Int32 _OfferId;
        [JsonName("state")]
        public Int32 _State;
        [JsonName("access")]
        public AccessType _Access;
        [JsonName("tutorial_id")]
        public Int32 _TutorialId;
        [JsonName("unit")]
        public Internal_IUnitAdd _Unit;
        [JsonName("slot")]
        public Int32 _SlotId;
        [JsonName("replace")]
        public Boolean _Replace;
        [JsonName("shards")]
        public Internal_IFormula _Shards;
        [JsonName("ability_id")]
        public Int32 _AbilityId;
        [JsonName("familiar_anim_start")]
        public Boolean _FamiliarAnimStart;
        [JsonName("shell_duration")]
        public String _ShellDuration;
        [JsonName("state")]
        public Single _Numbler;
        [JsonName("buff_type_id")]
        public Dictionary<String, Int32> _BuffTypeIds;
        private Dictionary<Int32, Int32> ROD_BuffTypeIds;
        [JsonName("color")]
        public String _Color;
        [JsonName("mob_id")]
        public Int32 _MobId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
