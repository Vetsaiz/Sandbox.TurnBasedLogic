using VetsEngine.MetaLogic.Core;

namespace SampesLogic.Logic.StaticData
{
    [StaticData]
    public interface ITestStructuresStatic
    {
        ITestElementsStatic Elements { get; }
        ITestDictStatic DictElements { get; }
        ITestArrayStatic ArrayElements { get; }
    }
}
