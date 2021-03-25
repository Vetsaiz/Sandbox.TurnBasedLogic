using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaShardsCalculator : FormulaCalculator<IFormulaShards>
    {
        private readonly UnitsAccessor _units;

        public FormulaShardsCalculator(UnitsAccessor units)
        {
            _units = units;
        }

        public override double Calculate(IFormulaShards formulaData)
        {
            var data = _units.State.Units.FirstOrDefault(x => x.Id == formulaData.UnitId);
            if (data == null)
            {
                return 0;
            }
            if (!formulaData.Full)
            {
                return data.Shards;
            }
            var shards = data.Shards;
            for (var i = 1; i <= data.Stars; i++)
            {
                shards += _units.GetShardsForUpgrage(formulaData.UnitId, i);
            }
            return shards;
        }

        public override FormulaType Id => FormulaType.FormulaShards;
    }
}
