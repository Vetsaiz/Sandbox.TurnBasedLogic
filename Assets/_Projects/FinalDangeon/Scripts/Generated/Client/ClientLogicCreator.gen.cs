using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Contracts;
using MetaLogic.Client.Internal.State;
using MetaLogic.Client.Internal.Static;
using MetaLogic.Client.Internal.Containers;
using MetaLogic.Data;
namespace MetaLogic
{
    public class ClientLogicCreator
    {
        public static IClientLogicFacade Create(LogicInitData data, IServerAPI api)
        {
            return new InternalContext(data, api);
        }
        public static IEmulateLogicFacade CreateEmulate(LogicInitData data, IServerAPI api)
        {
            return new EmulateContext(data, api);
        }
        public static string CreateDefaultState(ISerializator serializator)
        {
            return serializator.Serialize(new Internal_StateData());
        }
        public static string CreateDefaultStatic(ISerializator serializator)
        {
            return serializator.Serialize(new Internal_StaticData());
        }
        public static IStaticData GetStaticData(ISerializator serializator, string staticData)
        {
            var data = serializator.Deserialize<Internal_StaticData>(staticData);
            data.PostSerialize();
            return data;
        }
    }
}
