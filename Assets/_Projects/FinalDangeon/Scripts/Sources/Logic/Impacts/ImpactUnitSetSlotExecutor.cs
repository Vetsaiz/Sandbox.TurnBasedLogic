using System.Collections.Generic;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactUnitSetExecutor : ImpactExecutor<IImpactUnitSetSlot>
    {
        private UnitsAccessor _accessor;
        private FormulaController _formula;


        public ImpactUnitSetExecutor(UnitsAccessor accessor, FormulaController formula)
        {
            _formula = formula;
            _accessor = accessor;
        }

        public override void Execute(IImpactUnitSetSlot impactData)
        {
            if (_accessor.TryGetUnit(impactData.UnitId, false, out var data))
            {
                if (data.ExplorerPosition == impactData.SlotId)
                {
                    return;
                }

                if (impactData.SlotId < 0)
                {
                    _accessor.SetUnitReserve(impactData.UnitId, false);
                    return;
                }
                var unit = _accessor.State.Units.FirstOrDefault(x => x.ExplorerPosition == impactData.SlotId);
                if (unit == null)
                {
                    data.ExplorerPosition = impactData.SlotId;
                }
                else
                {
                    if (impactData.Replace)
                    {
                        _accessor.SetUnitReserve(unit.Id, false);
                        data.ExplorerPosition = impactData.SlotId;
                    }
                    else
                    {
                        var slots = new List<int> {1,2,3};
                        foreach (var temp in _accessor.State.Units)
                        {
                            slots.Remove(temp.ExplorerPosition);
                        }
                        if (slots.Count > 0)
                        {
                            data.ExplorerPosition = slots.First();
                        }
                    }
                }
            }
            else
            {
            
            }
        }

        public override ImpactType Id => ImpactType.ImpUnitSetSlot;
    }
}
