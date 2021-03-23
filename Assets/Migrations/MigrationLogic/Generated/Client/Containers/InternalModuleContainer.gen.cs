using MigrationLogic.Data;
using MigrationLogic.Logic.Accessors;
using MigrationLogic.Logic.Modules;
using VetsEngine.MetaLogic.Core;

namespace MigrationLogic.Client
{
    internal partial class InternalModules
    {
        public readonly MigrationsModule MigrationsModule;

        public InternalModules(InternalAccessors accessors, InternalAdditionalLogics additionalLogics, LogicData data, IMigrationsExternalAPI api)
        {
            MigrationsModule = MigrationsModule.CreateClient(accessors.MigrationsAccessor);
        }
    }
}

namespace MigrationLogic.Logic.Modules
{
        internal partial class MigrationsModule
    {
        public static MigrationsModule CreateClient(MigrationsAccessor _migrations)
        {
            return new MigrationsModule
                {
                    _migrations = _migrations,
                }
                ;
        }
    }
}