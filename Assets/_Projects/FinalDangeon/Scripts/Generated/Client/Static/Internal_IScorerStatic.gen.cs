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
    internal class Internal_IScorerStatic : IScorerStatic 
    {
        public void PostSerialize()
        {
            ROD_Scorers = _Scorers != null ? _Scorers.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IScorer;
            }
            ) : null;
            ROD_MoneyTypes = _MoneyTypes != null ? _MoneyTypes.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IMoneyType;
            }
            ) : null;
            ROD_Consts = _Consts != null ? _Consts.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IConstant;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IScorer> Scorers => ROD_Scorers;

        public  IReadOnlyDictionary<Int32, IMoneyType> MoneyTypes => ROD_MoneyTypes;

        public  IReadOnlyDictionary<Int32, IConstant> Consts => ROD_Consts;


        #endregion

        #region Internal

        [JsonName("scorers")]
        public Dictionary<String, Internal_IScorer> _Scorers;
        private Dictionary<Int32, IScorer> ROD_Scorers;
        [JsonName("money_types")]
        public Dictionary<String, Internal_IMoneyType> _MoneyTypes;
        private Dictionary<Int32, IMoneyType> ROD_MoneyTypes;
        [JsonName("consts")]
        public Dictionary<String, Internal_IConstant> _Consts;
        private Dictionary<Int32, IConstant> ROD_Consts;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
