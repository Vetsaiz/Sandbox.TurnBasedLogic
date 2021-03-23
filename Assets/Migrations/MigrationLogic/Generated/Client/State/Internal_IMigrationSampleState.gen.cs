using System;
using System.Collections.Generic;
using System.Linq;
using MigrationLogic.Logic.Accessors;
using MigrationLogic.Logic.StateData;
using Pathfinding.Serialization.JsonFx;
using UniRx;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core.Collections.Logic;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Client.State
{
    internal class Internal_IMigrationSampleState : IMigrationSampleStateClient, IMigrationSampleState 
    {
        private ChangeStorage _storage;
        private string DataId = "migrationSampleState";
        private MigrationsAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, MigrationsAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            Interface_Field1 = _Field1;
            if (_FieldString != null)
            {
                foreach (var temp in _FieldString)
                {
                    temp.InitData($"{DataId}.field2", storage);
                }
            }
            Interface_FieldString = _FieldString;
            _State1?.InitData(DataId, storage);
            Interface_State1 = _State1;
            LD_State2?.Init($"{DataId}.test_state2", storage, _State2);
            LL_State3?.Init($"{DataId}.test_state3", storage, _State3);
            LL_State4?.Init($"{DataId}.test_state3", storage, _State4);
            LD_State5?.Init($"{DataId}.test_state2", storage, _State5);
            LD_State6?.Init($"{DataId}.test_state2", storage, _State6);
        }
        public void PreSave()
        {
            _State1?.PreSave();
            foreach (var temp in LD_State2.Source)
            {
                temp.Value.PreSave();
            }
            _State2 = LD_State2.Source;
            foreach (var temp in LL_State3)
            {
                (temp as Internal_IMigrationSubState).PreSave();
            }
            foreach (var temp in LL_State4)
            {
                (temp as Internal_IMigrationSubState).PreSave();
            }
            _State5 = LD_State5.Source;
            _State6 = LD_State6.Source;
        }

        #region Queries


        #endregion

        #region Interface

        private Int32 Interface_Field1;
        Int32 IMigrationSampleStateClient.Field1 => Interface_Field1;
        public ILogicList<IMigrationSubState_1> FieldString { get; }
        private IMigrationSubState_1Client[] Interface_FieldString;
        IMigrationSubState_1Client[] IMigrationSampleStateClient.FieldString => Interface_FieldString;
        private IMigrationSubState_1Client Interface_State1;
        IMigrationSubState_1Client IMigrationSampleStateClient.State1 => Interface_State1;
        IReadOnlyReactiveDictionary<Int32, IMigrationSubStateClient> IMigrationSampleStateClient.State2 => LD_State2.Interface;
        public IReadOnlyReactiveProperty<IMigrationSubStateClient> GetState2Property(Int32 key)
        {
            return LD_State2.GetProperty(key);
        }
        IReadOnlyReactiveCollection<IMigrationSubStateClient> IMigrationSampleStateClient.State3 => LL_State3.Interface;
        IReadOnlyReactiveCollection<IMigrationSubStateClient> IMigrationSampleStateClient.State4 => LL_State4.Interface;
        public IReadOnlyReactiveProperty<IReadOnlyReactiveCollection<Int32>> GetState5Property(Int32 key)
        {
            return LD_State5.GetProperty(key);
        }
        public IReadOnlyReactiveProperty<IReadOnlyReactiveCollection<IMigrationSubStateClient>> GetState6Property(Int32 key)
        {
            return LD_State6.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("field1")]
        public Int32 _Field1;
        [JsonName("field2")]
        public Internal_IMigrationSubState_1[] _FieldString;
        [JsonName("test_state1")]
        public Internal_IMigrationSubState_1 _State1;
        [JsonName("test_state2")]
        public Dictionary<string, Internal_IMigrationSubState> _State2 = new Dictionary<string, Internal_IMigrationSubState>();
        private InternalLogicDictionary<Int32, Internal_IMigrationSubState, IMigrationSubState, IMigrationSubStateClient> LD_State2 = new InternalLogicDictionary<Int32, Internal_IMigrationSubState, IMigrationSubState, IMigrationSubStateClient>();
        [JsonName("test_state3")]
        public List<Internal_IMigrationSubState> _State3 = new List<Internal_IMigrationSubState>();
        private InternalLogicList<Internal_IMigrationSubState, IMigrationSubState, IMigrationSubStateClient> LL_State3 = new InternalLogicList<Internal_IMigrationSubState, IMigrationSubState, IMigrationSubStateClient>();
        [JsonName("test_state3")]
        public List<Internal_IMigrationSubState> _State4 = new List<Internal_IMigrationSubState>();
        private InternalLogicList<Internal_IMigrationSubState, IMigrationSubState, IMigrationSubStateClient> LL_State4 = new InternalLogicList<Internal_IMigrationSubState, IMigrationSubState, IMigrationSubStateClient>();
        [JsonName("test_state2")]
        public Dictionary<string, Int32[]> _State5 = new Dictionary<string, Int32[]>();
        private InternalValueListDictionary<Int32, Int32> LD_State5 = new InternalValueListDictionary<Int32, Int32>();
        [JsonName("test_state2")]
        public Dictionary<string, Internal_IMigrationSubState[]> _State6 = new Dictionary<string, Internal_IMigrationSubState[]>();
        private InternalInternalListDictionary<Int32, Internal_IMigrationSubState,IMigrationSubState, IMigrationSubStateClient> LD_State6 = new InternalInternalListDictionary<Int32, Internal_IMigrationSubState,IMigrationSubState, IMigrationSubStateClient>();

        #endregion

        #region Source

        Int32 IMigrationSampleState.Field1
        {
            get => _Field1;
        }
        IMigrationSubState_1 IMigrationSampleState.State1
        {
            get => _State1;
        }
        ILogicDictionary<Int32, IMigrationSubState> IMigrationSampleState.State2
        {
            get => LD_State2;
        }
        ILogicList<IMigrationSubState> IMigrationSampleState.State3
        {
            get => LL_State3;
        }
        ILogicList<IMigrationSubState> IMigrationSampleState.State4
        {
            get => LL_State4;
        }
        ILogicDictionary<Int32, ILogicList<Int32>> IMigrationSampleState.State5
        {
            get => LD_State5;
        }
        ILogicDictionary<Int32, ILogicList<IMigrationSubState>> IMigrationSampleState.State6
        {
            get => LD_State6;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Field1;
            result += _FieldString != null ? string.Join("", _FieldString.Select(x=>x?.ToString())) : "";
            result += _State1?.ToString();
            result += LD_State2.ToString();
            result += LL_State3.ToString();
            result += LL_State4.ToString();
            result += LD_State5.ToString();
            result += LD_State6.ToString();
            return result;
        }

        #endregion

    }
}
