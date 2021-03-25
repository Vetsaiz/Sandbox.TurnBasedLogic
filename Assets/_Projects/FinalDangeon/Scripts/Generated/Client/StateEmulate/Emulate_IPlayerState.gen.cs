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
    internal class Emulate_IPlayerState : IPlayerStateEmulate, IPlayerState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private PlayerAccessor _accessor;
        public void InitData(IPlayerStateClient client, PlayerAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            client.Level.Subscribe(x => _Level = x).AddTo(_disposables);
            client.Exp.Subscribe(x => _Exp = x).AddTo(_disposables);
            client.RegisterTime.Subscribe(x => _RegisterTime = x).AddTo(_disposables);
            client.LastLoginTime.Subscribe(x => _LastLoginTime = x).AddTo(_disposables);
            client.SyncTime.Subscribe(x => _SyncTime = x).AddTo(_disposables);
        }


        #region Queries

        public IPlayerStatic StaticStatic => _accessor.Static;
        public IReadOnlyDictionary<Int32, IPlayerLevel> LevelsStatic => _accessor.Levels;

        #endregion

        #region Common

        private Int32 _Level;
        public Int32  Level
        {
            get => _Level;
               set
            {
                 var backValue = _Level;
                _storage.AddBackAction(() => _Level = backValue);
                _Level = value;
            }
        }
        private Int32 _Exp;
        public Int32  Exp
        {
            get => _Exp;
               set
            {
                 var backValue = _Exp;
                _storage.AddBackAction(() => _Exp = backValue);
                _Exp = value;
            }
        }
        private String _RegisterTime;
        public String  RegisterTime
        {
            get => _RegisterTime;
               set
            {
                 var backValue = _RegisterTime;
                _storage.AddBackAction(() => _RegisterTime = backValue);
                _RegisterTime = value;
            }
        }
        private String _LastLoginTime;
        public String  LastLoginTime
        {
            get => _LastLoginTime;
               set
            {
                 var backValue = _LastLoginTime;
                _storage.AddBackAction(() => _LastLoginTime = backValue);
                _LastLoginTime = value;
            }
        }
        private String _SyncTime;
        public String  SyncTime
        {
            get => _SyncTime;
               set
            {
                 var backValue = _SyncTime;
                _storage.AddBackAction(() => _SyncTime = backValue);
                _SyncTime = value;
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
