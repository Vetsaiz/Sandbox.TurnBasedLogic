using Pathfinding.Serialization.JsonFx;
using SampesLogic.Shared;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Server.State
{
    internal class Internal_StateData 
    {
        string DataId = "root";
        ServerStateData _serverData;
        [JsonName(" testClientState")] 
        public Internal_ITestClientState _TestClientState;
        [JsonName(" testComplexState")] 
        public Internal_ITestComplexState _TestComplexState;
        [JsonName(" testServerState")] 
        public Internal_ITestServerState _TestServerState;

        public Internal_StateData()
        {
            _TestClientState = new Internal_ITestClientState(); 
            _TestComplexState = new Internal_ITestComplexState(); 
            _TestServerState = new Internal_ITestServerState(); 
        }

        public void InitData(ChangeStorage storage, InternalAccessors _accessors)
        {
            _TestClientState.InitData(DataId, storage, _accessors.TestClientAccessor);
            _TestComplexState.InitData(DataId, storage, _accessors.TestAccessor);
            _TestServerState.InitData(DataId, storage, _accessors.TestServerAccessor);
        }
        public void PreSave()
        {
            _TestClientState.PreSave();
            _TestComplexState.PreSave();
            _TestServerState.PreSave();
        }

        public ServerStateData GetServerState()
        {
            if (_serverData == null)
            {
                return null;
            }
            _serverData.ServerElement = _TestServerState._TestServerElements._ServerElement;
            _serverData.ServerElement1 = _TestServerState._TestServerElements._ServerElement1;
            _serverData.ServerElement2 = _TestServerState._TestServerElements._ServerElement2;
            _serverData.ServerElement3 = _TestServerState._TestServerElements._ServerElement3;
            _serverData.ServerElement4 = _TestServerState._TestServerElements._ServerElement4;
            _serverData.ServerElement5 = _TestServerState._TestServerElements._ServerElement5;
            _serverData.ServerElement6 = _TestServerState._TestServerElements._ServerElement6;
            _serverData.ServerElement7 = _TestServerState._TestServerElements._ServerElement7;
            _serverData.ArrayServerElement = _TestServerState._TestServerArray._ArrayServerElement;
            _serverData.ArrayServerElement1 = _TestServerState._TestServerArray._ArrayServerElement1;
            _serverData.ArrayServerElement2 = _TestServerState._TestServerArray._ArrayServerElement2;
            _serverData.ArrayServerElement3 = _TestServerState._TestServerArray._ArrayServerElement3;
            _serverData.ArrayServerElement4 = _TestServerState._TestServerArray._ArrayServerElement4;
            _serverData.ArrayServerElement5 = _TestServerState._TestServerArray._ArrayServerElement5;
            _serverData.ArrayServerElement6 = _TestServerState._TestServerArray._ArrayServerElement6;
            _serverData.ArrayServerElement7 = _TestServerState._TestServerArray._ArrayServerElement7;
            return _serverData;
        }

        public void SetServerState(ServerStateData data)
        {
            _serverData = data;
            _TestServerState._TestServerElements._ServerElement = data.ServerElement;
            _TestServerState._TestServerElements._ServerElement1 = data.ServerElement1;
            _TestServerState._TestServerElements._ServerElement2 = data.ServerElement2;
            _TestServerState._TestServerElements._ServerElement3 = data.ServerElement3;
            _TestServerState._TestServerElements._ServerElement4 = data.ServerElement4;
            _TestServerState._TestServerElements._ServerElement5 = data.ServerElement5;
            _TestServerState._TestServerElements._ServerElement6 = data.ServerElement6;
            _TestServerState._TestServerElements._ServerElement7 = data.ServerElement7;
            _TestServerState._TestServerArray._ArrayServerElement = data.ArrayServerElement;
            _TestServerState._TestServerArray._ArrayServerElement1 = data.ArrayServerElement1;
            _TestServerState._TestServerArray._ArrayServerElement2 = data.ArrayServerElement2;
            _TestServerState._TestServerArray._ArrayServerElement3 = data.ArrayServerElement3;
            _TestServerState._TestServerArray._ArrayServerElement4 = data.ArrayServerElement4;
            _TestServerState._TestServerArray._ArrayServerElement5 = data.ArrayServerElement5;
            _TestServerState._TestServerArray._ArrayServerElement6 = data.ArrayServerElement6;
            _TestServerState._TestServerArray._ArrayServerElement7 = data.ArrayServerElement7;
        }
    }
}
