using System.Linq;
using MetaLogic.Core;
using SampesLogic.Data;

namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestInputArrayModule
    {
        [Command]
        public void InputArrayTest1(int[] args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputArrayTest2(string[] args)
        {
            Logger.Log($"args: {string.Join(", ", args)}");
        }

        [Command]
        public void InputArrayTest3(SimpleTestData[] args)
        {
            Logger.Log($"args: {string.Join(", ", args.ToList())}");
        }

        [Command]
        public void InputArrayTest4(ComplexTestData[] args)
        {
            Logger.Log($"args: {string.Join(", ", args.ToList())}");
        }
    }
}