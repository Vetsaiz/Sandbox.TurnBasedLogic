using SampesLogic.Logic.StaticData;

namespace SampesLogic.Shared
{
    public interface IStaticData
    {
        ITestStatic TestStatic {get;}
        ITestStructuresStatic TestStructuresStatic {get;}
    }
}
