using SampesLogic.Data;

namespace SamplesLogic.Client
{
    public class SampleExternalAPI : ITestExternalAPI
    {
        public bool TestMethod(string[] currentCommands)
        {
            return true;
        }

    }
}
