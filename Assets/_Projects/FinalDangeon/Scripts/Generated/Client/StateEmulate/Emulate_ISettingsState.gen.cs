using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
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
    internal class Emulate_ISettingsState : ISettingsStateEmulate, ISettingsState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private SettingsAccessor _accessor;
        public void InitData(ISettingsStateClient client, SettingsAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            client.MusicOff.Subscribe(x => _MusicOff = x).AddTo(_disposables);
            client.SoundOff.Subscribe(x => _SoundOff = x).AddTo(_disposables);
            RegTime = client.RegTime;
            LoginTime = client.LoginTime;
            SyncTime = client.SyncTime;
            client.Locale.Subscribe(x => _Locale = x).AddTo(_disposables);
            client.Server.Subscribe(x => _Server = x).AddTo(_disposables);
            client.CurrentVersion.Subscribe(x => _CurrentVersion = x).AddTo(_disposables);
            client.Build.Subscribe(x => _Build = x).AddTo(_disposables);
            client.RandomState.Subscribe(x => _RandomState = x).AddTo(_disposables);
            client.PushStatus.Subscribe(x => _PushStatus = x).AddTo(_disposables);
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

        #region Common

        private Boolean _MusicOff;
        public Boolean  MusicOff
        {
            get => _MusicOff;
               set
            {
                 var backValue = _MusicOff;
                _storage.AddBackAction(() => _MusicOff = backValue);
                _MusicOff = value;
            }
        }
        private Boolean _SoundOff;
        public Boolean  SoundOff
        {
            get => _SoundOff;
               set
            {
                 var backValue = _SoundOff;
                _storage.AddBackAction(() => _SoundOff = backValue);
                _SoundOff = value;
            }
        }
        public Int64 RegTime { get; private set; }
        public Int64 LoginTime { get; private set; }
        public Int64 SyncTime { get; private set; }
        private String _Locale;
        public String  Locale
        {
            get => _Locale;
               set
            {
                 var backValue = _Locale;
                _storage.AddBackAction(() => _Locale = backValue);
                _Locale = value;
            }
        }
        private ServerType _Server;
        public ServerType  Server
        {
            get => _Server;
               set
            {
                 var backValue = _Server;
                _storage.AddBackAction(() => _Server = backValue);
                _Server = value;
            }
        }
        private String _CurrentVersion;
        public String  CurrentVersion
        {
            get => _CurrentVersion;
               set
            {
                 var backValue = _CurrentVersion;
                _storage.AddBackAction(() => _CurrentVersion = backValue);
                _CurrentVersion = value;
            }
        }
        private Int32 _Build;
        public Int32  Build
        {
            get => _Build;
               set
            {
                 var backValue = _Build;
                _storage.AddBackAction(() => _Build = backValue);
                _Build = value;
            }
        }
        private Int32 _RandomState;
        public Int32  RandomState
        {
            get => _RandomState;
               set
            {
                 var backValue = _RandomState;
                _storage.AddBackAction(() => _RandomState = backValue);
                _RandomState = value;
            }
        }
        private Boolean _PushStatus;
        public Boolean  PushStatus
        {
            get => _PushStatus;
               set
            {
                 var backValue = _PushStatus;
                _storage.AddBackAction(() => _PushStatus = backValue);
                _PushStatus = value;
            }
        }

        #endregion

        #region Interface


        #endregion

        #region Internal


        #endregion

        #region Source


        #endregion

    }
}
