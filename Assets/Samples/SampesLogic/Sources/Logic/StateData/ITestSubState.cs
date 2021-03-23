using SampesLogic.Data;

namespace SampesLogic.Logic.StateData
{
    internal interface ITestSubState
    {
        float TestFloat { get; }
        long TestDouble { get; set; }
        SimpleTestData TestData { get; }
        string[] Commands { set; get; }
    }
}
