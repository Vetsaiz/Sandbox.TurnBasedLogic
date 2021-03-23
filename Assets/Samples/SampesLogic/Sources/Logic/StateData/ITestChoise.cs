using VetsEngine.MetaLogic.Core.Collections;

namespace SampesLogic.Logic.StateData
{
    public interface ITestChoise : IChoise<ITestChoise>
    {
    }

    public interface ITestChoice1 : ITestChoise
    {
        int TestId { get; }
    }

    public interface ITestChoice2 : ITestChoise
    {
        string TestId2 { get; }
    }
}
