using VetsEngine.MetaLogic.Core;
using SampesLogic.Data;


namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestInputElementsModule
    {
        [Command]
        public void InputElementTest1(string arg)
        {
            Logger.Trace(() => $"args: {arg}");
        }

        [Command]
        public void InputElementTest2(int arg)
        {
            Logger.Trace(() => $"args: {arg}");
        }

        [Command]
        public void InputElementTest3(bool arg)
        {
            Logger.Trace(() => $"args: {arg}");
        }

        [Command]
        public void InputElementTest4(long arg)
        {
            Logger.Trace(() => $"args: {arg}");
        }

        [Command]
        public void InputElementTest5(float arg)
        {
            Logger.Trace(() => $"args: {arg}");
        }

        [Command]
        public void InputElementTest6(double arg)
        {
            Logger.Trace(() => $"args: {arg}");
        }

        [Command]
        public void InputElementTest7(TestEnum arg)
        {
            Logger.Trace(() => $"args: {arg}");
        }
    }
}