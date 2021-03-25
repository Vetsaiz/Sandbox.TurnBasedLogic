using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactUnsummonExecutor : ImpactExecutor<IImpactAssistUncommon>
    {
        private readonly BattleAccessor _battle;
        private UnitsAccessor _units;
        private ContextLogic _context;
        private ExplorerAccessor _explorer;

        public UnitImpactUnsummonExecutor(ContextLogic context, BattleAccessor battle, UnitsAccessor units, ExplorerAccessor explorer)
        {
            _context = context;
            _units = units;
            _explorer = explorer;
            _battle = battle;
        }

        public override void Execute(IImpactAssistUncommon asset)
        {
            var data = _units.State.Assist;
            if (data == null)
            {
                Logger.Error("Call for missing assists", this);
                return;
            }
            if (_context.BattleMode)
            {
                _battle.State.Data.Allies.Remove(data.Id);
            }
            _units.State.Assist = null;
        }

        public override ImpactType Id => ImpactType.ImpAssistUnsummon;
    }
}
