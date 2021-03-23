//using MetaLogic.Contracts;
//using Pathfinding.Serialization.JsonFx;

//namespace Migrations.Migrations.States
//{
//    public class StateData_4 : IMigrationState<StateData_3>
//    {
//        public int StateVersion => 4;
//        public int Version => 30;

//        // ----------------- Changed fields ---------------------------

//        [JsonName("field1")]
//        public string Field1;

//        // ------------------------------------------------------------

//        // ----------------- Deleted fields----------------------------

//        //[JsonName("field2")]
//        //public string[] Field2;

//        // ----------------------------------------------------------- 

//        [JsonName("field1")]
//        public SubState_4 Field3;

//        public class SubState_4
//        {
//            // ----------------- Added fields ------------------------------

//            [JsonName("subField2")]
//            public int SubField2;

//            // ------------------------------------------------------------

//            [JsonName("subField1")]
//            public string SubField1;

//            public static SubState_4 CopyTo(StateData_3.SubState_3 oldData)
//            {
//                var newData = new SubState_4();
//                newData.SubField1 = oldData.SubField1;
//                return newData;
//            }
//        }

//        public IMigrationState<StateData_3> CopyTo(StateData_3 oldData)
//        {
//            var newData = new StateData_4();
//            newData.Field3 = SubState_4.CopyTo(oldData.Field3);
//            return newData;
//        }
//    }
//}
