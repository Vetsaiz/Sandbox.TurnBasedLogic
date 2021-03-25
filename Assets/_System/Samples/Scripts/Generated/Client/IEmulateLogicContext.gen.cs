using SampesLogic.Shared;

namespace SampesLogic.Client
{
    public interface IEmulateLogicContext
    {
        IEmulateStateData State { get; }
        ICommands Commands { get; }
        void InitData(IStateData clientState, IStaticData staticData);
        ILogicAPI Logic {get;}
        void BackState();
    }
}
