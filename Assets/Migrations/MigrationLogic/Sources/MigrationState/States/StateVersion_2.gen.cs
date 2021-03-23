using System;
using System.Collections.Generic;
using System.Linq;
using MetaLogic.Contracts;
using Pathfinding.Serialization.JsonFx;

namespace MigrationLogic.MigrationState.States
{
    public class StateVersion_2 : IMigrationState<StateVersion_1>
    {
        public int StateVersion => 2;
        public int Version => 10;

        [JsonName("migrationSampleState")]
        public IMigrationSampleState_2 MigrationSampleState;

        public IMigrationState<StateVersion_1> CopyTo(StateVersion_1 oldData)
        {
            var newData = new StateVersion_2();
            newData.MigrationSampleState = IMigrationSampleState_2.CopyTo(oldData.MigrationSampleState);
            return newData;
        }
        public class IMigrationSampleState_2
        {

            // ----------------- Added fields -----------------------------

            [JsonName("test_state2")]
            public Dictionary<String, Int32[]> State5;

            [JsonName("test_state2")]
            public Dictionary<String, IMigrationSubState_2[]> State6;

            [JsonName("field2")]
            public string[] FieldString;

            // ------------------------------------------------------------

            [JsonName("field1")]
            public Int32 Field1;

            [JsonName("test_state1")]
            public IMigrationSubState_2 State1;

            [JsonName("test_state2")]
            public Dictionary<String, IMigrationSubState_2> State2;

            [JsonName("test_state3")]
            public IMigrationSubState_2[] State3;

            [JsonName("test_state3")]
            public IMigrationSubState_2[] State4;

            public static IMigrationSampleState_2 CopyTo(StateVersion_1.IMigrationSampleState_1 oldData)
            {
                var newData = new IMigrationSampleState_2();
                newData.Field1 = oldData.Field1;
                newData.State1 = IMigrationSubState_2.CopyTo(oldData.State1);
                newData.State2 = oldData.State2.ToDictionary(x => x.Key, x => IMigrationSubState_2.CopyTo(x.Value));
                newData.State3 = oldData.State3.Select(IMigrationSubState_2.CopyTo).ToArray();
                newData.State4 = oldData.State4.Select(IMigrationSubState_2.CopyTo).ToArray();
                return newData;
            }
        }
        public class IMigrationSubState_2
        {

            [JsonName("field1")]
            public Int32 Field1;

            public static IMigrationSubState_2 CopyTo(StateVersion_1.IMigrationSubState_1 oldData)
            {
                var newData = new IMigrationSubState_2();
                newData.Field1 = oldData.Field1;
                return newData;
            }
        }
    }
}
