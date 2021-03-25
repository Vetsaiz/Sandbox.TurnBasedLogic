using System;
using VetsEngine.MetaLogic.Contracts;
using MetaLogic.Data;
using MetaLogic.Logic;
using MetaLogic.Logic.Static;
namespace MetaLogic
{
    public interface IClientLogicContext
    {
        IStateData State { get; }
        IStaticData Static { get; }
        ICommands Commands { get; }
        ILogicAPI Logic {get;}
    }
    public interface IClientLogicFacade
    {
        IClientLogicContext Context { get; }
        IChangesApplier ChangesApplier{ get; }
        void InitData(string clientState, string staticData);
        string Save();
    }
}
