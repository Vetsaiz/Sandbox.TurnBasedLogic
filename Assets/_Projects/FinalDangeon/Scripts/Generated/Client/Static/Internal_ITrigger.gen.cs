using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using MetaLogic.Logic.Static.Activations;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ITrigger : ITrigger 
    ,IActivationManual 
    ,IActivationStartBattle 
    ,ITriggerBuff 
    ,ITriggerBuffType 
    ,ITriggerFamiliarSummon 
    ,ITriggerHp 
    ,ITriggerInfluence 
    {
        public void PostSerialize()
        {
            _Value?.PostSerialize();
        }

        #region Interface

        public TriggerType Type => _Type;

        public TargetActivationType Target => _Target;

        public Int32 BuffId => _BuffId;

        public OperatorType Operator => _Operator;

        public IFormula Value => _Value;

        public Int32 BuffType => _BuffType;

        public InfluenceTargetType InfluenceType => _InfluenceType;


        #endregion

        #region Internal

        [JsonName("template_id")]
        public TriggerType _Type;
        [JsonName("target")]
        public TargetActivationType _Target;
        [JsonName("buff_id")]
        public Int32 _BuffId;
        [JsonName("operator")]
        public OperatorType _Operator;
        [JsonName("value")]
        public Internal_IFormula _Value;
        [JsonName("buff_type")]
        public Int32 _BuffType;
        [JsonName("influence_type")]
        public InfluenceTargetType _InfluenceType;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
