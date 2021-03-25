using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using System.Globalization;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Static;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IScorersState : IScorersStateClient, IScorersState 
    {
        private ChangeStorage _storage;
        private string DataId = "scorersState";
        private ScorersAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, ScorersAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            LD_Values?.Init($"{DataId}.global_scorers", storage, _Values);
            LD_BattleValues?.Init($"{DataId}.battle_scorers", storage, _BattleValues);
            LD_ImpactValues?.Init($"{DataId}.impact_scorers", storage, _ImpactValues);
        }
        public void PreSave()
        {
            _Values = LD_Values.Source;
            _BattleValues = LD_BattleValues.Source;
            _ImpactValues = LD_ImpactValues.Source;
        }

        #region Queries

        public IScorer GetScorer(System.String argKey)
        {
            return _accessor.GetScorer(argKey);
        }
        public IScorerStatic StaticStatic => _accessor.Static;
        public Int32 StaminaIdStatic => _accessor.StaminaId;
        public Int32 ManaIdStatic => _accessor.ManaId;

        #endregion

        #region Interface

        IReadOnlyReactiveDictionary<Int32, Int64> IScorersStateClient.Values => LD_Values.Interface;
        public IReadOnlyReactiveProperty<Int64?> GetValuesProperty(Int32 key)
        {
            return LD_Values.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int64> IScorersStateClient.BattleValues => LD_BattleValues.Interface;
        public IReadOnlyReactiveProperty<Int64?> GetBattleValuesProperty(Int32 key)
        {
            return LD_BattleValues.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int64> IScorersStateClient.ImpactValues => LD_ImpactValues.Interface;
        public IReadOnlyReactiveProperty<Int64?> GetImpactValuesProperty(Int32 key)
        {
            return LD_ImpactValues.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("global_scorers")]
        public Dictionary<string, Int64> _Values = new Dictionary<string, Int64>();
        private StructLogicDictionary<Int32, Int64> LD_Values = new StructLogicDictionary<Int32, Int64>();
        [JsonName("battle_scorers")]
        public Dictionary<string, Int64> _BattleValues = new Dictionary<string, Int64>();
        private StructLogicDictionary<Int32, Int64> LD_BattleValues = new StructLogicDictionary<Int32, Int64>();
        [JsonName("impact_scorers")]
        public Dictionary<string, Int64> _ImpactValues = new Dictionary<string, Int64>();
        private StructLogicDictionary<Int32, Int64> LD_ImpactValues = new StructLogicDictionary<Int32, Int64>(false);

        #endregion

        #region Source

        ILogicDictionary<Int32, Int64> IScorersState.Values
        {
            get => LD_Values;
        }
        ILogicDictionary<Int32, Int64> IScorersState.BattleValues
        {
            get => LD_BattleValues;
        }
        ILogicDictionary<Int32, Int64> IScorersState.ImpactValues
        {
            get => LD_ImpactValues;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_Values.ToString();
            result += LD_BattleValues.ToString();
            result += LD_ImpactValues.ToString();
            return result;
        }

        #endregion

    }
}
