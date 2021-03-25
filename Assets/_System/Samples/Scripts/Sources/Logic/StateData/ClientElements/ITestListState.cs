using SampesLogic.Data;
using VetsEngine.MetaLogic.Core.Collections;

namespace SampesLogic.Logic.StateData.ClientElements
{
    internal interface ITestListState
    {
        ILogicList<string> ListElement { get;}
        ILogicList<int> ListElement1 { get; }
        ILogicList<long> ListElement2 { get; }
        ILogicList<float> ListElement3 { get; }
        ILogicList<double> ListElement4 { get;  }
        ILogicList<bool> ListElement5 { get; }
        ILogicList<SimpleTestData> ListElement6 { get; }
        ILogicList<TestEnum> ListElement7 { get; }
        ILogicList<ITestSampleState> ListElement8 { get; }
    }
}
