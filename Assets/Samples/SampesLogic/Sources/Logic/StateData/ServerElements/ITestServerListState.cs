using MetaLogic.Core;
using SampesLogic.Data;
using VetsEngine.MetaLogic.Core.Collections;

namespace SampesLogic.Logic.StateData.ServerElements
{
    internal interface ITestServerListState
    {
        [ServerStateField]
        ILogicList<string> ListServerElement { get;}
        [ServerStateField]
        ILogicList<int> ListServerElement1 { get; }
        [ServerStateField]
        ILogicList<long> ListServerElement2 { get; }
        [ServerStateField]
        ILogicList<float> ListServerElement3 { get; }
        [ServerStateField]
        ILogicList<double> ListServerElement4 { get;  }
        [ServerStateField]
        ILogicList<bool> ListServerElement5 { get; }
        [ServerStateField]
        ILogicList<SimpleTestData> ListServerElement6 { get; }
        [ServerStateField]
        ILogicList<TestEnum> ListServerElement7 { get; }
        //[ServerStateField]
        //ILogicList<ITestServerSampleState> ListServerElement8 { get; }
    }
}
