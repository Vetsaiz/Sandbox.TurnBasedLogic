using SampesLogic.Client.StateEmulate;
using SampesLogic.Client.Static;
using SampesLogic.Data;
using SampesLogic.Shared;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client
{
    internal class EmulateContext : BaseClientContext<Emulate_StateData, Internal_StaticData>, IEmulateLogicContext
    {
        public IEmulateStateData State => _state;
        public ICommands Commands { get; }
        public ILogicAPI Logic => _additionalLogics;

        private InternalAccessors _accessors;
        private InternalAdditionalLogics _additionalLogics;
        private InternalModules _modules;
        public EmulateContext(ITestExternalAPI api) : base(null, null)
        {
            Data.IsEmulate = true;
            _accessors = new InternalAccessors();
            _additionalLogics = new InternalAdditionalLogics(_accessors, _changeStorage, Data, api);
            _modules = new InternalModules(_accessors, _additionalLogics, Data, api);
            Commands = new EmulateCommands(_modules);
            _state = new Emulate_StateData();
        }

        public void InitData(IStateData clientState, IStaticData staticData)
        {
             _state.InitData(clientState, _accessors, _changeStorage);
            _accessors.SetStaticData(staticData);
            //_accessors.SetStateData(_state);
            _additionalLogics.PostInit();
        }
    }
}
