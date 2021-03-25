using VetsEngine.MetaLogic.Core;
using MigrationLogic.Logic.Accessors;

namespace MigrationLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class MigrationsModule
    {
        public MigrationsAccessor _migrations;

        [Command]
        public void MigrationTest()
        {
            _migrations.MigrationTest();
        }
    }
}
