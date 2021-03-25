using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    internal class ImpactPauseExecutor : ImpactExecutor<IImpactDelay>
    {
        private ApplyChangeLogic _logic;
        private FormulaController _formula;
        private ContextLogic _context;

        public ImpactPauseExecutor(ApplyChangeLogic logic, FormulaController formula, ContextLogic context)
        {
            _context = context;
            _logic = logic;
            _formula = formula;
        }

        public override void Execute(IImpactDelay data)
        {
            if (_context.BattleMode)
            {
                if (_context.TurnType == BattleTurnResultType.ActiveAbility || _context.TurnType == BattleTurnResultType.PassiveAbility)
                {
                    _logic.BatchAbilityInFrame();
                    var frameData = new FrameAbility
                    {
                        FamiliarAnimStart = false,
                        UnityId = null,
                        Time = (float) _formula.Calculate(data.Value)
                    };
                    _logic.Data = frameData;
                }
                else
                {
                    _logic.BatchOtherInFrame();
                    var frameData = new FrameOther
                    {
                        Time = (float)_formula.Calculate(data.Value)
                    };
                    _logic.Other = frameData;
                }
            }
            else
            {
                var delay = (float) _formula.Calculate(data.Value);
                _logic.BatchCutScene(delay);
            }
        }

        public override ImpactType Id => ImpactType.ImpDelay;
    }
}
