using System;
using System.Collections.Generic;
using MigrationLogic.Shared;
using Pathfinding.Serialization.JsonFx;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Client.State
{
    internal class Internal_StateData : IStateData
    {
        string DataId = "root";
        ServerStateData _serverData;
        [JsonIgnore]
        public Internal_IMigrationSampleState _MigrationSampleState;
        [JsonName("field1")]
        public Int32 Internal_IMigrationSampleState_Field1;
        [JsonName("field2")]
        public Internal_IMigrationSubState_1[] Internal_IMigrationSampleState_FieldString;
        [JsonName("test_state1")]
        public Internal_IMigrationSubState_1 Internal_IMigrationSampleState_State1;
        [JsonName("test_state2")]
        public Dictionary<string, Internal_IMigrationSubState> Internal_IMigrationSampleState_State2 = new Dictionary<string, Internal_IMigrationSubState>();
        [JsonName("test_state3")]
        public List<Internal_IMigrationSubState> Internal_IMigrationSampleState_State3 = new List<Internal_IMigrationSubState>();
        [JsonName("test_state3")]
        public List<Internal_IMigrationSubState> Internal_IMigrationSampleState_State4 = new List<Internal_IMigrationSubState>();
        [JsonName("test_state2")]
        public Dictionary<string, Int32[]> Internal_IMigrationSampleState_State5 = new Dictionary<string, Int32[]>();
        [JsonName("test_state2")]
        public Dictionary<string, Internal_IMigrationSubState[]> Internal_IMigrationSampleState_State6 = new Dictionary<string, Internal_IMigrationSubState[]>();

        public IMigrationSampleStateClient MigrationSampleState => _MigrationSampleState;

        public Internal_StateData()
        {
            _MigrationSampleState = new Internal_IMigrationSampleState(); 
        }

        public void InitData(ChangeStorage storage, InternalAccessors _accessors)
        {
            _MigrationSampleState._Field1 = Internal_IMigrationSampleState_Field1;
            _MigrationSampleState._FieldString = Internal_IMigrationSampleState_FieldString;
            _MigrationSampleState._State1 = Internal_IMigrationSampleState_State1;
            _MigrationSampleState._State2 = Internal_IMigrationSampleState_State2;
            _MigrationSampleState._State3 = Internal_IMigrationSampleState_State3;
            _MigrationSampleState._State4 = Internal_IMigrationSampleState_State4;
            _MigrationSampleState._State5 = Internal_IMigrationSampleState_State5;
            _MigrationSampleState._State6 = Internal_IMigrationSampleState_State6;
            _MigrationSampleState.InitData(DataId, storage, _accessors.MigrationsAccessor);
        }
        public void PreSave()
        {
            _MigrationSampleState.PreSave();
            Internal_IMigrationSampleState_Field1 = _MigrationSampleState._Field1;
            Internal_IMigrationSampleState_FieldString = _MigrationSampleState._FieldString;
            Internal_IMigrationSampleState_State1 = _MigrationSampleState._State1;
            Internal_IMigrationSampleState_State2 = _MigrationSampleState._State2;
            Internal_IMigrationSampleState_State3 = _MigrationSampleState._State3;
            Internal_IMigrationSampleState_State4 = _MigrationSampleState._State4;
            Internal_IMigrationSampleState_State5 = _MigrationSampleState._State5;
            Internal_IMigrationSampleState_State6 = _MigrationSampleState._State6;
        }

        public void UpdateServerState(ServerStateData data)
        {
            _serverData = data;
        }

        public void SetServerState(ServerStateData data)
        {
            _serverData = data;
        }
    }
}
