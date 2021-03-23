using MigrationLogic.Data;
using MigrationLogic.Logic.Accessors;
using MigrationLogic.Logic.Modules;
using VetsEngine.MetaLogic.Core;

namespace MigrationLogic.Server
{
    internal partial class InternalModules
    {
        public readonly MigrationsModule MigrationsModule;

        public InternalModules(InternalAccessors accessors, InternalAdditionalLogics additionalLogics, LogicData data, IMigrationsExternalAPI api)
        {
            MigrationsModule = MigrationsModule.CreateServer(accessors.MigrationsAccessor);
        }
    }
}

namespace MigrationLogic.Logic.Modules
    {
        internal partial class MigrationsModule
    {
        public static MigrationsModule CreateServer(MigrationsAccessor _migrations)
        {
            return new MigrationsModule
                {
                    _migrations = _migrations,
                }
                ;
        }
    }
}