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
    internal class Internal_IPlayerState : IPlayerStateClient, IPlayerState 
    {
        private ChangeStorage _storage;
        private string DataId = "playerState";
        private PlayerAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, PlayerAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            Interface_Level = new ReactiveProperty<Int32>(_Level);
            Interface_Exp = new ReactiveProperty<Int32>(_Exp);
            Interface_RegisterTime = new ReactiveProperty<String>(_RegisterTime);
            Interface_LastLoginTime = new ReactiveProperty<String>(_LastLoginTime);
            Interface_SyncTime = new ReactiveProperty<String>(_SyncTime);
        }
        public void PreSave()
        {
        }

        #region Queries

        public IPlayerStatic StaticStatic => _accessor.Static;
        public IReadOnlyDictionary<Int32, IPlayerLevel> LevelsStatic => _accessor.Levels;

        #endregion

        #region Interface

        private ReactiveProperty<Int32> Interface_Level;
        IReadOnlyReactiveProperty<Int32> IPlayerStateClient.Level => Interface_Level;
        private ReactiveProperty<Int32> Interface_Exp;
        IReadOnlyReactiveProperty<Int32> IPlayerStateClient.Exp => Interface_Exp;
        private ReactiveProperty<String> Interface_RegisterTime;
        IReadOnlyReactiveProperty<String> IPlayerStateClient.RegisterTime => Interface_RegisterTime;
        private ReactiveProperty<String> Interface_LastLoginTime;
        IReadOnlyReactiveProperty<String> IPlayerStateClient.LastLoginTime => Interface_LastLoginTime;
        private ReactiveProperty<String> Interface_SyncTime;
        IReadOnlyReactiveProperty<String> IPlayerStateClient.SyncTime => Interface_SyncTime;

        #endregion

        #region Internal

        [JsonName("level")]
        public Int32 _Level;
        [JsonName("exp")]
        public Int32 _Exp;
        [JsonName("reg_time")]
        public String _RegisterTime;
        [JsonName("login_time")]
        public String _LastLoginTime;
        [JsonName("sync_time")]
        public String _SyncTime;

        #endregion

        #region Source

        Int32 IPlayerState.Level
        {
            get => _Level;
            set
            {
                if (_Level == value)
                {
                    return;
                }
                _Level = value;
                var dataId = DataId + $".level.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Level.Value = value; });
            }
        }
        Int32 IPlayerState.Exp
        {
            get => _Exp;
            set
            {
                if (_Exp == value)
                {
                    return;
                }
                _Exp = value;
                var dataId = DataId + $".exp.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Exp.Value = value; });
            }
        }
        String IPlayerState.RegisterTime
        {
            get => _RegisterTime;
            set
            {
                if (_RegisterTime == value)
                {
                    return;
                }
                _RegisterTime = value;
                var dataId = DataId + $".reg_time.{value}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_RegisterTime.Value = value; });
            }
        }
        String IPlayerState.LastLoginTime
        {
            get => _LastLoginTime;
            set
            {
                if (_LastLoginTime == value)
                {
                    return;
                }
                _LastLoginTime = value;
                var dataId = DataId + $".login_time.{value}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_LastLoginTime.Value = value; });
            }
        }
        String IPlayerState.SyncTime
        {
            get => _SyncTime;
            set
            {
                if (_SyncTime == value)
                {
                    return;
                }
                _SyncTime = value;
                var dataId = DataId + $".sync_time.{value}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_SyncTime.Value = value; });
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Level;
            result += _Exp;
            result += _RegisterTime;
            result += _LastLoginTime;
            result += _SyncTime;
            return result;
        }

        #endregion

    }
}
