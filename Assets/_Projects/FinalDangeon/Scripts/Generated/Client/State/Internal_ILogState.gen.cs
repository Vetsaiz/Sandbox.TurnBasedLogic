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
    internal class Internal_ILogState : ILogStateClient, ILogState 
    {
        private ChangeStorage _storage;
        private string DataId = "logState";
        private LogAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, LogAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            LD_Log?.Init($"{DataId}.log", storage, _Log);
        }
        public void PreSave()
        {
            _Log = LD_Log.Source;
        }

        #region Queries


        #endregion

        #region Interface

        IReadOnlyReactiveDictionary<Int32, LogData> ILogStateClient.Log => LD_Log.Interface;
        public IReadOnlyReactiveProperty<LogData> GetLogProperty(Int32 key)
        {
            return LD_Log.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("log")]
        public Dictionary<string, LogData> _Log = new Dictionary<string, LogData>();
        private ReferenceLogicDictionary<Int32, LogData> LD_Log = new ReferenceLogicDictionary<Int32, LogData>();

        #endregion

        #region Source

        ILogicDictionary<Int32, LogData> ILogState.Log
        {
            get => LD_Log;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_Log.ToString();
            return result;
        }

        #endregion

    }
}
