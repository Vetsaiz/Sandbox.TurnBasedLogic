using System.Collections.Generic;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaModCalculator : FormulaCalculator<IFormulaMod>
    {
        private readonly FormulaController _formula;
        private readonly ContextLogic _context;
        private readonly BattleAccessor _battle;
        private readonly ExplorerAccessor _explorer;

        public FormulaModCalculator(FormulaController formula, ContextLogic context, BattleAccessor battle, ExplorerAccessor explorer)
        {
            _context = context;
            _battle = battle;
            _formula = formula;
            _explorer = explorer;
        }

        public override double Calculate(IFormulaMod formulaData)
        {
            if (!_battle.Static.Modifiers.TryGetValue(formulaData.ModId, out var modifier))
            {
                return 0;
            }

            var type = modifier.Type;
            var result = type == ModifierType.Relative ? 1.0 : 0.0;
            if (!_context.BattleMode)
            {
                var buffs = _explorer.State.PlayerBuffs.Select(x=> x.Key);
                return GetBuffResult(buffs, formulaData, type);
            }

            var target = _context.GetMember(formulaData.Owner);
            if (target == null)
            {
                return result;
            }
            return GetBuffResult(target.Buffs.Select(x => x.Key), formulaData, type);
        }


        private double GetBuffResult(IEnumerable<int> buffs, IFormulaMod formulaData, ModifierType type)
        {
            var result = type == ModifierType.Relative ? 1.0 : 0.0;
            foreach (var buffData in buffs)
            {
                var buff = _battle.Static.Buffs[buffData];
                foreach (var mod in buff.Mods ?? new Dictionary<int, IBuffModifier>())
                {
                    if (mod.Value.ModId == formulaData.ModId)
                    {
                        if (type == ModifierType.Relative)
                        {
                            result *= _formula.Calculate(mod.Value.Value);
                        }
                        else
                        {
                            result += _formula.Calculate(mod.Value.Value);
                        }
                    }
                }
            }
            return result;
        }

        public override FormulaType Id => FormulaType.FormulaMod;
    }
}
