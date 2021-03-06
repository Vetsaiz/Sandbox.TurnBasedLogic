using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using SampesLogic.Data;


namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestInputListModule
    {
        [Command]
        public void InputListTest1(List<int> args)
        {
            Logger.Trace(()=>$"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputListTest2(List<string> args)
        {
            Logger.Trace(() => $"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputListTest3(List<SimpleTestData> args)
        {
            Logger.Trace(() => $"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputListTest4(List<ComplexTestData> args)
        {
            Logger.Trace(() => $"args: {string.Join(", ", args)}");
        }
    }
}