using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    internal class ImpactAttackMobExecutor : ImpactExecutor<IImpactMobAttack>
    {
        private readonly BattleLogic _battlelogic;
        private readonly ContextLogic _contextLogic;
        private readonly BattleAccessor _battleAccessor;
        private readonly ExplorerAccessor _explorer;

        public ImpactAttackMobExecutor(ContextLogic contextLogic, BattleLogic logic, BattleAccessor accessor, ExplorerAccessor explorer) {
            _battlelogic = logic;
            _contextLogic = contextLogic;
            _battleAccessor = accessor;
            _explorer = explorer;
        }

        public override void Execute(IImpactMobAttack data)
        {
            if (_battleAccessor.State.Data != null)
            {
                throw new Exception("Attempt to start battle 2");
            }
            _contextLogic.ImpactInit = data.ImpactInit;
            _contextLogic.ImpactLose = data.ImpactLose;
            _contextLogic.ImpactWin = data.ImpactWin;
            _battlelogic.GenerateBattleState(data.Mobs, data.UnityObjectId, data.Description);

        }

        public override ImpactType Id => ImpactType.ImpMobsAttack;
    }
}
