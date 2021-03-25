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
    internal class Internal_ISettingsState : ISettingsStateClient, ISettingsState 
    {
        private ChangeStorage _storage;
        private string DataId = "settingsState";
        private SettingsAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, SettingsAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            Interface_MusicOff = new ReactiveProperty<Boolean>(_MusicOff);
            Interface_SoundOff = new ReactiveProperty<Boolean>(_SoundOff);
            Interface_RegTime = _RegTime;
            Interface_LoginTime = _LoginTime;
            Interface_SyncTime = _SyncTime;
            Interface_Locale = new ReactiveProperty<String>(_Locale);
            Interface_Server = new ReactiveProperty<ServerType>(_Server);
            Interface_CurrentVersion = new ReactiveProperty<String>(_CurrentVersion);
            Interface_Build = new ReactiveProperty<Int32>(_Build);
            Interface_RandomState = new ReactiveProperty<Int32>(_RandomState);
            Interface_PushStatus = new ReactiveProperty<Boolean>(_PushStatus);
        }
        public void PreSave()
        {
        }

        #region Queries

        public Int32 GetSettingsMoneyIcon(System.Int32 delta)
        {
            return _accessor.GetSettingsMoneyIcon(delta);
        }
        public IPrice GetPriceRefresh(System.Int32 number)
        {
            return _accessor.GetPriceRefresh(number);
        }
        public IPrice GetPriceStamina(System.Int32 number)
        {
            return _accessor.GetPriceStamina(number);
        }
        public Int32 GetIntVersion(System.String version)
        {
            return _accessor.GetIntVersion(version);
        }
        public ISettingsStatic SettingsStatic => _accessor.Settings;

        #endregion

        #region Interface

        private ReactiveProperty<Boolean> Interface_MusicOff;
        IReadOnlyReactiveProperty<Boolean> ISettingsStateClient.MusicOff => Interface_MusicOff;
        private ReactiveProperty<Boolean> Interface_SoundOff;
        IReadOnlyReactiveProperty<Boolean> ISettingsStateClient.SoundOff => Interface_SoundOff;
        private Int64 Interface_RegTime;
        Int64 ISettingsStateClient.RegTime => Interface_RegTime;
        private Int64 Interface_LoginTime;
        Int64 ISettingsStateClient.LoginTime => Interface_LoginTime;
        private Int64 Interface_SyncTime;
        Int64 ISettingsStateClient.SyncTime => Interface_SyncTime;
        private ReactiveProperty<String> Interface_Locale;
        IReadOnlyReactiveProperty<String> ISettingsStateClient.Locale => Interface_Locale;
        private ReactiveProperty<ServerType> Interface_Server;
        IReadOnlyReactiveProperty<ServerType> ISettingsStateClient.Server => Interface_Server;
        private ReactiveProperty<String> Interface_CurrentVersion;
        IReadOnlyReactiveProperty<String> ISettingsStateClient.CurrentVersion => Interface_CurrentVersion;
        private ReactiveProperty<Int32> Interface_Build;
        IReadOnlyReactiveProperty<Int32> ISettingsStateClient.Build => Interface_Build;
        private ReactiveProperty<Int32> Interface_RandomState;
        IReadOnlyReactiveProperty<Int32> ISettingsStateClient.RandomState => Interface_RandomState;
        private ReactiveProperty<Boolean> Interface_PushStatus;
        IReadOnlyReactiveProperty<Boolean> ISettingsStateClient.PushStatus => Interface_PushStatus;

        #endregion

        #region Internal

        [JsonName("music_off")]
        public Boolean _MusicOff;
        [JsonName("sound_off")]
        public Boolean _SoundOff;
        [JsonName("reg_time")]
        public Int64 _RegTime;
        [JsonName("login_time")]
        public Int64 _LoginTime;
        [JsonName("sync_time")]
        public Int64 _SyncTime;
        [JsonName("locale")]
        public String _Locale;
        [JsonName("server_type")]
        public ServerType _Server;
        [JsonName("current_version")]
        public String _CurrentVersion;
        [JsonName("build_id")]
        public Int32 _Build;
        [JsonName("random_state")]
        public Int32 _RandomState;
        [JsonName("push_status")]
        public Boolean _PushStatus;

        #endregion

        #region Source

        Boolean ISettingsState.MusicOff
        {
            get => _MusicOff;
            set
            {
                if (_MusicOff == value)
                {
                    return;
                }
                _MusicOff = value;
                var dataId = DataId + $".music_off.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_MusicOff.Value = value; });
            }
        }
        Boolean ISettingsState.SoundOff
        {
            get => _SoundOff;
            set
            {
                if (_SoundOff == value)
                {
                    return;
                }
                _SoundOff = value;
                var dataId = DataId + $".sound_off.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_SoundOff.Value = value; });
            }
        }
        Int64 ISettingsState.RegTime
        {
            get => _RegTime;
        }
        Int64 ISettingsState.LoginTime
        {
            get => _LoginTime;
        }
        Int64 ISettingsState.SyncTime
        {
            get => _SyncTime;
        }
        String ISettingsState.Locale
        {
            get => _Locale;
            set
            {
                if (_Locale == value)
                {
                    return;
                }
                _Locale = value;
                var dataId = DataId + $".locale.{value}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Locale.Value = value; });
            }
        }
        ServerType ISettingsState.Server
        {
            get => _Server;
            set
            {
                if (_Server == value)
                {
                    return;
                }
                _Server = value;
                var dataId = DataId + $".server_type.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Server.Value = value; });
            }
        }
        String ISettingsState.CurrentVersion
        {
            get => _CurrentVersion;
            set
            {
                if (_CurrentVersion == value)
                {
                    return;
                }
                _CurrentVersion = value;
                var dataId = DataId + $".current_version.{value}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CurrentVersion.Value = value; });
            }
        }
        Int32 ISettingsState.Build
        {
            get => _Build;
            set
            {
                if (_Build == value)
                {
                    return;
                }
                _Build = value;
                var dataId = DataId + $".build_id.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Build.Value = value; });
            }
        }
        Int32 ISettingsState.RandomState
        {
            get => _RandomState;
            set
            {
                if (_RandomState == value)
                {
                    return;
                }
                _RandomState = value;
                var dataId = DataId + $".random_state.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_RandomState.Value = value; });
            }
        }
        Boolean ISettingsState.PushStatus
        {
            get => _PushStatus;
            set
            {
                if (_PushStatus == value)
                {
                    return;
                }
                _PushStatus = value;
                var dataId = DataId + $".push_status.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_PushStatus.Value = value; });
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _MusicOff;
            result += _SoundOff;
            result += _RegTime;
            result += _LoginTime;
            result += _SyncTime;
            result += _Locale;
            result += _Server;
            result += _CurrentVersion;
            result += _Build;
            result += _RandomState;
            result += _PushStatus;
            return result;
        }

        #endregion

    }
}
