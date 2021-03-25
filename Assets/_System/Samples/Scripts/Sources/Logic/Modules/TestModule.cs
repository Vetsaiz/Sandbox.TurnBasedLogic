using VetsEngine.MetaLogic.Core;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.AdditionalLogics;


namespace SampesLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class TestModule
    {
        public TestAccessor _accessor;
        public TestServerAccessor _serverAccessor;
        public TestClientAccessor _clientAccessor;

        public TestAdditionalLogic _logic;
        //public ITestExternalAPI api;


        [Command]
        public void CreateState()
        {
            _accessor.CreateElements();
            _serverAccessor.CreateElements();
            _clientAccessor.CreateElements();
        }

        [Command]
        public void TestMethod1()
        {
            foreach (var temp in _accessor.State.SubSet.Commands)
            {
                Logger.Trace(() => temp);
            }
        }

        [Command]
        public void TestMethod2(string arg1, int arg2)
        {
            foreach (var temp in _accessor.State.SubSet.Commands)
            {
                Logger.Trace(()=>temp);
            }
        }
    }
}