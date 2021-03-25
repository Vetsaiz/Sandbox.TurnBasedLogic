using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    internal class ImpactFinishBattleExecutor : ImpactExecutor<IImpactFinishBattle>
    {
        private readonly BattleAccessor _battleAccessor;

        public ImpactFinishBattleExecutor(BattleAccessor accessor) {
            _battleAccessor = accessor;
        }

        public override void Execute(IImpactFinishBattle data)
        {
            if (_battleAccessor.State.Data == null)
            {
                throw new Exception("No battle");
            }
            if (data.IsVictory)
            {
                _battleAccessor.State.Data.Status = BattleStatus.Win;
            }
            else
            {
                _battleAccessor.State.Data.Status = BattleStatus.Lose;
            }

        }

        public override ImpactType Id => ImpactType.ImpFinishBattle;
    }
}
