using System.Linq;
using VetsEngine.MetaLogic.Core;
using SampesLogic.Data;


namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestInputArrayModule
    {
        [Command]
        public void InputArrayTest1(int[] args)
        {
            Logger.Trace(() => $"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputArrayTest2(string[] args)
        {
            Logger.Trace(() => $"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputArrayTest3(SimpleTestData[] args)
        {
            Logger.Trace(() => $"args: {string.Join(", ", args.ToList())}");
        }

        [Command]
        public void InputArrayTest4(ComplexTestData[] args)
        {
            Logger.Trace(() => $"args: {string.Join(", ", args.ToList())}");
        }
    }
}