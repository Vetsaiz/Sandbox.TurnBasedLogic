using MetaLogic.Contracts;
using SampesLogic.Data;
using SampesLogic.Logic.AdditionalLogics;
using SampesLogic.Shared;
using VetsEngine.MetaLogic.Core;

namespace SampesLogic.Server
{
    internal partial class InternalAdditionalLogics : ILogicAPI
    {
        public readonly TestAdditionalLogic TestAdditionalLogic;

        public InternalAdditionalLogics(InternalAccessors accessors, IApplyManager storage, LogicData data, ITestExternalAPI api)
        {
            TestAdditionalLogic = TestAdditionalLogic.CreateServer();
        }

        public void PostInit()
        {
        }
    }
}
namespace SampesLogic.Logic.AdditionalLogics
{

    internal partial class TestAdditionalLogic
    {
        public static Logic.AdditionalLogics.TestAdditionalLogic CreateServer()
        {
            return new Logic.AdditionalLogics.TestAdditionalLogic
                {
                }
                ;
        }
    }
}