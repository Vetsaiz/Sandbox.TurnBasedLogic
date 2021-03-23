using MetaLogic.Contracts;
using SampesLogic.Client.State;
using SampesLogic.Client.Static;
using SampesLogic.Data;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client
{
    public class ClientLogicCreator : BaseLogicCreator
    {
        public static IClientLogicContext Create(ISerializator serializator, ICommandStorage commandStorage,  ITestExternalAPI api)
        {
            return new InternalContext(serializator, commandStorage, api);
        }
        public static string CreateDefaultState(ISerializator serializator)
        {
            return serializator.Serialize(new Internal_StateData());
        }
        public static string CreateDefaultStatic(ISerializator serializator)
        {
            return serializator.Serialize(new Internal_StaticData());
        }
    }
}
