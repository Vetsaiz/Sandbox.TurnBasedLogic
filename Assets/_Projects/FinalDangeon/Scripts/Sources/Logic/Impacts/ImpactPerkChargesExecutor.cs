using System;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactPerkChargesExecutor : ImpactExecutor<IImpactChangePerkCharges>
    {
        private readonly UnitsAccessor _units;
        private readonly FormulaLogic _logic;

        public ImpactPerkChargesExecutor(FormulaLogic logic, UnitsAccessor units)
        {
            _logic = logic;
            _units = units;
        }

        public override void Execute(IImpactChangePerkCharges data)
        {
            var value = (int)_logic.Calculate(data.Value);
            var unitData = _units.ExplorerUnits
                .Select(x => {
                    var (unit, _) = _units.GetUnit(x);
                    return unit;
                })
                .FirstOrDefault(x => {
                    x.PerkCharges.TryGetValue(data.PerkId, out value);
                    return value > 0;
                });
            if (unitData == null)
            {
                throw new Exception($"Закончились заряды перка");
            }
            unitData.PerkCharges[data.PerkId] -= 1;
            LogicLog.ChangePerkCharge(data.PerkId, value);
        }

        public override ImpactType Id => ImpactType.ImpPerkCharges;
    }
}
