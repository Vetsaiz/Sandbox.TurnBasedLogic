//using MetaLogic.Contracts;
//using Pathfinding.Serialization.JsonFx;

//namespace Migrations.Migrations.States
//{
//    public class StateData_2 : IMigrationState<StateData_1>
//    {
//        public int StateVersion => 2;
//        public int Version => 15;

//        // ----------------- Added fields -----------------------------

//        [JsonName("field2")]
//        public string[] Field2;

//        // ------------------------------------------------------------

//        [JsonName("field1")]
//        public int Field1;

//        public IMigrationState<StateData_1> CopyTo(StateData_1 oldData)
//        {
//            var newData = new StateData_2();
//            newData.Field1 = oldData.Field1;
//            return newData;
//        }
//    }
//}
