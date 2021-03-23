using MetaLogic.Contracts;
using SampesLogic.Data;
using SampesLogic.Server.State;
using SampesLogic.Server.Static;
using SampesLogic.Shared;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server
{
    internal class InternalContext : BaseServerContext<Internal_StateData, Internal_StaticData, InternalCommands>, IServerLogicContext, IBatchCommandProcessor
    {
        public IChangesApplier ChangesApplier => _changeStorage;
        private InternalAccessors _accessors;
        private InternalModules _modules;
        private InternalAdditionalLogics _additionalLogics;
        public InternalContext(ISerializator serializator, ITestExternalAPI api) : base(serializator)
        {
            _accessors = new InternalAccessors();
            _additionalLogics = new InternalAdditionalLogics(_accessors, _changeStorage, _data, api);
            _modules = new InternalModules(_accessors, _additionalLogics, _data, api);
            _commands = new InternalCommands(_modules);
        }

        public IStaticData SetStaticData(string staticData)
        {
             _static = _serializator.Deserialize<Internal_StaticData>(staticData);
            _static.PostSerialize();
            _accessors.SetStaticData(_static);
            return _static;
        }
        public void SetStateData(string clientState, string serverState)
        {
            _state = _serializator.Deserialize<Internal_StateData>(clientState);
            _state.InitData(_changeStorage, _accessors);
            if (serverState != null)
            {
                _state.SetServerState(_serializator.Deserialize<ServerStateData>(serverState));
            }
            _accessors.SetStateData(_state);
        }
        protected override object GetServerState()
        {
            return _state.GetServerState();
        }
        public override void PreSave()
        {
             _state.PreSave();
        }
    }
}
