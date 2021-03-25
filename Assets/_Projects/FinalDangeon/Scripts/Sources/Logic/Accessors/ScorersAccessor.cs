using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class ScorersAccessor
    {
        public IScorersState State { get; set; }
        [Query]
        public IScorerStatic Static { get; set; }

        //public FormulaLogic Logic { get;set; }

        //[Query]
        //public int Stamina => State.Values["stamina"];

        //[Query]
        //public IReadOnlyDictionary<int, IScorer> Scorers => Static.Scorers;

        public void Spend(IPrice price, FormulaLogic logic)
        {
            var value = (int)logic.Calculate(price.Value);
            var scorerId = Static.MoneyTypes[price.MoneyType].ScorerId;
            State.Values.TryGetValue(scorerId, out var count);
            if (count < value)
            {
                throw new Exception($"Недостаточно ресурсов type = {price.MoneyType} для покупки ({count} < {value})");
            }
            State.Values[scorerId] = count - value;
        }

        [Query]
        public int StaminaId
        {
            get
            {
                var stamina = Static.Scorers.Values.FirstOrDefault(x => x.Label == HardCodeIds.Stamina);
                if (stamina == null)
                {
                    throw new Exception("");
                }
                return stamina.Id;
            }
        }


        [Query]
        public int ManaId
        {
            get
            {
                var mana = Static.Scorers.Values.FirstOrDefault(x => x.Label == HardCodeIds.Mana);
                if (mana == null)
                {
                    throw new Exception("");
                }
                return mana.Id;
            }
        }

        [Query]
        public IScorer GetScorer(string argKey)
        {
            return Static.Scorers.Values.FirstOrDefault(x=> x.Label == argKey);
        }

    }
}
