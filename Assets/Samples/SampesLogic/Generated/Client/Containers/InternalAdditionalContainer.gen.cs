using MetaLogic.Contracts;
using SampesLogic.Data;
using SampesLogic.Logic.AdditionalLogics;
using SampesLogic.Shared;
using VetsEngine.MetaLogic.Core;

namespace SampesLogic.Client
{
    internal partial class InternalAdditionalLogics : ILogicAPI
    {
        public readonly TestAdditionalLogic TestAdditionalLogic;

        public InternalAdditionalLogics(InternalAccessors accessors, IApplyManager storage, LogicData data, ITestExternalAPI api)
        {
            TestAdditionalLogic = TestAdditionalLogic.CreateClient();
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
        public static Logic.AdditionalLogics.TestAdditionalLogic CreateClient()
        {
            return new Logic.AdditionalLogics.TestAdditionalLogic
                {
                }
                ;
        }
    }
}