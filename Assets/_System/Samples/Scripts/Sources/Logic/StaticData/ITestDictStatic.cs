using System.Collections.Generic;
using SampesLogic.Data;

namespace SampesLogic.Logic.StaticData
{
    public interface ITestDictStatic
    {
        IReadOnlyDictionary<string, string> DictElements { get; }
        IReadOnlyDictionary<string, int> DictElements1 { get; }
        IReadOnlyDictionary<int, string> DictElements2 { get; }
        IReadOnlyDictionary<int, ITestElementStatic> DictElements3 { get; }
        IReadOnlyDictionary<int, SimpleTestData> DictElements4 { get; }
        //IReadOnlyDictionary<string, int[]> DictElements5 { get; }
        //IReadOnlyDictionary<string, SimpleTestData[]> DictElements6 { get; }
        IReadOnlyDictionary<int, ITestElementStatic[]> DictElements7 { get; }
    }
}
