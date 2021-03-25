using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using MetaLogic.Logic.Static.Formula;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IFormula : IFormula 
    ,IFormulaBase 
    ,IFormulaConst 
    ,IFormulaDiff 
    ,IFormulaDiv 
    ,IFormulaFloat 
    ,IFormulaLocale 
    ,IFormulaMax 
    ,IFormulaMin 
    ,IFormulaMod 
    ,IFormulaModObjects 
    ,IFormulaMult 
    ,IFormulaParam 
    ,IFormulaPerkRarity 
    ,IFormulaPow 
    ,IFormulaRand 
    ,IFormulaRound 
    ,IFormulaScorer 
    ,IFormulaShards 
    ,IFormulaSum 
    ,IFormulaUnitsParam 
    ,IFormulaUtime 
    ,IFormulaBuff 
    ,IFormulaIf 
    {
        public void PostSerialize()
        {
            _Formula?.PostSerialize();
            ROD_ArgsDiff = _ArgsDiff != null ? _ArgsDiff.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFormula;
            }
            ) : null;
            ROD_ArgsDiv = _ArgsDiv != null ? _ArgsDiv.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFormula;
            }
            ) : null;
            ROD_ArgsMax = _ArgsMax != null ? _ArgsMax.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFormula;
            }
            ) : null;
            ROD_ArgsMin = _ArgsMin != null ? _ArgsMin.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFormula;
            }
            ) : null;
            ROD_ArgsMod = _ArgsMod != null ? _ArgsMod.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFormula;
            }
            ) : null;
            ROD_ArgsMult = _ArgsMult != null ? _ArgsMult.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFormula;
            }
            ) : null;
            _Root?.PostSerialize();
            _Max?.PostSerialize();
            _Min?.PostSerialize();
            _Value?.PostSerialize();
            ROD_ArgsSum = _ArgsSum != null ? _ArgsSum.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFormula;
            }
            ) : null;
            _If?.PostSerialize();
            _Than?.PostSerialize();
            _Else?.PostSerialize();
        }

        #region Interface

        public FormulaType TemplateLabel => _TemplateLabel;

        public IFormula Formula => _Formula;

        public Int32 ConstId => _ConstId;

        public  IReadOnlyDictionary<Int32, IFormula> ArgsDiff => ROD_ArgsDiff;

        public  IReadOnlyDictionary<Int32, IFormula> ArgsDiv => ROD_ArgsDiv;

        public Single ConstValue => _ConstValue;

        public  IReadOnlyDictionary<Int32, IFormula> ArgsMax => ROD_ArgsMax;

        public  IReadOnlyDictionary<Int32, IFormula> ArgsMin => ROD_ArgsMin;

        public Int32 Id => _Id;

        public TargetType Owner => _Owner;

        public Int32 ModId => _ModId;

        public  IReadOnlyDictionary<Int32, IFormula> ArgsMod => ROD_ArgsMod;

        public  IReadOnlyDictionary<Int32, IFormula> ArgsMult => ROD_ArgsMult;

        public Int32 ParamId => _ParamId;

        public TargetType Target => _Target;

        public Int32 PerkId => _PerkId;

        public Single Power => _Power;

        public IFormula Root => _Root;

        public IFormula Max => _Max;

        public IFormula Min => _Min;

        public Int32 FractionDigits => _FractionDigits;

        public DigitType DigitType => _DigitType;

        public IFormula Value => _Value;

        public Int32 Scorer => _Scorer;

        public Int32 StageId => _StageId;

        public Int32 UnitId => _UnitId;

        public Boolean Full => _Full;

        public  IReadOnlyDictionary<Int32, IFormula> ArgsSum => ROD_ArgsSum;

        public TargetType TargetType => _TargetType;

        public Int32 Param => _Param;

        public Int32 BuffId => _BuffId;

        public ICondition If => _If;

        public IFormula Than => _Than;

        public IFormula Else => _Else;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public FormulaType _TemplateLabel;
        [JsonName("type")]
        public Internal_IFormula _Formula;
        [JsonName("const_id")]
        public Int32 _ConstId;
        [JsonName("diff")]
        public Dictionary<String, Internal_IFormula> _ArgsDiff;
        private Dictionary<Int32, IFormula> ROD_ArgsDiff;
        [JsonName("div")]
        public Dictionary<String, Internal_IFormula> _ArgsDiv;
        private Dictionary<Int32, IFormula> ROD_ArgsDiv;
        [JsonName("value")]
        public Single _ConstValue;
        [JsonName("max")]
        public Dictionary<String, Internal_IFormula> _ArgsMax;
        private Dictionary<Int32, IFormula> ROD_ArgsMax;
        [JsonName("min")]
        public Dictionary<String, Internal_IFormula> _ArgsMin;
        private Dictionary<Int32, IFormula> ROD_ArgsMin;
        [JsonName("id")]
        public Int32 _Id;
        [JsonName("owner")]
        public TargetType _Owner;
        [JsonName("mod")]
        public Int32 _ModId;
        [JsonName("mod_objects")]
        public Dictionary<String, Internal_IFormula> _ArgsMod;
        private Dictionary<Int32, IFormula> ROD_ArgsMod;
        [JsonName("mult")]
        public Dictionary<String, Internal_IFormula> _ArgsMult;
        private Dictionary<Int32, IFormula> ROD_ArgsMult;
        [JsonName("param")]
        public Int32 _ParamId;
        [JsonName("target")]
        public TargetType _Target;
        [JsonName("perk_id")]
        public Int32 _PerkId;
        [JsonName("power")]
        public Single _Power;
        [JsonName("root")]
        public Internal_IFormula _Root;
        [JsonName("rand_max")]
        public Internal_IFormula _Max;
        [JsonName("rand_min")]
        public Internal_IFormula _Min;
        [JsonName("fraction_digits")]
        public Int32 _FractionDigits;
        [JsonName("digit_type")]
        public DigitType _DigitType;
        [JsonName("round_value")]
        public Internal_IFormula _Value;
        [JsonName("scorer")]
        public Int32 _Scorer;
        [JsonName("stage_id")]
        public Int32 _StageId;
        [JsonName("unit_id")]
        public Int32 _UnitId;
        [JsonName("full")]
        public Boolean _Full;
        [JsonName("sum")]
        public Dictionary<String, Internal_IFormula> _ArgsSum;
        private Dictionary<Int32, IFormula> ROD_ArgsSum;
        [JsonName("target")]
        public TargetType _TargetType;
        [JsonName("param")]
        public Int32 _Param;
        [JsonName("buff_id")]
        public Int32 _BuffId;
        [JsonName("if_label")]
        public Internal_ICondition _If;
        [JsonName("than_label")]
        public Internal_IFormula _Than;
        [JsonName("else_label")]
        public Internal_IFormula _Else;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
