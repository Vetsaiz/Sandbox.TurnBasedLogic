using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionBaseChecker : ConditionChecker<IConditionBase> {
        private ConditionController _logic;

        public ConditionBaseChecker(ConditionController logic, ConditionType type) {
            _logic = logic;
            Id = type;
        }

        public override bool Check(IConditionBase restictionData)
        {
            return _logic.Check(restictionData.Condition);
        }

        public override ConditionType Id { get; }
    }
}
