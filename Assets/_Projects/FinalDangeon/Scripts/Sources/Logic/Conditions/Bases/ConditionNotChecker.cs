using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionNegationChecker : ConditionChecker<IConditionNegation>
    {
        private ConditionController _provider;

        public ConditionNegationChecker(ConditionController provider, ConditionType type)
        {
            _provider = provider;
            Id = type;
        }

        public override bool Check(IConditionNegation data)
        {
            return !_provider.Check(data.ConditionNot);
        }

        public override ConditionType Id { get; }
    }
}
