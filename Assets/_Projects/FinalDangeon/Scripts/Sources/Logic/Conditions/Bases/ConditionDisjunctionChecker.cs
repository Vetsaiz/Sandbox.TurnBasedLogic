using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionDisjunctionChecker : ConditionChecker<IConditionDisjunction>
    {
        private ConditionController _provider;

        public ConditionDisjunctionChecker(ConditionController provider, ConditionType type)
        {
            _provider = provider;
            Id = type;
        }

        public override bool Check(IConditionDisjunction data)
        {
            var result = false;
            foreach (var temp in data.RestrictionsOr.Values)
            {
                result |= _provider.Check(temp);
            }
            return result;
        }

        public override ConditionType Id { get; }
    }
}
