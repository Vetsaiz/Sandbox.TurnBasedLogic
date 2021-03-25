using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static.Formula;

namespace MetaLogic.Logic.Formula
{
    internal class FormulaBuffCalculator : FormulaCalculator<IFormulaBuff>
    {
        private readonly ContextLogic _context;

        public FormulaBuffCalculator(ContextLogic context)
        {
            _context = context;
        }

        public override double Calculate(IFormulaBuff formulaData)
        {
            var member = _context.GetMember(formulaData.Target);
            if (member.Buffs.TryGetValue(formulaData.BuffId, out var value))
            {
                return value.CountStack;
            }
            return 0;
        }

        public override FormulaType Id => FormulaType.FormulaBuff;
    }
}
