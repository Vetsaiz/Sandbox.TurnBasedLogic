using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Migrations;

//using Migrations.Migrations.States;

namespace MigrationLogic.Migrations
{
    internal class MigrationHelper : BaseMigrationHelper
    {
        public MigrationHelper()
        {
            var list = new List<IMigrationData>()
            {
                //new MigrationData<StateData_0>(this, new StateData_0(), new StateData_1()),
                //new MigrationData<StateData_1>(this, new StateData_1(), new StateData_2()),
                //new MigrationData<StateData_2>(this, new StateData_2(), new StateData_3()),
                //new MigrationData<StateData_3>(this, new StateData_3(), new StateData_4()),
            };
            AddAllMigrations(list);
        }
    }

}
