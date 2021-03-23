using MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;

namespace SampesLogic.Logic.StateData.ServerElements
{
    internal interface ITestServerDictState
    {
        [ServerStateField]
        ILogicDictionary<string, string> DictServerElement { get; }
        [ServerStateField]
        ILogicDictionary<string, int> DictServerElement1 { get; }
        [ServerStateField]
        ILogicDictionary<string, long> DictServerElement2 { get; }
        [ServerStateField]
        ILogicDictionary<string, float> DictServerElement3 { get; }
        [ServerStateField]
        ILogicDictionary<string, double> DictServerElement4 { get; }
        [ServerStateField]
        ILogicDictionary<string, bool> DictServerElement5 { get; }
        //ILogicDictionary<string, SimpleTestData> DictServerElement6 { get; }
        //[ServerStateField]
        //ILogicDictionary<string, TestEnum> DictServerElement7 { get; }
        //[ServerStateField]
        //ILogicDictionary<string, ITestServerSampleState> DictServerElement8 { get; }

        [ServerStateField]
        ILogicDictionary<int, string> DictServerElement9 { get; }
        //[ServerStateField]
        //ILogicDictionary<int, ITestServerSampleState> DictServerElement10 { get; }
        [ServerStateField]
        ILogicDictionary<string, int[]> DictServerElement11 { get; }
        //ILogicDictionary<string, SimpleTestData[]> DictServerElements12 { get; }
        //ILogicDictionary<int, ITestElementState[]> DictServerElements13 { get; }
    }
}
