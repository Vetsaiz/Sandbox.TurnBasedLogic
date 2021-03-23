using UnityEngine;
using UnityEngine.UI;

namespace MetaTests.Client.Views
{
    public class ViewCommands
    {
        [SerializeField]
        private Button _testCommand1 = null;

        [SerializeField]
        private Button _testCommand2 = null;

        object _commands;

        void Awake()
        {
            _testCommand1.onClick.AddListener(TestMethod1);
            _testCommand2.onClick.AddListener(TestMethod2);
        }

        public void Init(object commands)
        {
            _commands = commands;
        }

        private void TestMethod1()
        {
            //_commands.TestMethod1();
        }

        private void TestMethod2()
        {
            //_commands.TestMethod2("test", 0);
        }
    }
}
