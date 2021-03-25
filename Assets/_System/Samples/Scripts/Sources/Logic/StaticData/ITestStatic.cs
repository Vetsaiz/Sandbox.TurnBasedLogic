using VetsEngine.MetaLogic.Core;

namespace SampesLogic.Logic.StaticData
{
    [StaticData]
    public interface ITestStatic
    {
        ITestSubStatic Element { get; }
    }
}
