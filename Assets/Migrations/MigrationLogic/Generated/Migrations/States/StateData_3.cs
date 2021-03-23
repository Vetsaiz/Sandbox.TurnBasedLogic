//using MetaLogic.Contracts;
//using Pathfinding.Serialization.JsonFx;

//namespace Migrations.Migrations.States
//{
//    public class StateData_3 : IMigrationState<StateData_2>
//    {
//        public int StateVersion => 3;
//        public int Version => 25;

//        // ----------------- Added fields -----------------------------

//        [JsonName("field3")]
//        public SubState_3 Field3;

//        // ------------------------------------------------------------

//        [JsonName("field1")]
//        public int Field1;

//        [JsonName("field2")]
//        public string[] Field2;

//        public IMigrationState<StateData_2> CopyTo(StateData_2 oldData)
//        {
//            var newData = new StateData_3();
//            newData.Field1 = oldData.Field1;
//            newData.Field2 = oldData.Field2;
//            return newData;
//        }

//        public class SubState_3
//        {
//            [JsonName("subField1")]
//            public string SubField1;
//        }
//    }

//}
