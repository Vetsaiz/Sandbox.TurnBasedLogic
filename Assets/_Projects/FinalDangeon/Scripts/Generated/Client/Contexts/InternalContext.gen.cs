using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic;
using MetaLogic.Client.Internal.State;
using MetaLogic.Client.Internal.Static;
using MetaLogic.Data;

namespace MetaLogic.Client.Internal.Containers
{
    internal class InternalContext : /*BaseClientContext<Internal_StateData, Internal_StaticData>, */IClientLogicFacade, IClientLogicContext
    {
        //public IStateData State => _state;
        //public IStaticData Static => _static;
        //public ICommands Commands { get; }
        //public ILogicAPI Logic => _additionalLogics;
        //public IClientLogicContext Context => this;
        //public IChangesApplier ChangesApplier => _changeStorage;

        //private InternalAccessors _accessors;
        //private InternalModules _modules;
        //private InternalAdditionalLogics _additionalLogics;

        public InternalContext(LogicInitData data, IServerAPI api)
        {
            //    var factory = new Internal_IStateFactory();
            //    _accessors = new InternalAccessors(Data, factory);
            //    _additionalLogics = new InternalAdditionalLogics(_accessors, _changeStorage, Data, api);
            //    _modules = new InternalModules(_accessors, _additionalLogics, Data, api);
            //    Commands = new InternalCommands(_modules, _changeStorage, data);
            //}

            //public void InitData(string clientState, string staticData)
            //{
            //     _static = _serializator.Deserialize<Internal_StaticData>(staticData);
            //    _static.PostSerialize();
            //    _accessors.SetStaticData(_static);
            //    _additionalLogics.PostInit();

            //    _state = _serializator.Deserialize<Internal_StateData>(clientState);
            //    _state.InitData(_changeStorage, _accessors);
            //    _accessors.SetStateData(_state);
            //}

            //public IStaticData GetStaticData(string staticData)
            //{
            //    _static = _serializator.Deserialize<Internal_StaticData>(staticData);
            //    _static.PostSerialize();
            //    return _static;
            //}

            //public string Save()
            //{
            //    _state.PreSave();
            //    return _serializator.Serialize(_state);
            //}
        }

        public IClientLogicContext Context { get; }
        public IChangesApplier ChangesApplier { get; }

        public void InitData(string clientState, string staticData)
        {
            throw new System.NotImplementedException();
        }

        public string Save()
        {
            throw new System.NotImplementedException();
        }

        public IStateData State { get; }
        public IStaticData Static { get; }
        public ICommands Commands { get; }
        public ILogicAPI Logic { get; }
    }
}
