using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IMob : IMob 
    {
        public void PostSerialize()
        {
            _Strength?.PostSerialize();
            _HpMax?.PostSerialize();
            _Initiative?.PostSerialize();
            _Impact?.PostSerialize();
            _ImpactWin?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public String Title => _Title;

        public String UnityId => _UnityId;

        public Boolean Boss => _Boss;

        public IFormula Strength => _Strength;

        public IFormula HpMax => _HpMax;

        public IFormula Initiative => _Initiative;

        public IImpact Impact => _Impact;

        public IImpact ImpactWin => _ImpactWin;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("boss")]
        public Boolean _Boss;
        [JsonName("strength")]
        public Internal_IFormula _Strength;
        [JsonName("hp_max")]
        public Internal_IFormula _HpMax;
        [JsonName("initiative")]
        public Internal_IFormula _Initiative;
        [JsonName("ai")]
        public Internal_IImpact _Impact;
        [JsonName("impact_win")]
        public Internal_IImpact _ImpactWin;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
