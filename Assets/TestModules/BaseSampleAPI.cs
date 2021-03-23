using MetaTests.Client;

namespace Sandbox.Logic
{
    public abstract class BaseLogicAPI: IClientServerLogic
    {
        public abstract string ConfigPath { get; }
        public abstract string NamespaceCreator { get; }
        public abstract object ClientExternalApi { get; }
        public abstract object ServerExternalApi { get; }

        private object _commands;

        public bool Progress { get; set; }
        public object[] Context => new object[] { this, _commands };

        public void SetDependencies(object clientCommands, object clientState)
        {
            _commands = clientCommands;
        }

        public void Dispose()
        {
        }
    }
}
