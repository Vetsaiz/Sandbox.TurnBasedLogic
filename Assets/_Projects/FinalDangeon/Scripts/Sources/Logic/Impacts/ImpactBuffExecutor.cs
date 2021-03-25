using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactBuffExecutor : ImpactExecutor<IImpactBuff>
    {
        private readonly FormulaLogic _logic;
        private readonly ExplorerAccessor _explorer;

        public ImpactBuffExecutor (FormulaLogic logic, ExplorerAccessor explorer)
        {
            _logic = logic;
            _explorer = explorer;
        }

        public override void Execute(IImpactBuff data)
        {
            _explorer.State.PlayerBuffs[data.BuffId] = (int)_logic.Calculate(data.Value);
        }

        public override ImpactType Id => ImpactType.ImpBuff;
    }
}
