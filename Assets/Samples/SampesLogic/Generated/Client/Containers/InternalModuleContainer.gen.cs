using SampesLogic.Data;
using SampesLogic.Logic.Accessors;
using SampesLogic.Logic.Modules;
using VetsEngine.MetaLogic.Core;

namespace SampesLogic.Client
{
    internal partial class InternalModules
    {
        public readonly TestChangeServerModule TestChangeServerModule;
        public readonly TestChangeStateModule TestChangeStateModule;
        public readonly TestInputArrayModule TestInputArrayModule;
        public readonly TestInputDictModule TestInputDictModule;
        public readonly TestInputElementsModule TestInputElementsModule;
        public readonly TestInputListModule TestInputListModule;
        public readonly TestModule TestModule;

        public InternalModules(InternalAccessors accessors, InternalAdditionalLogics additionalLogics, LogicData data, ITestExternalAPI api)
        {
            TestChangeServerModule = TestChangeServerModule.CreateClient(accessors.TestServerAccessor);
            TestChangeStateModule = TestChangeStateModule.CreateClient(accessors.TestClientAccessor);
            TestInputArrayModule = TestInputArrayModule.CreateClient();
            TestInputDictModule = TestInputDictModule.CreateClient();
            TestInputElementsModule = TestInputElementsModule.CreateClient();
            TestInputListModule = TestInputListModule.CreateClient();
            TestModule = TestModule.CreateClient(accessors.TestAccessor, accessors.TestServerAccessor, accessors.TestClientAccessor, additionalLogics.TestAdditionalLogic);
        }
    }
}

namespace SampesLogic.Logic.Modules
{
    internal partial class TestChangeServerModule
    {
        public static Logic.Modules.TestChangeServerModule CreateClient(TestServerAccessor _accessor)
        {
            return new Logic.Modules.TestChangeServerModule
                {
                    _accessor = _accessor,
                }
                ;
        }
    }

    internal partial class TestChangeStateModule
    {
        public static Logic.Modules.TestChangeStateModule CreateClient(TestClientAccessor _accessor)
        {
            return new Logic.Modules.TestChangeStateModule
                {
                    _accessor = _accessor,
                }
                ;
        }
    }

    internal partial class TestInputArrayModule
    {
        public static Logic.Modules.TestInputArrayModule CreateClient()
        {
            return new Logic.Modules.TestInputArrayModule
                {
                }
                ;
        }
    }

    internal partial class TestInputDictModule
    {
        public static Logic.Modules.TestInputDictModule CreateClient()
        {
            return new Logic.Modules.TestInputDictModule
                {
                }
                ;
        }
    }

    internal partial class TestInputElementsModule
    {
        public static Logic.Modules.TestInputElementsModule CreateClient()
        {
            return new Logic.Modules.TestInputElementsModule
                {
                }
                ;
        }
    }

    internal partial class TestInputListModule
    {
        public static Logic.Modules.TestInputListModule CreateClient()
        {
            return new Logic.Modules.TestInputListModule
                {
                }
                ;
        }
    }

    internal partial class TestModule
    {
        public static Logic.Modules.TestModule CreateClient(TestAccessor _accessor, TestServerAccessor _serverAccessor, TestClientAccessor _clientAccessor, Logic.AdditionalLogics.TestAdditionalLogic _logic)
        {
            return new Logic.Modules.TestModule
                {
                    _accessor = _accessor,
                    _serverAccessor = _serverAccessor,
                    _clientAccessor = _clientAccessor,
                    _logic = _logic,
                }
                ;
        }
    }
}