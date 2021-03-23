using MetaLogic.Contracts;
using MigrationLogic.Client.State;
using MigrationLogic.Client.Static;
using MigrationLogic.Data;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Client
{
    public class ClientLogicCreator : BaseLogicCreator
    {
        public static IClientLogicContext Create(ISerializator serializator, ICommandStorage commandStorage,  IMigrationsExternalAPI api)
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
