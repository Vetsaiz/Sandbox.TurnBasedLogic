using Common.SampleUI;
using MetaTests.Client;
using MetaTests.Client.Core;
using SampesLogic.Client;

namespace SamplesLogic.Client
{
    public class EmulateLogicAPI : ILogic
    {
        IClientLogicContext _clientContext;
        SampleExternalAPI _externalApi;
        private IEmulateLogicContext _emulateContext;
        private ConfigData _config;
        public const string _path = "SampleLogic/";

        public bool Progress { get; set; }
        public object[] Context => new object[] { this };

        public EmulateLogicAPI()
        {
            _config = ConfigUtility.GetData(_path);

            _externalApi = new SampleExternalAPI();
            var serializator = new TestSerializator();
            var command = new TestCommandStorage(serializator);
            _clientContext = ClientLogicCreator.Create(serializator, command, _externalApi);
            _clientContext.InitData(_config.defaultClientState, _config.staticData);
            _clientContext.UpdateServerState(_config.defaultServerState);

            //_emulateContext = ClientLogicCreator.Create(_externalApi);
            _emulateContext.InitData(_clientContext.State, null);
        }

        public void Dispose()
        {
        }
    }
}