using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static.Conditions;

namespace MetaLogic.Logic.Conditions
{
    internal class ConditionZoneChecker : ConditionChecker<IConditionZone>
    {
        private ExplorerAccessor _explorer;

        public ConditionZoneChecker(ExplorerAccessor explorer)
        {
            _explorer = explorer;
        }

        public override bool Check(IConditionZone data)
        {
            return _explorer.Stages[_explorer.CurrentStage].ZoneId == data.ZoneId;
        }

        public override ConditionType Id => ConditionType.CondZone;
    }
}
