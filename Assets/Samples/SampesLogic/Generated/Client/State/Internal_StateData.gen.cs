using Pathfinding.Serialization.JsonFx;
using SampesLogic.Shared;
using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.State
{
    internal class Internal_StateData : IStateData
    {
        string DataId = "root";
        ServerStateData _serverData;
        [JsonName(" testClientState")] 
        public Internal_ITestClientState _TestClientState;
        [JsonName(" testComplexState")] 
        public Internal_ITestComplexState _TestComplexState;
        [JsonName(" testServerState")] 
        public Internal_ITestServerState _TestServerState;

        public ITestClientStateClient TestClientState => _TestClientState;
        public ITestComplexStateClient TestComplexState => _TestComplexState;
        public ITestServerStateClient TestServerState => _TestServerState;

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

        public void UpdateServerState(ServerStateData data)
        {
            _serverData = data;
            _TestServerState._TestServerElements.SetServerElement(data.ServerElement);
            _TestServerState._TestServerElements.SetServerElement1(data.ServerElement1);
            _TestServerState._TestServerElements.SetServerElement2(data.ServerElement2);
            _TestServerState._TestServerElements.SetServerElement3(data.ServerElement3);
            _TestServerState._TestServerElements.SetServerElement4(data.ServerElement4);
            _TestServerState._TestServerElements.SetServerElement5(data.ServerElement5);
            _TestServerState._TestServerElements.SetServerElement6(data.ServerElement6);
            _TestServerState._TestServerElements.SetServerElement7(data.ServerElement7);
            _TestServerState._TestServerArray.SetArrayServerElement(data.ArrayServerElement);
            _TestServerState._TestServerArray.SetArrayServerElement1(data.ArrayServerElement1);
            _TestServerState._TestServerArray.SetArrayServerElement2(data.ArrayServerElement2);
            _TestServerState._TestServerArray.SetArrayServerElement3(data.ArrayServerElement3);
            _TestServerState._TestServerArray.SetArrayServerElement4(data.ArrayServerElement4);
            _TestServerState._TestServerArray.SetArrayServerElement5(data.ArrayServerElement5);
            _TestServerState._TestServerArray.SetArrayServerElement6(data.ArrayServerElement6);
            _TestServerState._TestServerArray.SetArrayServerElement7(data.ArrayServerElement7);
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
