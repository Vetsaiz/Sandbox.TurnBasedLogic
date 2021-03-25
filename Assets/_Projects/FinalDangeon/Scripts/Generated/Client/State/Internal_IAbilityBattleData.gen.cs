using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using System.Globalization;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IAbilityBattleData : IAbilityBattleDataClient, IAbilityBattleData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "abilityBattleData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_CountBattle = new ReactiveProperty<Int32>(_CountBattle);
            Interface_CountTurn = new ReactiveProperty<Int32>(_CountTurn);
            Interface_SpendMana = _SpendMana;
        }
        public void PreSave()
        {
        }

        #region Interface

        private ReactiveProperty<Int32> Interface_CountBattle;
        IReadOnlyReactiveProperty<Int32> IAbilityBattleDataClient.CountBattle => Interface_CountBattle;
        private ReactiveProperty<Int32> Interface_CountTurn;
        IReadOnlyReactiveProperty<Int32> IAbilityBattleDataClient.CountTurn => Interface_CountTurn;
        private Boolean Interface_SpendMana;
        Boolean IAbilityBattleDataClient.SpendMana => Interface_SpendMana;

        #endregion

        #region Internal

        [JsonName("countBattle")]
        public Int32 _CountBattle;
        [JsonName("countTurn")]
        public Int32 _CountTurn;
        [JsonName("spendMana")]
        public Boolean _SpendMana;

        #endregion

        #region Source

        Int32 IAbilityBattleData.CountBattle
        {
            get => _CountBattle;
            set
            {
                if (_CountBattle == value)
                {
                    return;
                }
                _CountBattle = value;
                var dataId = DataId + $".countBattle.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CountBattle.Value = value; });
            }
        }
        Int32 IAbilityBattleData.CountTurn
        {
            get => _CountTurn;
            set
            {
                if (_CountTurn == value)
                {
                    return;
                }
                _CountTurn = value;
                var dataId = DataId + $".countTurn.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CountTurn.Value = value; });
            }
        }
        Boolean IAbilityBattleData.SpendMana
        {
            get => _SpendMana;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _CountBattle;
            result += _CountTurn;
            result += _SpendMana;
            return result;
        }

        #endregion

    }
}
