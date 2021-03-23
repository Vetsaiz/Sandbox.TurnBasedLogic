using MetaLogic.Contracts;
using MigrationLogic.Data;
using MigrationLogic.Server.State;
using MigrationLogic.Server.Static;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Server
{
    public class ServerLogicCreator : BaseLogicCreator
    {
        public static IServerLogicContext Create(ISerializator serializator, IMigrationsExternalAPI api)
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
