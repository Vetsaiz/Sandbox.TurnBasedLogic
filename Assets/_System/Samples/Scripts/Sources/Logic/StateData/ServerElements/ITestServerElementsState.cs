using VetsEngine.MetaLogic.Core;
using SampesLogic.Data;

namespace SampesLogic.Logic.StateData.ServerElements
{
    internal interface ITestServerElementsState
    {
        [ServerStateField]
        string ServerElement { get; set; }
        [ServerStateField]
        int ServerElement1 { get; set; }
        [ServerStateField]
        long ServerElement2 { get; set; }
        [ServerStateField]
        float ServerElement3 { get; set; }
        [ServerStateField]
        double ServerElement4 { get; set; }
        [ServerStateField]
        bool ServerElement5 { get; set; }
        [ServerStateField]
        SimpleTestData ServerElement6 { get; set; }
        [ServerStateField]
        TestEnum ServerElement7 { get; set; }
        //[ServerStateField]
        //ITestServerSampleState ServerElement8 { get; set; }
    }
}
