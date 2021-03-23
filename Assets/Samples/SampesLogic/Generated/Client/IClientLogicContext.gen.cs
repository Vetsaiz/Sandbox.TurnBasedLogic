using MetaLogic.Contracts;
using SampesLogic.Shared;

namespace SampesLogic.Client
{
    public interface IClientLogicContext
    {
        IChangesApplier ChangesApplier{ get; }
        IStateData State { get; }
         IStaticData Static { get; }
        ICommands Commands { get; }
        void InitData(string clientState, string staticData);
        ILogicAPI Logic {get;}
        string Save();
        void UpdateServerState(string serverState);
        void UpdateServerData(ServerStateData data);
    }
}
