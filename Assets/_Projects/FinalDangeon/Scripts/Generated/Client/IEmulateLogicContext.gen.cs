using MetaLogic;
using VetsEngine.MetaLogic.Contracts;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic
{
    public interface IEmulateLogicContext
    {
        IStaticData Static { get; }
        IEmulateStateData State { get; }
        ICommands Commands { get; }
        ILogicAPI Logic {get;}
        void BackState();
    }
}
public interface IEmulateLogicFacade
{
    IEmulateLogicContext Context { get; }
    void InitData(IStateData clientState, IStaticData staticData);
}
