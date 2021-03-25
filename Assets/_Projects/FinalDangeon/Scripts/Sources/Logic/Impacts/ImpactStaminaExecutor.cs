using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactStaminaExecutor : ImpactExecutor<IImpactChangeStamina>
    {
        private readonly ExplorerAccessor _explorer;
        private readonly ScorersAccessor _scorers;
        private readonly FormulaLogic _logic;

        public ImpactStaminaExecutor(FormulaLogic logic, ExplorerAccessor explorer, ScorersAccessor scorers)
        {
            _logic = logic;
            _scorers = scorers;
            _explorer = explorer;
        }

        public override void Execute(IImpactChangeStamina data)
        {
            if (!_explorer.State.IsRun)
            {
                throw new Exception("Explore not running");
            }
            var value = (int)_logic.Calculate(data.Value);
            var staminaId = _scorers.StaminaId;
            _explorer.SpendScorer(staminaId, -value);
        }

        public override ImpactType Id => ImpactType.ImpChangeStamina;
    }
}
