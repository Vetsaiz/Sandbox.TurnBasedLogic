using VetsEngine.MetaLogic.Core.Common;

namespace SampesLogic.Client.StateEmulate
{
    internal class Emulate_StateData : IEmulateStateData
    {
        public Emulate_ITestClientState _TestClientState;
        public Emulate_ITestComplexState _TestComplexState;
        public Emulate_ITestServerState _TestServerState;

        public ITestClientStateEmulate TestClientState => _TestClientState;
        public ITestComplexStateEmulate TestComplexState => _TestComplexState;
        public ITestServerStateEmulate TestServerState => _TestServerState;

        public Emulate_StateData()
        {
            _TestClientState = new Emulate_ITestClientState(); 
            _TestComplexState = new Emulate_ITestComplexState(); 
            _TestServerState = new Emulate_ITestServerState(); 
        }

        public void InitData(IStateData data, InternalAccessors _accessors, ChangeStorage storage)
        {
            _TestClientState.InitData(data.TestClientState, _accessors.TestClientAccessor, storage);
            _TestComplexState.InitData(data.TestComplexState, _accessors.TestAccessor, storage);
            _TestServerState.InitData(data.TestServerState, _accessors.TestServerAccessor, storage);
        }
    }
}
