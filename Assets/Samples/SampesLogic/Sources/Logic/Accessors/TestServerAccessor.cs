using MetaLogic.Core;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class TestServerAccessor
    {
        public ITestServerState State { get; set; }
        public ITestStructuresStatic Static { get; set; }
        public ITestFactory Factory { get; set; }

        public void CreateElements()
        {
            State.TestServerElements = Factory.CreateServerTestElements();
        }
    }
}
