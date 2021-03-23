using MetaLogic.Core;
using SampesLogic.Logic.StateData.ClientElements;

namespace SampesLogic.Logic.StateData
{
    [StateData]
    internal interface ITestClientState
    {
        ITestElementsState TestElements { get; set; }
        ITestDictState TestDict { get; set; }
        ITestListState TestList { get; set; }
        ITestArrayState TestArray { get; set; }
    }
}
