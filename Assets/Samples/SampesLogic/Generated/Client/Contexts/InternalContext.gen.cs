using MetaLogic.Contracts;
using SampesLogic.Client.State;
using SampesLogic.Client.Static;
using SampesLogic.Data;
using SampesLogic.Shared;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client
{
    internal class InternalContext : BaseClientContext<Internal_StateData, Internal_StaticData>, IClientLogicContext
    {
        public IStateData State => _state;
        public IStaticData Static => _static;
        public ICommands Commands { get; }
        public ILogicAPI Logic => _additionalLogics;
        public IChangesApplier ChangesApplier => _changeStorage;

        private InternalAccessors _accessors;
        private InternalModules _modules;
        private InternalAdditionalLogics _additionalLogics;

        public InternalContext(ISerializator serializator, ICommandStorage storage, ITestExternalAPI api) : base(serializator, storage)
        {
            _accessors = new InternalAccessors();
            _additionalLogics = new InternalAdditionalLogics(_accessors, _changeStorage, Data, api);
            _modules = new InternalModules(_accessors, _additionalLogics, Data, api);
            Commands = new InternalCommands(_modules, _changeStorage, storage);
        }

        public void InitData(string clientState, string staticData)
        {
            _state = _serializator.Deserialize<Internal_StateData>(clientState);
            _state.InitData(_changeStorage, _accessors);
             _static = _serializator.Deserialize<Internal_StaticData>(staticData);
            _static.PostSerialize();
            _accessors.SetStaticData(_static);
            _accessors.SetStateData(_state);
            _additionalLogics.PostInit();
        }

        public string Save()
        {
            _state.PreSave();
            return _serializator.Serialize(_state);
        }
        public void UpdateServerState(string serverState)
        {
            var data = _serializator.Deserialize<ServerStateData>(serverState);
            _state.UpdateServerState(data);
        }
        public void UpdateServerData(ServerStateData data)
        {
            _state.UpdateServerState(data);
        }
    }
}
