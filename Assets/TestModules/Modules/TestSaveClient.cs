
using MetaTests.Client.Views;
using UnityEngine;
using UnityEngine.UI;

namespace MetaTests.Client.Core
{
    public class TestSaveClient
    {

        [SerializeField]
        private Button _clearProfile = null;

        [SerializeField]
        ViewCommands _commands = null;

        [SerializeField]
        ViewData _data = null;

        private TestProtocol _protocol;
        private ITestClientLogic _context;
        private TestSerializator _serializator;

        public void Init()
        {
            //_commandStorage = new TestCommandStorage();
            _protocol = TestProtocol.Instance;
            _serializator = new TestSerializator();
            _commands.Init(_data);
            //_context = ClientLogicCreator.Create(_serializator, _commandStorage);
            
            //_synhronize.onClick.AddListener(SendSync);
        }
    }
}
