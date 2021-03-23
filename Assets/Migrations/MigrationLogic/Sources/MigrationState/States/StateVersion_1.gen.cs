using System;
using System.Collections.Generic;
using MetaLogic.Contracts;
using Pathfinding.Serialization.JsonFx;

namespace MigrationLogic.MigrationState.States
{
    public class StateVersion_1 : IMigrationState<StateVersion_0>
    {
        public int StateVersion => 1;
        public int Version => 10;

        [JsonName("migrationSampleState")]
        public IMigrationSampleState_1 MigrationSampleState;

        public IMigrationState<StateVersion_0> CopyTo(StateVersion_0 oldData)
        {
            var newData = new StateVersion_1();
            newData.MigrationSampleState = IMigrationSampleState_1.CopyTo(oldData.MigrationSampleState);
            return newData;
        }
        public class IMigrationSampleState_1
        {

            // ----------------- Added fields -----------------------------

            [JsonName("test_state1")]
            public IMigrationSubState_1 State1;

            [JsonName("test_state2")]
            public Dictionary<String, IMigrationSubState_1> State2;

            [JsonName("test_state3")]
            public IMigrationSubState_1[] State3;

            [JsonName("test_state3")]
            public IMigrationSubState_1[] State4;


            // ------------------------------------------------------------

            // ----------------- Deleted fields----------------------------

            //public String[] Field2;


            // ------------------------------------------------------------

            [JsonName("field1")]
            public Int32 Field1;

            public static IMigrationSampleState_1 CopyTo(StateVersion_0.IMigrationSampleState_0 oldData)
            {
                var newData = new IMigrationSampleState_1();
                newData.Field1 = oldData.Field1;
                return newData;
            }
        }
        public class IMigrationSubState_1
        {

            [JsonName("field1")]
            public Int32 Field1;

        }
    }
}
