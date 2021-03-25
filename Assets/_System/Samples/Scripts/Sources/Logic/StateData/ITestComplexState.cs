using VetsEngine.MetaLogic.Core;
using SampesLogic.Data;

namespace SampesLogic.Logic.StateData
{
    [StateData]
    internal interface ITestComplexState
    {
        string TestString { get; }
        int TestInt { get; set; }
        ITestSubState SubSet { get; set; }
        SimpleTestData TestData { set; get; }
        //ITestChoise TestChoise { get; set; }
    }
}
