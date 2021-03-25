using SampesLogic.Shared;
using VetsEngine.MetaLogic.Contracts;

namespace SampesLogic.Server
{
    public interface IServerLogicContext :  IBatchCommandProcessor
    {
        IChangesApplier ChangesApplier{ get; }
        void ExecuteCommand(CommandData command);
        IStaticData SetStaticData(string staticData);
        void SetStateData(string clientState, string serverState);
        void PreSave();
        object ServerState { get; }
        object ClientState { get; }
    }
}
