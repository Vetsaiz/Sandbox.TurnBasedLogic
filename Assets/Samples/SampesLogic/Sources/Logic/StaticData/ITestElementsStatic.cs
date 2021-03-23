using SampesLogic.Data;

namespace SampesLogic.Logic.StaticData
{
    public interface ITestElementsStatic
    {
        string Element { get; }
        int Element1 { get; }
        long Element2 { get; }
        float Element3 { get; }
        double Element4 { get; }
        bool Element5 { get; }
        SimpleTestData Element6 { get; }
        ComplexTestData Element7 { get; }
        ITestElementStatic Element8 { get; }
    }
}
