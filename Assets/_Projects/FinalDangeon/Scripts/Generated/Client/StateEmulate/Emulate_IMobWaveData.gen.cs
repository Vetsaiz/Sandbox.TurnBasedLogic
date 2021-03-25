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
    internal class Emulate_IMobWaveData : IMobWaveDataEmulate, IMobWaveData 
    , IInitStateData<IMobWaveDataClient>, IInitStateData<IMobWaveData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IMobWaveDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            Id = client.Id;
            Position = client.Position;
        }

        public void InitData(IMobWaveData data, ChangeStorage storage)
        {
            _storage = storage;
            Id = data.Id;
            Position = data.Position;
        }

        #region Common

        public Int32 Id { get; private set; }
        public Int32 Position { get; private set; }

        #endregion

        #region Interface


        #endregion

        #region Internal


        #endregion

        #region Source


        #endregion

    }
}
