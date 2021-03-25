using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactUnitShardExecutor : ImpactExecutor<IImpactUnitShard>
    {
        private UnitsAccessor _accessor;
        private FormulaLogic _logic;

        public ImpactUnitShardExecutor(UnitsAccessor accessor, FormulaLogic logic)
        {
            _accessor = accessor;
            _logic = logic;
        }

        public override void Execute(IImpactUnitShard data)
        {
            var value = (int) _logic.Calculate(data.Shards);
            _accessor.AddUnitShard(data.UnitId, value);
            LogicLog.AddUnitShard(data.UnitId, value);
        }

        public override ImpactType Id => ImpactType.ImpUnitShard;
    }
}
