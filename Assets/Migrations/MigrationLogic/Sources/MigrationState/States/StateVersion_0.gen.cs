using System;
using MetaLogic.Contracts;
using Pathfinding.Serialization.JsonFx;

namespace MigrationLogic.MigrationState.States
{
    public class StateVersion_0 : IMigrationState
    {
        public int StateVersion => 0;
        public int Version => 10;

        [JsonName("migrationSampleState")]
        public IMigrationSampleState_0 MigrationSampleState;

        public class IMigrationSampleState_0
        {

            [JsonName("field1")]
            public Int32 Field1;

            [JsonName("field2")]
            public String[] Field2;

        }
    }
}
