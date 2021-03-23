using System;
using System.Collections.Generic;
using Common.SampleUI;
using MetaTests.Client.Core;
using UnityEngine;

namespace MetaTests.Client
{
    public class EntryTestLogic : MonoBehaviour, IAdditionalModule
    {
        [SerializeField]
        TestServer _server;

        [SerializeField]
        TestClient _client;

        public TestCommandStorage Storage { get; private set; }

        TestSerializator _serializator;

        public void SetInst(List<Type> types, ILogic logicInst)
        {
            if (!(logicInst is IClientServerLogic logic))
            {
                return;
            }

            _serializator = new TestSerializator();
            Storage = new TestCommandStorage(_serializator);
            
            var path = logic.ConfigPath;
            var clientCreator = types.Find(x => x.Namespace == logic.NamespaceCreator && x.Name == "ClientLogicCreator");
            var serverCreator = types.Find(x => x.Namespace == logic.NamespaceCreator && x.Name == "ServerLogicCreator");
            var data = new ClientServerData
            {
                client = clientCreator.GetMethod("Create").Invoke(null, new [] { _serializator, Storage, logic.ClientExternalApi }),
                server = serverCreator.GetMethod("Create").Invoke(null, new[] { _serializator, logic.ServerExternalApi }),
            };
            var commands = data.client.GetType().GetProperty("Commands").GetValue(data.client);
            var state = data.client.GetType().GetProperty("State").GetValue(data.client);
            var config = ConfigUtility.GetData(path);
            _server.Init(data, _serializator, config);
            _client.Init(data, Storage, _serializator, config);
            logic.SetDependencies(commands, state);
        }
    }

    public class ConfigUtility
    {
        public static ConfigData GetData(string path)
        {
            return new ConfigData
            {
                staticData = Resources.Load<TextAsset>($"{path}static_data").text,
                defaultClientState = Resources.Load<TextAsset>($"{path}default_client_state").text,
                defaultServerState = Resources.Load<TextAsset>($"{path}default_server_state").text,
            };
        }
    }

    public interface IClientServerLogic : ILogic
    {
        string ConfigPath { get; }
        string NamespaceCreator { get; }
        object ClientExternalApi { get; }
        object ServerExternalApi { get; }
        void SetDependencies(object clientCommands, object clientState);
    }
    
    public struct ConfigData
    {
        public string defaultClientState;
        public string staticData;
        public string defaultServerState;
    }

    internal struct ClientServerData
    {
        public object server;
        public object client;
    }
}
