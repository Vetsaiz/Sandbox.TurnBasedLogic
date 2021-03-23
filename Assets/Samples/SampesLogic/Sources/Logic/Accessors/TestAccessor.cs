using MetaLogic.Core;
using SampesLogic.Data;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class TestAccessor
    {
        public ITestComplexState State { get; set; }
        public ITestFactory Factory { get; set; }
        public ITestStatic Static { get; set; }

        public void CreateElements()
        {

        }

        public void SetCommand(int x)
        {
            State.TestData.X = x;
        }

        public ITestSubState GetSubState()
        {
            return null;
        }

        [Query]
        public SimpleTestData GetData()
        {
            return  new SimpleTestData();
        }

        [Query]
        public SimpleTestData GetStrData(string testStr)
        {
            return new SimpleTestData();
        }

        [Query]
        public int TestInt => Static.Element.TestInt;
    }
}
