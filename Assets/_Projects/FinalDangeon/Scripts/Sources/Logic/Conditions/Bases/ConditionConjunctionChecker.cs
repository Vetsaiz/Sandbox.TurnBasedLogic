using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Restrictions
{
    internal class ConditionConjunctionChecker : ConditionChecker<IConditionConjunction>
    {
        private ConditionController _provider;

        public ConditionConjunctionChecker(ConditionController provider, ConditionType type)
        {
            _provider = provider;
            Id = type;
        }

        public override ConditionType Id { get; }

        public override bool Check(IConditionConjunction data)
        {
            var result = true;
            foreach (var temp in data.RestrictionsAnd.Values)
            {
                result &= _provider.Check(temp);
            }
            return result;
        }
    }
}
