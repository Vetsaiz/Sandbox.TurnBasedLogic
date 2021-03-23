using System;

namespace MetaTests.Client.Core
{
    class TestProtocol
    {
        private static TestProtocol _instance;
        private TestServer _server;

        public static TestProtocol Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance =new TestProtocol();
                return _instance;
            }
        }

        public void SetServer(TestServer server)
        {
            _server = server;
        }

        public void SendSyncProfile(string message, Action<string> resultCallback)
        {
            _server.SendSyncProfile(message, resultCallback);
        }

        public void SendGetProfile(string id, Action<string, string> resultCallback)
        {
            _server.SendGetProfile(id, resultCallback);
        }
    }
}
