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
    internal class Internal_IMobWaveData : IMobWaveDataClient, IMobWaveData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "mobWaveData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_Id = _Id;
            Interface_Position = _Position;
        }
        public void PreSave()
        {
        }

        #region Interface

        private Int32 Interface_Id;
        Int32 IMobWaveDataClient.Id => Interface_Id;
        private Int32 Interface_Position;
        Int32 IMobWaveDataClient.Position => Interface_Position;

        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("position")]
        public Int32 _Position;

        #endregion

        #region Source

        Int32 IMobWaveData.Id
        {
            get => _Id;
        }
        Int32 IMobWaveData.Position
        {
            get => _Position;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Id;
            result += _Position;
            return result;
        }

        #endregion

    }
}
