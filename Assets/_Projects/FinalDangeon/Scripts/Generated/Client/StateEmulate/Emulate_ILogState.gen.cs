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
using VetsEngine.MetaLogic.Contracts;


namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_ILogState : ILogStateEmulate, ILogState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private LogAccessor _accessor;
        public void InitData(ILogStateClient client, LogAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            LD_Log.Init(client.Log, storage);
        }


        #region Queries


        #endregion

        #region Common


        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, LogData> ILogStateEmulate.Log => LD_Log;

        #endregion

        #region Internal

        ILogicDictionary<Int32, LogData> ILogState.Log => LD_Log;

        #endregion

        #region Source

        public ValueEmulateDictionary<Int32, LogData> LD_Log { get; } = new ValueEmulateDictionary<Int32, LogData>();

        #endregion

    }
}
