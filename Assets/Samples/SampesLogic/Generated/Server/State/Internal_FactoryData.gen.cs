using System;
using SampesLogic.Data;
using SampesLogic.Logic.StateData;
using SampesLogic.Logic.StateData.ClientElements;
using SampesLogic.Logic.StateData.ServerElements;

namespace SampesLogic.Server.State
{
    internal class Internal_ITestFactory : ITestFactory
    {
        public ITestSubState CreateSubState(Single testFloat,Int64 testDouble,SimpleTestData testData,String[] commands)
        {
            var data = new Internal_ITestSubState();
            data._TestFloat = testFloat;
            data._TestDouble = testDouble;
            data._TestData = testData;
            data._Commands = commands;
            return data;
        }
        public ITestSubState CreateSubState(Single testFloat,Int64 testDouble,SimpleTestData testData)
        {
            var data = new Internal_ITestSubState();
            data._TestFloat = testFloat;
            data._TestDouble = testDouble;
            data._TestData = testData;
            return data;
        }
        public ITestElementsState CreateTestElements()
        {
            var data = new Internal_ITestElementsState();
            return data;
        }
        public ITestArrayState CreateTestArray()
        {
            var data = new Internal_ITestArrayState();
            return data;
        }
        public ITestListState CreateTestList()
        {
            var data = new Internal_ITestListState();
            return data;
        }
        public ITestDictState CreateTestDict()
        {
            var data = new Internal_ITestDictState();
            return data;
        }
        public ITestServerElementsState CreateServerTestElements()
        {
            var data = new Internal_ITestServerElementsState();
            return data;
        }
        public ITestSampleState CreateTestElement(String testString,Int32 testInt)
        {
            var data = new Internal_ITestSampleState();
            data._TestString = testString;
            data._TestInt = testInt;
            return data;
        }
    }
}
