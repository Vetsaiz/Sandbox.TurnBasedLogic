using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactPlayerExpExecutor : ImpactExecutor<IImpactPlayerExp>
    {
        private PlayerAccessor _accessor;
        private ImpactController _logic;
        private FormulaLogic _formula;

        public ImpactPlayerExpExecutor(ImpactController logic, FormulaLogic formula, PlayerAccessor accessor)
        {
            _formula = formula;
            _logic = logic;
            _accessor = accessor;
        }

        public override void Execute(IImpactPlayerExp data)
        {
            var exp = (int)_formula.Calculate(data.Value);
            _accessor.UpgradeLevel(exp);
        }

        public override ImpactType Id => ImpactType.ImpPlayerExp;
    }
}
