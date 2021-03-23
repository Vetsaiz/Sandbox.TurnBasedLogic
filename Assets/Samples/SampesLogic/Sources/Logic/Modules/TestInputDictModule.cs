using System.Collections.Generic;
using MetaLogic.Core;
using SampesLogic.Data;

namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestInputDictModule
    {
        [Command]
        public void InputDictTest1(Dictionary<string, string> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputDictTest2(Dictionary<string, int> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputDictTest3(Dictionary<int, string> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputDictTest4(Dictionary<int, int> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputDictTest5(Dictionary<int, SimpleTestData> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputDictTest6(Dictionary<string, SimpleTestData> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputDictTest7(Dictionary<string, ComplexTestData> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputDictTest8(Dictionary<int, ComplexTestData> args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }
    }
}