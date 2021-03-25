using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactSummonExecutor : ImpactExecutor<IUnitImpactSummon>
    {
        readonly BattleAccessor _battle;
        readonly BattleLogic _battleLogic;
        readonly ContextLogic _contextLogic;

        public UnitImpactSummonExecutor(ContextLogic contextLogic, BattleAccessor battle, BattleLogic battleLogic)
        {
            _contextLogic = contextLogic;
            _battleLogic = battleLogic;
            _battle = battle;
        }

        public override void Execute(IUnitImpactSummon data)
        {
            //if (!data.Transform)
            //{
            if (_battle.LiveEnemies.Count() < HardCodeIds.MaxBattleSlots)
            {
                var currentPositions = _battle.State.Data.Enemies.Where(x=> x.Value.Status == UnitBattleStatus.Live).Select(x => x.Value.Position).ToArray();

                int position = 0;
                if (data.SlotId != 0 && !currentPositions.Contains(data.SlotId))
                {
                    position = data.SlotId;
                }
                if (position == 0)
                {
                    for (var i = 1; i < HardCodeIds.MaxBattleSlots; i++)
                    {
                        if (!currentPositions.Contains(i))
                        {
                            position = i;
                            break;
                        }
                    }
                    if (position == 0)
                    {
                        return;
                    }
                }
                _battle.State.Data.CurrentId++;
                _battle.State.Data.Enemies[_battle.State.Data.CurrentId] = _battleLogic.CreateBattleMob(data.MobId, position, true);
            }
            

            //}
            //else
            //{
            //    var battleMob = _contextLogic.CurrentTarget;
            //    var mob = _battleLogic.CreateBattleMob(data.MobId, battleMob.Position, true);
            //    //mob.CurrentHp = battleMob.CurrentHp;
            //    foreach (var temp in battleMob.Abilities)
            //    {
            //        mob.Abilities[temp.Key] = temp.Value;
            //    }
            //    _battle.State.Data.Enemies[_contextLogic.CurrentContext.CurrentTarget] = mob;
            //}
        }

        public override ImpactType Id => ImpactType.UnitImpSummon;
    }
}