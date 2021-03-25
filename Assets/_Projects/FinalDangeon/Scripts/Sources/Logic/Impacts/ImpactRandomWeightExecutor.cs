using System;
using System.Collections.Generic;
using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactRandomWeightExecutor : ImpactExecutor<IImpactRandomWeight>
    {
        private readonly FormulaLogic _formulaLogic;
        private readonly ImpactController _impactLogic;
        private ConditionController _condition;

        private int _state;
        private SettingsAccessor _settings;

        public ImpactRandomWeightExecutor(FormulaLogic formulaLogic, ConditionController condition, ImpactController impactLogic, SettingsAccessor settings, ImpactType type)
        {
            _condition = condition;
            _formulaLogic = formulaLogic;
            _impactLogic = impactLogic;
            _settings = settings;
            Id = type;
        }

        public override void Execute(IImpactRandomWeight data)
        {
            var dataWeight = new List<(int, IImpact)>();
            foreach (var temp in data.Weights.Values)
            {
                if (!_condition.Check(temp.Impact.Condition))
                {
                    continue;
                }
                dataWeight.Add(((int)_formulaLogic.Calculate(temp.Formula), temp.Impact));
            }
            if (dataWeight.Count == 0)
            {
                return;
            }
            if (dataWeight.Count == 1)
            {
                _impactLogic.ExecuteImpact(dataWeight.FirstOrDefault().Item2);
                return;
            }
            var result = _settings.GetWeightRandom(dataWeight);
            _impactLogic.ExecuteImpact(result.Item2, false);
        }


        int GetNext(int count)
        {
            var random = new Random(_state);
            var val = random.Next(count);
            _state = random.Next(0, 100000);
            return val;
        }

        public override ImpactType Id { get; }
    }
}
