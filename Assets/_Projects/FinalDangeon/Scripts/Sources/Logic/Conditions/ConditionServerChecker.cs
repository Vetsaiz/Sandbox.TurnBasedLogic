using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class ConditionServerChecker : ConditionChecker<IConditionServer>
    {
        private SettingsAccessor _settings;

        public ConditionServerChecker(SettingsAccessor settings)
        {
            _settings = settings;
        }
        
        public override bool Check(IConditionServer data)
        {
            return data.Servers.Values.Contains(_settings.State.Server);
        }

        public override ConditionType Id => ConditionType.CondPlatform;
    }
}
