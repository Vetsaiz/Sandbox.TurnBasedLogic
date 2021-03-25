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
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IMobWave : IMobWaveEmulate, IMobWave 
    , IInitStateData<IMobWaveClient>, IInitStateData<IMobWave>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IMobWaveClient client, ChangeStorage storage)
        {
            _storage = storage;
            LD_MobData.Init(client.MobData, storage);
        }

        public void InitData(IMobWave data, ChangeStorage storage)
        {
            _storage = storage;
            LD_MobData.Init(data.MobData, storage);
        }

        #region Common


        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, IMobWaveDataEmulate> IMobWaveEmulate.MobData => LD_MobData;

        #endregion

        #region Internal

        ILogicDictionary<Int32, IMobWaveData> IMobWave.MobData => LD_MobData;

        #endregion

        #region Source

        public InternalEmulateDictionary<Int32,Emulate_IMobWaveData, IMobWaveData, IMobWaveDataEmulate> LD_MobData { get; } = new InternalEmulateDictionary<Int32,Emulate_IMobWaveData, IMobWaveData, IMobWaveDataEmulate>();

        #endregion

    }
}
