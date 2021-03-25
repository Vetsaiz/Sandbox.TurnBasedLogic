using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactWhileExecutor : ImpactExecutor<IImpactWhile>
    {
        private ImpactController _logic;
        private ConditionController _condition;

        public ImpactWhileExecutor(ImpactController logic, ConditionController condition, ImpactType type)
        {
            _condition = condition;
            _logic = logic;
            Id = type;
        }

        public override void Execute(IImpactWhile data)
        {
            while (_condition.Check(data.Condition))
            {
                _logic.ExecuteImpact(data.Impact);
            }
        }

        public override ImpactType Id { get; }
    }
}
