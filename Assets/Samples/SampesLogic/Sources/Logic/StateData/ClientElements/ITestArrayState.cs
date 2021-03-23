using SampesLogic.Data;

namespace SampesLogic.Logic.StateData.ClientElements
{
    internal interface ITestArrayState
    {
        string[] ArrayElement { get; set; }
        int[] ArrayElement1 { get; set; }
        long[] ArrayElement2 { get; set; }
        float[] ArrayElement3 { get; set; }
        double[] ArrayElement4 { get; set; }
        bool[] ArrayElement5 { get; set; }
        SimpleTestData[] ArrayElement6 { get; set; }
        TestEnum[] ArrayElement7 { get; set; }
        
        ITestSampleState[] ArrayElement8 { get; }
    }
}
