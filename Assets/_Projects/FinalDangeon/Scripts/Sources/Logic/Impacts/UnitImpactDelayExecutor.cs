using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactDelayExecutor : ImpactExecutor<IImpactDelay>
    {
        private readonly ApplyChangeLogic _logic;
        private readonly FormulaLogic _formula;

        public UnitImpactDelayExecutor(ApplyChangeLogic logic, FormulaLogic formula)
        {
            _logic = logic;
            _formula = formula;
        }

        public override void Execute(IImpactDelay data)
        {
            //_logic.BatchBattle(_formula.Calculate(data.Value));
        }

        public override ImpactType Id => ImpactType.ImpDelay;
    }
}
