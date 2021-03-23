using SampesLogic.Client.State;
using SampesLogic.Client.Static;
using SampesLogic.Logic.Accessors;
using SampesLogic.Shared;

namespace SampesLogic.Client
{
    internal partial class InternalAccessors
    {
        public readonly Internal_ITestFactory Factory;
        public readonly TestAccessor TestAccessor;
        public readonly TestClientAccessor TestClientAccessor;
        public readonly TestServerAccessor TestServerAccessor;
        public InternalAccessors()
        {
            Factory = new Internal_ITestFactory();
            TestAccessor = new TestAccessor();
            TestClientAccessor = new TestClientAccessor();
            TestServerAccessor = new TestServerAccessor();
        }

        public void SetStateData(Internal_StateData stateData)
        {
            TestAccessor.State = stateData._TestComplexState;
            TestClientAccessor.State = stateData._TestClientState;
            TestServerAccessor.State = stateData._TestServerState;
        }
        public void SetStaticData(IStaticData staticData)
        {
            TestAccessor.Static = staticData.TestStatic;
            TestClientAccessor.Static = staticData.TestStructuresStatic;
            TestServerAccessor.Static = staticData.TestStructuresStatic;
            TestAccessor.Factory = Factory;
            TestClientAccessor.Factory = Factory;
            TestServerAccessor.Factory = Factory;
        }
        public void SetData(Internal_StateData stateData, Internal_StaticData staticData)
        {
            SetStaticData(staticData);
            SetStateData(stateData);
        }
    }
}
