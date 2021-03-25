using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactChangeMoneyExecutor : ImpactExecutor<IImpactChangeMoney>
    {
        private readonly ScorersAccessor _scorers;
        private readonly FormulaLogic _logic;
        private ExplorerAccessor _explorer;

        public ImpactChangeMoneyExecutor(FormulaLogic logic, ScorersAccessor scorers, ExplorerAccessor explorer) {
            _scorers = scorers;
            _logic = logic;
            _explorer = explorer;
        }

        public override void Execute(IImpactChangeMoney data)
        {
            var value = (int)_logic.Calculate(data.Value);
            var data1 = _scorers.Static.MoneyTypes[data.MoneyTypeId];
            var id = _scorers.Static.MoneyTypes[data.MoneyTypeId].ScorerId;
            var dict = _scorers.State.Values;
            dict.TryGetValue(id, out var oldValue);
            var delta = 0;
            switch (data.Operator)
            {
                case OperationType.Add:
                    dict[id] = oldValue + value;
                    delta = value;
                    break;
                case OperationType.Set:
                    delta = value - (int)oldValue;
                    dict[id] = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (delta > 0)
            {
                if (data1.AchievScorerId != 0)
                {
                    if (!dict.ContainsKey(data1.AchievScorerId))
                    {
                        dict[data1.AchievScorerId] = 0;
                    }
                    dict[data1.AchievScorerId] += delta;
                }
            }
            if (dict[id] <= 0)
            {
                dict.Remove(id);
            }
            LogicLog.ChangeMoneyType(data.MoneyTypeId, data.Operator, value);
        }

        public override ImpactType Id => ImpactType.ImpChangeMoney;
    }
}
