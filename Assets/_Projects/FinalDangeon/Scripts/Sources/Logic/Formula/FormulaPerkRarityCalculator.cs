using System.Linq;
using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;
using UnityEngine;

namespace MetaLogic.Logic.Formula
{
    class FormulaPerkRarityCalculator : FormulaCalculator<IFormulaPerkRarity>
    {
        private UnitsAccessor _units;

        public FormulaPerkRarityCalculator(UnitsAccessor units)
        {
            _units = units;
        }

        public override double Calculate(IFormulaPerkRarity formulaData)
        {
            var max = 0;
            foreach (var unitId in _units.ExplorerUnits)
            {
                var (state, unit) = _units.GetUnit(unitId);
                if (state.PerkStars.TryGetValue(formulaData.PerkId, out var maxUnit))
                {
                    max = Mathf.Max(maxUnit, max);
                }
            }
            return max;
        }

        public override FormulaType Id => FormulaType.FormulaPerkRarity;
    }
}
