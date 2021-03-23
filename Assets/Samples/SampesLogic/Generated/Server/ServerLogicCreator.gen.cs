using MetaLogic.Contracts;
using SampesLogic.Data;
using SampesLogic.Server.State;
using SampesLogic.Server.Static;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server
{
    public class ServerLogicCreator : BaseLogicCreator
    {
        public static IServerLogicContext Create(ISerializator serializator, ITestExternalAPI api)
        {
            return new InternalContext(serializator, api);
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
