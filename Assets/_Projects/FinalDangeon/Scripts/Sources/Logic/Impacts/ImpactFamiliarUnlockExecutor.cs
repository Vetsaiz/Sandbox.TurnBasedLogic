using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactFamiliarUnlockExecutor : ImpactExecutor<IImpactFamiliarUnlock>
    {
        private UnitsAccessor _logic;

        public ImpactFamiliarUnlockExecutor(UnitsAccessor logic)
        {
            _logic = logic;
        }

        public override void Execute(IImpactFamiliarUnlock data)
        {
            if (!_logic.TryGetUnit(data.UnitId, true, out var unit))
            {
                return;
            }
            LogicLog.UnlockFamiliar(data.UnitId);
            unit.FamiliarUnlock = true;
        }

        public override ImpactType Id => ImpactType.ImpFamiliarUnlock;
    }
}
