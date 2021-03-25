using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Client.Internal.State;
using MetaLogic.Client.Internal.Static;
using MetaLogic.Data;
namespace MetaLogic.Client.Internal.Containers
{
    internal class EmulateContext : /*BaseClientContext<Emulate_StateData, Internal_StaticData, >,*/ IEmulateLogicFacade, IEmulateLogicContext
    {
        //public IEmulateStateData State => _state;
        public IStaticData Static { get; private set; }

        public IEmulateStateData State { get; }
        public ICommands Commands { get; }
        public ILogicAPI Logic => _additionalLogics;
        public IEmulateLogicContext Context => this;

        private InternalAccessors _accessors;
        private InternalAdditionalLogics _additionalLogics;
        private InternalModules _modules;

        public EmulateContext(LogicInitData data, IServerAPI api)/* : base(data, true)*/
        {
            //var factory = new Emulate_IStateFactory(new Internal_IStateFactory(), _changeStorage);
            //_accessors = new InternalAccessors(Data, factory);
            //_additionalLogics = new InternalAdditionalLogics(_accessors, _changeStorage, Data, api);
            //_modules = new InternalModules(_accessors, _additionalLogics, Data, api);
            //Commands = new EmulateCommands(_modules, data);
            //_state = new Emulate_StateData();
        }

        public void InitData(IStateData clientState, IStaticData staticData)
        {
            //Static = _static;
            //_state.InitData(clientState, _accessors, _changeStorage);
            //_accessors.SetStaticData(staticData);
            //_accessors.SetStateData(_state);
            //_additionalLogics.PostInit();
        }

        public void BackState()
        {
            throw new System.NotImplementedException();
        }
    }
}
