//using MetaLogic.Contracts;
//using Pathfinding.Serialization.JsonFx;

//namespace Migrations.Migrations.States
//{
//    public class StateData_1 : IMigrationState<StateData_0>
//    {
//        public int StateVersion => 1;
//        public int Version => 5;

//        // ----------------- Added fields -----------------------------

//        [JsonName("field1")]
//        public int Field1;

//        // ------------------------------------------------------------

//        public IMigrationState<StateData_0> CopyTo(StateData_0 oldData)
//        {
//            var newData = new StateData_1();
//            return newData;
//        }
//    }

//}
