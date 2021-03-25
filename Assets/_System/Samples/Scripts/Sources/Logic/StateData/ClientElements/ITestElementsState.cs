using SampesLogic.Data;

namespace SampesLogic.Logic.StateData.ClientElements
{
    internal interface ITestElementsState
    {
        string Element { get; set; }
        int Element1 { get; set; }
        long Element2 { get; set; }
        float Element3 { get; set; }
        double Element4 { get; set; }
        bool Element5 { get; set; }
        SimpleTestData Element6 { get; set; }
        TestEnum Element7 { get; set; }
        ITestSampleState Element8 { get; set; }
    }
}
