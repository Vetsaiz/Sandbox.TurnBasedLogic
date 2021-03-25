using Common.SampleUI;
using MetaTests.Client;
using MetaTests.Client.Core;
using SampesLogic.Client;
using SampesLogic.Server;
using UnityEngine;

namespace SamplesLogic.Client
{
    public class LogicCreateAPI : ILogic
    {
        IClientLogicContext _clientContext;
        SampleExternalAPI _externalApi;
        private IServerLogicContext _serverContext;
        private ConfigData _config;

        public const string _path = "SampleLogic/";

        public bool Progress { get; set; }
        public object[] Context => new object[] { this };

        public LogicCreateAPI()
        {
            _config = ConfigUtility.GetData(_path);
        }

        public void CreateClientContext()
        {
            var serializator = new TestSerializator();
            var command = new TestCommandStorage(serializator);
            _clientContext = ClientLogicCreator.Create(serializator, command, _externalApi);
        }

        public void InitData()
        {
            _clientContext.InitData(_config.defaultClientState, _config.staticData);
            _clientContext.UpdateServerState(_config.defaultServerState);
        }

        public void TestMethod2(string stringField, int intField)
        {
            _clientContext.Commands.TestMethod2(stringField, intField);
        }

        public void Save()
        {
            var state = _clientContext.Save();
            Debug.Log($"currentState = {state}");
        }

        public void CreateServerContext()
        {
            var serializator = new TestSerializator();
            _serverContext = ServerLogicCreator.Create(serializator, _externalApi);
            _serverContext.SetStaticData(_config.staticData);
            _serverContext.SetStateData(_config.defaultClientState, _config.defaultServerState);
        }
        
        public void Dispose()
        {
        }
    }
}