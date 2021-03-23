using MetaLogic.Contracts;
using MigrationLogic.Data;
using MigrationLogic.Shared;
using VetsEngine.MetaLogic.Core;

namespace MigrationLogic.Server
{
    internal partial class InternalAdditionalLogics : ILogicAPI
    {
        public InternalAdditionalLogics(InternalAccessors accessors, IApplyManager storage, LogicData data, IMigrationsExternalAPI api)
        {
        }
        public void PostInit()
        {
        }
    }
}
