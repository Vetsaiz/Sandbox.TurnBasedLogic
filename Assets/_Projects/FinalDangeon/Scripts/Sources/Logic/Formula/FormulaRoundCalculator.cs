using System;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;
using UnityEngine;

namespace MetaLogic.Logic.Formula
{
    class FormulaRoundCalculator : FormulaCalculator<IFormulaRound>
    {
        private FormulaController _logic;

        public FormulaRoundCalculator(FormulaController logic)
        {
            _logic = logic;
        }

        public override double Calculate(IFormulaRound formulaData)
        {
            var calculate = _logic.Calculate(formulaData.Value);

            if (formulaData.FractionDigits < 0)
            {
                var s = (int)(Mathf.Pow(10, - formulaData.FractionDigits));
                var t = ((int)calculate / s) * s;
                return t;
            }
            switch (formulaData.DigitType)
            {
                case DigitType.Normal:
                {
                    var value = Math.Round(calculate, formulaData.FractionDigits, MidpointRounding.AwayFromZero);
                    return value;
                }
                case DigitType.More:
                {
                    if (calculate == 0)
                    {
                        return 0;
                    }

                    if (formulaData.FractionDigits == 0)
                    {
                        var digit = calculate / Mathf.Abs((float) calculate);
                        if (digit > 0)
                        {
                            return (int) (calculate - 0.00001) + digit;
                        }
                        else
                        {
                                return (int) (calculate + 0.00001);
                        }
                    }
                    return Math.Round(calculate, formulaData.FractionDigits, MidpointRounding.AwayFromZero);
                }
                case DigitType.Less:
                {
                    var x = Mathf.Pow(10, formulaData.FractionDigits);
                    var value = ((int)(calculate * x)) / x;
                    return value;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override FormulaType Id => FormulaType.FormulaRound;
    }
}
