using System;
using VetsEngine.MetaLogic.Core;

namespace MigrationLogic.Server
{
    internal class InternalCommands : IServerCommandExecutor
    {
        private InternalModules _modules;

        public InternalCommands(InternalModules modules)
        {
            _modules = modules;
        }
        public void Execute(string nameCommand, object[] args, Action callback)
        {
            switch (nameCommand)
            {
                case "MigrationTest":
                {
                    _modules.MigrationsModule.MigrationTest();
                    break;
                }
            }
            callback();
        }
    }
}
