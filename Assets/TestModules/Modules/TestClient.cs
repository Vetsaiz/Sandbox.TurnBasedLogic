using System;
using UnityEngine;
using UnityEngine.UI;

namespace MetaTests.Client.Core
{
    class TestClient : MonoBehaviour
    {
        [SerializeField]
        private InputField _id = null;

        [SerializeField]
        private Button _getProfile = null;

        [SerializeField]
        private Button _synhronize = null;

        [SerializeField]
        private Button _clearClientChanges = null;
        
        private TestProtocol _protocol;
        //private ITestClientLogic _context;
        private TestSerializator _serializator;
        object _context;
        Type _contextType;
        TestCommandStorage _storage;
        private string _staticData;

        public void Init(ClientServerData data, TestCommandStorage storage, TestSerializator serializator, ConfigData config)
        {
            _storage = storage;
            _context = data.client;
            _contextType = _context.GetType();
            _staticData = config.staticData;

            _protocol = TestProtocol.Instance;
            _serializator = serializator;
            _getProfile.onClick.AddListener(SendGetProfile);
            _synhronize.onClick.AddListener(SendSync);
            _clearClientChanges.onClick.AddListener(ClearClientChanges);
            SendGetProfile();
        }

        void ClearClientChanges()
        {
            _storage.ClearBatches();
        }

        #region ClientServer

        private void SendGetProfile()
        {
            _protocol.SendGetProfile(_id.text, (clientState, serverState) =>
            {

                //var state = _context.SetStateData(clientState, serverState);
                _contextType.GetMethod("InitData").Invoke( _context , new object[]{clientState, _staticData});
                //_state = _clientContext.State;
            });
        }


        private void SendSync()
        {
            var str = _storage.GetBatches();
            _protocol.SendSyncProfile(str, (m)=> {});
        }

        #endregion

    }
}
