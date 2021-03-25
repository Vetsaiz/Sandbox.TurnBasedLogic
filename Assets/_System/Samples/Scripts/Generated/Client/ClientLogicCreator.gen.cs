using SampesLogic.Data;
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;

namespace SampesLogic.Client
{
    public class ClientLogicCreator : BaseLogicCreator
    {
        public static IClientLogicContext Create(ISerializator serializator, ICommandStorage commandStorage,  ITestExternalAPI api)
        {
            return null;
            //return new InternalContext(serializator, commandStorage, api);
        }
        public static string CreateDefaultState(ISerializator serializator)
        {
            return null;
            //return serializator.Serialize(new Internal_StateData());
        }
        public static string CreateDefaultStatic(ISerializator serializator)
        {
            return null;
            //return serializator.Serialize(new Internal_StaticData());
        }
    }
}
