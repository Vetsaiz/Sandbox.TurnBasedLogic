using MetaLogic.Core;
using SampesLogic.Data;
using SampesLogic.Logic.StateData.ClientElements;
using SampesLogic.Logic.StateData.ServerElements;

namespace SampesLogic.Logic.StateData
{
    [StateFactory]
    internal interface ITestFactory
    {
        ITestSubState CreateSubState(float testFloat, long testDouble, SimpleTestData testData, string[] commands);

        ITestSubState CreateSubState(float testFloat, long testDouble, SimpleTestData testData);

        ITestElementsState CreateTestElements();
        ITestArrayState CreateTestArray();
        ITestListState CreateTestList();
        ITestDictState CreateTestDict();

        ITestServerElementsState CreateServerTestElements();

        ITestSampleState CreateTestElement(string testString, int testInt);

        //ITestServerSampleState CreateServerTestElement(string testServerString, int testServerInt);
    }
}
