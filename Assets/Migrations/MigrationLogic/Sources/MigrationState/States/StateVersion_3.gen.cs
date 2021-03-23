using System;
using System.Collections.Generic;
using System.Linq;
using MetaLogic.Contracts;
using Pathfinding.Serialization.JsonFx;

namespace MigrationLogic.MigrationState.States
{
    public class StateVersion_3 : IMigrationState<StateVersion_2>
    {
        public int StateVersion => 3;
        public int Version => 10;

        [JsonName("migrationSampleState")]
        public IMigrationSampleState_3 MigrationSampleState;

        public IMigrationState<StateVersion_2> CopyTo(StateVersion_2 oldData)
        {
            var newData = new StateVersion_3();
            newData.MigrationSampleState = IMigrationSampleState_3.CopyTo(oldData.MigrationSampleState);
            return newData;
        }
        public class IMigrationSampleState_3
        {

            // ----------------- Changed fields ---------------------------

            [JsonName("field2")]
            public IMigrationSubState_1_3[] FieldString;

            [JsonName("test_state1")]
            public IMigrationSubState_1_3 State1;


            // ------------------------------------------------------------

            [JsonName("field1")]
            public Int32 Field1;

            [JsonName("test_state2")]
            public Dictionary<String, IMigrationSubState_3> State2;

            [JsonName("test_state3")]
            public IMigrationSubState_3[] State3;

            [JsonName("test_state3")]
            public IMigrationSubState_3[] State4;

            [JsonName("test_state2")]
            public Dictionary<String, Int32[]> State5;

            [JsonName("test_state2")]
            public Dictionary<String, IMigrationSubState_3[]> State6;

            public static IMigrationSampleState_3 CopyTo(StateVersion_2.IMigrationSampleState_2 oldData)
            {
                var newData = new IMigrationSampleState_3();
                newData.Field1 = oldData.Field1;
                newData.State2 = oldData.State2.ToDictionary(x => x.Key, x => IMigrationSubState_3.CopyTo(x.Value));
                newData.State3 = oldData.State3.Select(IMigrationSubState_3.CopyTo).ToArray();
                newData.State4 = oldData.State4.Select(IMigrationSubState_3.CopyTo).ToArray();
                newData.State5 = oldData.State5;
                newData.State6 = oldData.State6.ToDictionary(x => x.Key, x => x.Value.Select(IMigrationSubState_3.CopyTo).ToArray());
                return newData;
            }
        }
        public class IMigrationSubState_3
        {

            // ----------------- Changed fields ---------------------------

            [JsonName("field1")]
            public IMigrationSubState_1_3 Field1;


            // ------------------------------------------------------------

            public static IMigrationSubState_3 CopyTo(StateVersion_2.IMigrationSubState_2 oldData)
            {
                var newData = new IMigrationSubState_3();
                return newData;
            }
        }
        public class IMigrationSubState_1_3
        {

            [JsonName("field1")]
            public Int32 Field1;

        }
    }
}
