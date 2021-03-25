using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Formula;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Formula;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class FormulaLogic : IFormulaLogic
    {
        public ContextLogic _contextLogic;

        public ScorersAccessor _scorers;
        public UnitsAccessor _units;
        public BattleAccessor _battle;
        public ExplorerAccessor _explorer;
        public LogicData _data;
        public PlayerAccessor _player;
        public SettingsAccessor _settings;

        public ConditionController _controller;
        public FormulaController _formula;

        public ScorersLogic _scorerLogic;

        private Dictionary<FormulaType, Func<IFormula, double>> _calculators = new Dictionary<FormulaType, Func<IFormula, double>>();

        [ClientAPI]
        public IFormulaLogic GetStateFormula()
        {
            return this;
        }

        public double Calculate(IFormula data)
        {
            return _formula.Calculate(data);
        }

        [ClientAPI]
        public double Calculate(IFormula data, int unit)
        {
            if (_contextLogic.BattleMode && !_battle.LiveAllies.Contains(unit) && !_battle.LiveEnemies.Contains(unit))
            {
                var enemy = _battle.LiveEnemies.FirstOrDefault(x => _battle.State.Data.Enemies[x].StaticId == unit);
                if (enemy == -1)
                {
                    Logger.Error($"no found unit id = {unit}", this);
                    return 1;
                }
                unit = enemy;
            }
            if (!_contextLogic.BattleMode && !_units.TryGetUnit(unit, true, out var _))
            {
                Logger.Error($"no found unit id = {unit}", this);
                return 1;
            }

            _contextLogic.SetContextFormula(unit);
            var value = _formula.Calculate(data);
            _contextLogic.SetContextFormula(null);
            return value;
        }

        [ClientAPI]
        public IFormulaLogic CreateClientFormula()
        {
            return new FormulaLogic
            {
                _battle = _battle,
                _units = _units,
                _explorer = _explorer,
                _scorers = _scorers,
                _calculators = _calculators.ToDictionary(x=> x.Key, x=> x.Value)
            };
        }

        public void RegisterCalculator<T>(IFormulaCalculator<T> checker) where T : IFormula
        {
            _formula.RegisterCalculator(checker);
        }

        [PostInit]
        public void RegisterCalculators()
        {
            RegisterCalculator(new FormulaFloatCalculator());
            RegisterCalculator(new FormulaBaseCalculator(_formula));
            RegisterCalculator(new FormulaMultCalculator(_formula));
            RegisterCalculator(new FormulaSumCalculator(_formula));
            RegisterCalculator(new FormulaPowCalculator(_formula));
            RegisterCalculator(new FormulaMinCalculator(_formula));
            RegisterCalculator(new FormulaMaxCalculator(_formula));
            RegisterCalculator(new FormulaModObjectsCalculator(_formula));
            RegisterCalculator(new FormulaDiffCalculator(_formula));
            RegisterCalculator(new FormulaRandCalculator(_formula, _data));
            RegisterCalculator(new FormulaUtimeCalculator());
            RegisterCalculator(new FormulaDivCalculator(_formula));
            RegisterCalculator(new FormulaRoundCalculator(_formula));
            RegisterCalculator(new FormulaConstantCalculator(this, _scorers));
            RegisterCalculator(new FormulaScorerCalculator(_scorerLogic));
            RegisterCalculator(new FormulaLocaleCalculator(_settings));
            RegisterCalculator(new FormulaUnitParamCalculator(_formula, _contextLogic, _battle, _units, _player));
            RegisterCalculator(new FormulaModCalculator(_formula, _contextLogic, _battle, _explorer));
            RegisterCalculator(new FormulaPerkRarityCalculator(_units));
            RegisterCalculator(new FormulaIfCalculator(_formula, _controller));
            RegisterCalculator(new FormulaBuffCalculator(_contextLogic));
            RegisterCalculator(new FormulaShardsCalculator(_units));
        }
    }
}
