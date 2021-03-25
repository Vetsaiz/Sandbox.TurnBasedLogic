using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionInteractiveObjectChecker : ConditionChecker<IConditionInteractiveObject> {
        private IFormulaLogic _formula;
        private ExplorerAccessor _explorer;

        public ConditionInteractiveObjectChecker(ExplorerAccessor explorer, IFormulaLogic formula) {
            _explorer = explorer;
            _formula = formula;
        }

        public override bool Check(IConditionInteractiveObject data)
        {
            return _explorer.GetInteractiveData(data.InteractiveId).Availibility == data.Availibility;
        }

        public override ConditionType Id => ConditionType.CondAvailability;
    }
}