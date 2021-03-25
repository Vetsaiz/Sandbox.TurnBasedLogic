using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionUnitExistChecker : ConditionChecker<IConditionUnit> {
        private UnitsAccessor _units;
        private IFormulaLogic _formula;

        public ConditionUnitExistChecker(UnitsAccessor units, IFormulaLogic formula) {
            _units = units;
            _formula = formula;
        }

        public override bool Check(IConditionUnit data)
        {
            var value = (int)_formula.Calculate(data.RarityValue);
            if (!_units.TryGetUnit(data.UnitId, true, out var unit))
            {
                return data.Operator.Check(0, value);
            }

            if (data.InExplorer && !_units.ExplorerUnits.Contains(unit.Id))
            {
                return false;
            }
            if (data.InActive && unit.ExplorerPosition < 0)
            {
                return false;
            }
            return data.Operator.Check(unit.Stars, value);
        }

        public override ConditionType Id => ConditionType.CondRarityUnit;
    }
}