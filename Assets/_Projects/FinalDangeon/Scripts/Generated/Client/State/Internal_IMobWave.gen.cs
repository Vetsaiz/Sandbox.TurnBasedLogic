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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IMobWave : IMobWaveClient, IMobWave 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "mobWave";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            LD_MobData?.Init($"{DataId}.mobs", storage, _MobData);
        }
        public void PreSave()
        {
            foreach (var temp in LD_MobData.Source)
            {
                temp.Value.PreSave();
            }
            _MobData = LD_MobData.Source;
        }

        #region Interface

        IReadOnlyReactiveDictionary<Int32, IMobWaveDataClient> IMobWaveClient.MobData => LD_MobData.Interface;
        public IReadOnlyReactiveProperty<IMobWaveDataClient> GetMobDataProperty(Int32 key)
        {
            return LD_MobData.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("mobs")]
        public Dictionary<string, Internal_IMobWaveData> _MobData = new Dictionary<string, Internal_IMobWaveData>();
        private InternalLogicDictionary<Int32, Internal_IMobWaveData, IMobWaveData, IMobWaveDataClient> LD_MobData = new InternalLogicDictionary<Int32, Internal_IMobWaveData, IMobWaveData, IMobWaveDataClient>();

        #endregion

        #region Source

        ILogicDictionary<Int32, IMobWaveData> IMobWave.MobData
        {
            get => LD_MobData;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_MobData.ToString();
            return result;
        }

        #endregion

    }
}
