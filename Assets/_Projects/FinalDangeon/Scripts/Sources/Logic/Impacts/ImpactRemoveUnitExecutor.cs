using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactUnitRemoveExecutor : ImpactExecutor<IImpactUnitRemove>
    {
        private UnitsAccessor _units;
        private ExplorerAccessor _explorer;

        public ImpactUnitRemoveExecutor(UnitsAccessor units, ExplorerAccessor explorer)
        {
            _units = units;
            _explorer = explorer;
        }

        public override void Execute(IImpactUnitRemove data)
        {
            if (_units.TryGetUnit(data.UnitId, false, out var unit))
            {
                unit.ExplorerPosition = -1;
                _units.State.Units.Remove(unit);
                _units.State.LastTeam.Remove(data.UnitId);
                _units.UpdateLastTeamSlots();
            }
        }
    
        public override ImpactType Id => ImpactType.ImpUnitRemove;
    }
}
