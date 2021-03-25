using VetsEngine.MetaLogic.Core;
using SampesLogic.Data;

namespace SampesLogic.Logic.StateData.ServerElements
{
    internal interface ITestServerArrayState
    {
        [ServerStateField]
        string[] ArrayServerElement { get; set; }
        [ServerStateField]
        int[] ArrayServerElement1 { get; set; }
        [ServerStateField]
        long[] ArrayServerElement2 { get; set; }
        [ServerStateField]
        float[] ArrayServerElement3 { get; set; }
        [ServerStateField]
        double[] ArrayServerElement4 { get; set; }
        [ServerStateField]
        bool[] ArrayServerElement5 { get; set; }
        [ServerStateField]
        SimpleTestData[] ArrayServerElement6 { get; set; }
        [ServerStateField]
        TestEnum[] ArrayServerElement7 { get; set; }
        //[ServerStateField]
        //ITestServerSampleState[] ArrayServerElement8 { get; set; }
    }
}
