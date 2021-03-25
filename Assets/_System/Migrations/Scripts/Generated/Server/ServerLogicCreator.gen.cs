using MigrationLogic.Data;
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;

namespace MigrationLogic.Server
{
    public class ServerLogicCreator : BaseLogicCreator
    {
        public static IServerLogicContext Create(ISerializator serializator, IMigrationsExternalAPI api)
        {
            return null;
            //return new InternalContext(serializator, api);
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
