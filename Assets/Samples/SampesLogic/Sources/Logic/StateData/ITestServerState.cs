using MetaLogic.Core;
using SampesLogic.Logic.StateData.ServerElements;

namespace SampesLogic.Logic.StateData
{
    [StateData]
    internal interface ITestServerState
    {
        //[ServerStateField]
        //ITestElementsState TestServerInternal { get; set; }

        ITestServerElementsState TestServerElements { get; set; }
        //ITestServerDictState TestServerDict { get; set; }
        //ITestServerListState TestServerList { get; set; }
        ITestServerArrayState TestServerArray { get; set; }
    }
}
