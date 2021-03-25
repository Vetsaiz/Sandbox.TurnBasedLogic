using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using MetaLogic.Logic.Static.Conditions;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ICondition : ICondition 
    ,IConditionBase 
    ,IConditionConjunction 
    ,IConditionDisjunction 
    ,IConditionNegation 
    ,IUnitConditionCheck 
    ,IConditionAchievement 
    ,IConditionAvailability 
    ,IConditionFamiliar 
    ,IConditionFormula 
    ,IConditionInteractiveObject 
    ,IConditionPlayerLevel 
    ,IConditionRand 
    ,IConditionScorer 
    ,IConditionServer 
    ,IConditionUnit 
    ,IUnitConditionBuff 
    ,IUnitConditionBuffType 
    ,IUnitConditionFamiliar 
    ,IUnitConditionHave 
    ,IUnitConditionHp 
    ,IUnitConditionMob 
    ,IUnitConditionMostHp 
    ,IUnitConditionMove 
    ,IUnitConditionSlots 
    ,IUnitConditionTarget 
    ,IUnitConditionUnitClass 
    ,IUnitConditionWorld 
    ,IConditionStage 
    ,IConditionZone 
    {
        public void PostSerialize()
        {
            _Condition?.PostSerialize();
            ROD_RestrictionsAnd = _RestrictionsAnd != null ? _RestrictionsAnd.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ICondition;
            }
            ) : null;
            ROD_RestrictionsOr = _RestrictionsOr != null ? _RestrictionsOr.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ICondition;
            }
            ) : null;
            _ConditionNot?.PostSerialize();
            _Value?.PostSerialize();
            _FormulaValue1?.PostSerialize();
            _FormulaValue2?.PostSerialize();
            ROD_Servers = _Servers != null ? _Servers.ToDictionary(
            x => Int32.Parse(x.Key),
            y => y.Value
            ) : null;
            _RarityValue?.PostSerialize();
        }

        #region Interface

        public ConditionType TemplateLabel => _TemplateLabel;

        public ICondition Condition => _Condition;

        public  IReadOnlyDictionary<Int32, ICondition> RestrictionsAnd => ROD_RestrictionsAnd;

        public  IReadOnlyDictionary<Int32, ICondition> RestrictionsOr => ROD_RestrictionsOr;

        public ICondition ConditionNot => _ConditionNot;

        public ContextConditionType ConditionType => _ConditionType;

        public ContextTargetType ContextTarget => _ContextTarget;

        public Int32 AchievementId => _AchievementId;

        public Int32 ItemId => _ItemId;

        public OperatorType Operator => _Operator;

        public IFormula Value => _Value;

        public Boolean Inventory => _Inventory;

        public Int32 UnitId => _UnitId;

        public IFormula FormulaValue1 => _FormulaValue1;

        public IFormula FormulaValue2 => _FormulaValue2;

        public Int32 InteractiveId => _InteractiveId;

        public AvailibilityType Availibility => _Availibility;

        public Int32 Scorer => _Scorer;

        public Int32 StageId => _StageId;

        public  IReadOnlyDictionary<Int32, ServerType> Servers => ROD_Servers;

        public Boolean InExplorer => _InExplorer;

        public Boolean InActive => _InActive;

        public IFormula RarityValue => _RarityValue;

        public Int32 BuffId => _BuffId;

        public Int32 BuffTypeId => _BuffTypeId;

        public Int32 MobId => _MobId;

        public HpType HpType => _HpType;

        public MoveType MoveType => _MoveType;

        public TargetType Target => _Target;

        public Int32 ClassId => _ClassId;

        public Int32 WorldId => _WorldId;

        public Int32 ZoneId => _ZoneId;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public ConditionType _TemplateLabel;
        [JsonName("type")]
        public Internal_ICondition _Condition;
        [JsonName("and")]
        public Dictionary<String, Internal_ICondition> _RestrictionsAnd;
        private Dictionary<Int32, ICondition> ROD_RestrictionsAnd;
        [JsonName("or")]
        public Dictionary<String, Internal_ICondition> _RestrictionsOr;
        private Dictionary<Int32, ICondition> ROD_RestrictionsOr;
        [JsonName("cond")]
        public Internal_ICondition _ConditionNot;
        [JsonName("condition_type")]
        public ContextConditionType _ConditionType;
        [JsonName("context_target")]
        public ContextTargetType _ContextTarget;
        [JsonName("achievement_id")]
        public Int32 _AchievementId;
        [JsonName("item_id")]
        public Int32 _ItemId;
        [JsonName("operator")]
        public OperatorType _Operator;
        [JsonName("value")]
        public Internal_IFormula _Value;
        [JsonName("inventory")]
        public Boolean _Inventory;
        [JsonName("unit_id")]
        public Int32 _UnitId;
        [JsonName("formula_1")]
        public Internal_IFormula _FormulaValue1;
        [JsonName("formula_2")]
        public Internal_IFormula _FormulaValue2;
        [JsonName("io_id")]
        public Int32 _InteractiveId;
        [JsonName("availibility")]
        public AvailibilityType _Availibility;
        [JsonName("scorer")]
        public Int32 _Scorer;
        [JsonName("stage_id")]
        public Int32 _StageId;
        [JsonName("platform_type")]
        public Dictionary<String, ServerType> _Servers;
        private Dictionary<Int32, ServerType> ROD_Servers;
        [JsonName("in_party")]
        public Boolean _InExplorer;
        [JsonName("is_active")]
        public Boolean _InActive;
        [JsonName("rarity")]
        public Internal_IFormula _RarityValue;
        [JsonName("buff_id")]
        public Int32 _BuffId;
        [JsonName("buff_type_id")]
        public Int32 _BuffTypeId;
        [JsonName("mob_id")]
        public Int32 _MobId;
        [JsonName("hp_type")]
        public HpType _HpType;
        [JsonName("move_type")]
        public MoveType _MoveType;
        [JsonName("target")]
        public TargetType _Target;
        [JsonName("class_id")]
        public Int32 _ClassId;
        [JsonName("world_id")]
        public Int32 _WorldId;
        [JsonName("zone_id")]
        public Int32 _ZoneId;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
