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
    internal class Emulate_IAchievementData : IAchievementDataEmulate, IAchievementData 
    , IInitStateData<IAchievementDataClient>, IInitStateData<IAchievementData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IAchievementDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            client.RefreshNumber.Subscribe(x => _RefreshNumber = x).AddTo(_disposables);
            client.FinishTime.Subscribe(x => _FinishTime = x).AddTo(_disposables);
            client.Complete.Subscribe(x => _Complete = x).AddTo(_disposables);
        }

        public void InitData(IAchievementData data, ChangeStorage storage)
        {
            _storage = storage;
            RefreshNumber = data.RefreshNumber;
            FinishTime = data.FinishTime;
            Complete = data.Complete;
        }

        #region Common

        private Int32 _RefreshNumber;
        public Int32  RefreshNumber
        {
            get => _RefreshNumber;
               set
            {
                 var backValue = _RefreshNumber;
                _storage.AddBackAction(() => _RefreshNumber = backValue);
                _RefreshNumber = value;
            }
        }
        private Int64 _FinishTime;
        public Int64  FinishTime
        {
            get => _FinishTime;
               set
            {
                 var backValue = _FinishTime;
                _storage.AddBackAction(() => _FinishTime = backValue);
                _FinishTime = value;
            }
        }
        private Boolean _Complete;
        public Boolean  Complete
        {
            get => _Complete;
               set
            {
                 var backValue = _Complete;
                _storage.AddBackAction(() => _Complete = backValue);
                _Complete = value;
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
