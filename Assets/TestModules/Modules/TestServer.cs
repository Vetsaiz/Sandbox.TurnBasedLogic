using System;
using MetaLogic.Contracts;
using MetaTests.Client.Views;
using UnityEngine;
using UnityEngine.UI;

namespace MetaTests.Client.Core
{
    class TestServer : MonoBehaviour
    {
        [SerializeField]
        private Button _clearBD = null;

        [SerializeField]
        private Button _writeState = null;

        [SerializeField]
        ViewConsole _console = null;

        private TestSerializator _serializator;

        private string _clientState;
        private string _serverState;
        object _server;
        Type _serverType;

        void Awake()
        {
            _writeState.onClick.AddListener(OnWriteState);
            _clearBD.onClick.AddListener(ClearBD);
        }

        public void Init(ClientServerData data, TestSerializator serializator, ConfigData config)
        {
            _serializator = serializator;
            _server = data.server;
            _serverType = data.server.GetType();
            _clientState = config.defaultClientState;
            _serverState = config.defaultServerState;

            TestProtocol.Instance.SetServer(this);
        }

        void OnWriteState()
        {
            Debug.Log(_clientState);
        }

        public (string, string) Execute(string clientState, string serverState, string commands)
        {
            _serverType.GetMethod("SetStateData").Invoke(_server, new object[] {clientState, serverState});
            var result = _serverType.GetMethod("ExecuteCommands").Invoke(_server, new object[]{0, _serializator.Deserialize<CommandData[]>(commands)});
            //var data = (ServerExecuteResult)result;
            //return new ValueTuple<string, string>(_serializator.Serialize(data.ClientState), _serializator.Serialize(data.ServerState));
            return new ValueTuple<string, string>();
        }

        public void SendSyncProfile(string message, Action<string> resultCallback)
        {
            _console.AddConsole($"In: SendSyncProfile. Message = {message}", ViewConsole.ConsoleMessageType.In);
            (_clientState, _serverState) = Execute(_clientState, _serverState, message);
            _console.AddConsole($"Out: SendSyncProfile. Message = {message}", ViewConsole.ConsoleMessageType.Out);
            resultCallback(message);
        }

        public void SendGetProfile(string id, Action<string, string> resultCallback)
        {
            _console.AddConsole($"In: SendGetProfile. Message = {id}", ViewConsole.ConsoleMessageType.In);
            _console.AddConsole($"Out: SendGetProfile. Profile = {_clientState}", ViewConsole.ConsoleMessageType.Out);
            resultCallback(_clientState, _serverState);
        }

        private void ClearConsole()
        {
            _console.Clear();
        }

        private void ClearBD()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}