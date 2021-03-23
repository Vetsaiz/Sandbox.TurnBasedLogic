using MetaLogic.Core;
using SampesLogic.Data;

namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestInputElementsModule
    {
        [Command]
        public void InputElementTest1(string arg)
        {
            Logger.Log($"args: {arg}");
        }

        [Command]
        public void InputElementTest2(int arg)
        {
            Logger.Log($"args: {arg}");
        }

        [Command]
        public void InputElementTest3(bool arg)
        {
            Logger.Log($"args: {arg}");
        }

        [Command]
        public void InputElementTest4(long arg)
        {
            Logger.Log($"args: {arg}");
        }

        [Command]
        public void InputElementTest5(float arg)
        {
            Logger.Log($"args: {arg}");
        }

        [Command]
        public void InputElementTest6(double arg)
        {
            Logger.Log($"args: {arg}");
        }

        [Command]
        public void InputElementTest7(TestEnum arg)
        {
            Logger.Log($"args: {arg}");
        }
    }
}