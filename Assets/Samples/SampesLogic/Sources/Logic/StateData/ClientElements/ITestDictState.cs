using SampesLogic.Data;
using VetsEngine.MetaLogic.Core.Collections;

namespace SampesLogic.Logic.StateData.ClientElements
{
    internal interface ITestDictState
    {
        ILogicDictionary<string, string> DictElement { get; }
        ILogicDictionary<string, int> DictElement1 { get; }
        ILogicDictionary<string, long> DictElement2 { get; }
        ILogicDictionary<string, float> DictElement3 { get; }
        ILogicDictionary<string, double> DictElement4 { get; }
        ILogicDictionary<string, bool> DictElement5 { get; }



        //ILogicDictionary<string, SimpleTestData> DictElement6 { get; }
        //ILogicDictionary<string, TestEnum> DictElement7 { get; }
        ILogicDictionary<string, ITestSampleState> DictElement8 { get; }

        ILogicDictionary<int, string> DictElement9 { get; }
        ILogicDictionary<int, ITestSampleState> DictElement10 { get; }
        ILogicDictionary<string, int[]> DictElement11 { get; }
        //ILogicDictionary<string, SimpleTestData[]> DictElements12 { get; }
        //ILogicDictionary<int, ITestElementState[]> DictElements13 { get; }

        ILogicDictionary<TestEnum, int> DictElement12 { get; }
        ILogicDictionary<string, ILogicList<int>> DictElement14 { get; }
        ILogicDictionary<string, ILogicList<ITestSampleState>> DictElement13 { get; }
    }
}
