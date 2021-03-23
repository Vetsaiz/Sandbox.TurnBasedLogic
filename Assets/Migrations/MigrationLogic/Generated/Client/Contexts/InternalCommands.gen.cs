using System;
using MetaLogic.Contracts;
using MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Client
{
    internal class InternalCommands : BaseClientCommands, ICommands
    {
        private InternalModules _modules;

        public InternalCommands(InternalModules modules, ChangeStorage storage, ICommandStorage commandStorage) : base(storage, commandStorage)
        {
            _modules = modules;
        }
        public void MigrationTest()
        {
            PreCommand();
            try
            {
                _modules.MigrationsModule.MigrationTest();
            }
            catch (Exception e)
            {
                Logger.Exception(e);
                return;
            }
            PostCommand("MigrationTest", new object[] {} );
        }
    }
}
