using SampesLogic.Data;

namespace SampesLogic.Logic.StaticData
{
    public interface ITestArrayStatic
    {
        string[] ArrayElements { get; }
        int[] ArrayElements1 { get; }
        SimpleTestData[] ArrayElements2 { get; }
        ITestElementStatic[] ArrayElements3 { get; }
        //Dictionary<string, string>[] ArrayElements4 { get; }
    }
}
