using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;

using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IAbilityBattleData : IAbilityBattleDataEmulate, IAbilityBattleData 
    , IInitStateData<IAbilityBattleDataClient>, IInitStateData<IAbilityBattleData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IAbilityBattleDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.CountBattle.Subscribe(x => _CountBattle = x).AddTo(_disposables);
            client.CountTurn.Subscribe(x => _CountTurn = x).AddTo(_disposables);
            SpendMana = client.SpendMana;
        }

        public void InitData(IAbilityBattleData data, ChangeStorage storage)
        {
            _storage = storage;
            CountBattle = data.CountBattle;
            CountTurn = data.CountTurn;
            SpendMana = data.SpendMana;
        }

        #region Common

        private Int32 _CountBattle;
        public Int32  CountBattle
        {
            get => _CountBattle;
               set
            {
                 var backValue = _CountBattle;
                _storage.AddBackAction(() => _CountBattle = backValue);
                _CountBattle = value;
            }
        }
        private Int32 _CountTurn;
        public Int32  CountTurn
        {
            get => _CountTurn;
               set
            {
                 var backValue = _CountTurn;
                _storage.AddBackAction(() => _CountTurn = backValue);
                _CountTurn = value;
            }
        }
        public Boolean SpendMana { get; private set; }

        #endregion

        #region Interface


        #endregion

        #region Internal


        #endregion

        #region Source


        #endregion

    }
}
