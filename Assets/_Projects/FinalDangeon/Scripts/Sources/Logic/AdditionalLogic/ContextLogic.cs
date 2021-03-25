using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class ContextLogic
    {
        public BattleAccessor _battleAccessor;
        public UnitsAccessor _unitAccessor;

        public IImpact ImpactWin { get; set; }
        public IImpact ImpactLose { get; set; }
        public IImpact ImpactInit { get; set; }

        public bool BattleMode => _battleAccessor.State.Data?.Status == BattleStatus.Running;
        public bool NeedExploreParam { get; set; } = false;

        public BattleTurnResultType TurnType { get; set; }
        public ContextTurnData ContextTurn { get; private set; }
        public int CurrentAbility { get; set; }

        public ContextTargetType? ConditionTarget { get; set; }

        public int? ContextFormula { get; private set; }
        public ContextAbilityData ContextImpact { get; private set; }
        public ContextAbilityData ContextCondition { get; private set; }
        public ContextAbilityData CurrentContext { get; private set; }

        [ClientAPI]
        public ContextAbilityData GetPublicContext()
        {
            return CurrentContext;
        }

        public IMemberBattleData CurrentTarget => _battleAccessor.GetMember(CurrentContext.CurrentTarget);
        public int InternalAbility { get; set; }
        public Dictionary<int, IImpact> MobImpacts { get; } = new Dictionary<int, IImpact>();

        public IMemberBattleData GetMember(TargetType restictionDataTarget)
        {
            switch (restictionDataTarget)
            {
                case TargetType.Owner:
                    return _battleAccessor.GetMember(CurrentContext.OwnerId);
                case TargetType.Target:
                    return _battleAccessor.GetMember(CurrentContext.CurrentTarget);
                default:
                    throw new ArgumentOutOfRangeException(nameof(restictionDataTarget), restictionDataTarget, null);
            }
        }

        public float GetCurrentHp(int unitId)
        {
            if (BattleMode)
            {
                var member = _battleAccessor.GetMember(unitId);
                return member.CurrentHp;
            }
            else
            {
                var unit = _unitAccessor.GetUnit(unitId);
                return unit.data.CurrentHp;
            }
        }


        public IList<int> GetContextList(IList<int> list, ConditionTargetType type)
        {
            var result = new List<int>();
            switch (type)
            {
                case ConditionTargetType.AllTargetsActivateAll:
                    foreach (var unit in list)
                    {
                        result.Add(unit);
                    }
                    break;
                case ConditionTargetType.FirstTargetsActivateAll:
                    if (list.Count == 0)
                    {
                        list = new List<int>();
                    }
                    foreach (var unit in list)
                    {
                        result.Add(unit);
                    }
                    break;
                case ConditionTargetType.AnyTargetActivate:
                    foreach (var unit in list)
                    {
                        result.Add(unit);
                    }
                    break;
                case ConditionTargetType.FirstRandomTargetsActivate:
                    if (list.Count > 0)
                    {
                        var random = new Random().Next(0, list.Count);
                        result.Add(list[random]);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            return result;
        }

        public double GetMaxHp(int unitId, FormulaController formula)
        {
            if (BattleMode)
            {
                var member = _battleAccessor.GetMember(unitId);
                return member.HpMax.Value;
            }
            else
            {
                var unit = _unitAccessor.GetUnit(unitId);
                return _unitAccessor.CalculateMaxHp(unit.data, formula).Value;
            }
        }

        public void SetContextFormula(int? unit)
        {
            ContextFormula = unit;

            if (unit != null)
            {
                CurrentContext = new ContextAbilityData {OwnerId = unit.Value, CurrentTarget = unit.Value, IsEnemy = true};
            }
            else
            {
                CurrentContext = new ContextAbilityData {OwnerId = -1, CurrentTarget = -1, IsEnemy = false};
            }
        }

        public void SetAbilityContext(int ownerId, int? target, bool isEnemy)
        {
            ContextTurn = new ContextTurnData
            {
                OwnerId = ownerId,
                InterfaceTargetId = target,
                IsEnemy = isEnemy,
            };
            SetContextFormula(ownerId);
            SetContextImpact(ownerId, ownerId, isEnemy);
            SetContextCondition(ownerId, ownerId, isEnemy);
        }

        public void SetContextImpact(int ownerId, int target, bool isEnemy)
        {
            //Logger.Log($"{Logger.GetTabString()}change context impact owner: id = {ownerId} target id = {target}");
            ContextImpact = new ContextAbilityData { OwnerId = ownerId, CurrentTarget = target, IsEnemy = isEnemy };
            CurrentContext = ContextImpact;
        }

        public void SetContextCondition(int ownerId, int target, bool isEnemy)
        {
            //Logger.Log($"{Logger.GetTabString()}change context condition owner id = {ownerId} target id = {target}");
            ContextCondition = new ContextAbilityData { OwnerId = ownerId, CurrentTarget = target, IsEnemy = isEnemy };
            CurrentContext = ContextCondition;
        }

        public List<int> FindContextTarget(ContextTargetType target, ContextAbilityData context)
        {
            var list = new List<int>();
            switch (target)
            {
                case ContextTargetType.Target:
                    list.Add(ContextTurn.InterfaceTargetId ?? context.OwnerId);
                    break;
                case ContextTargetType.Owner:
                    list.Add(context.OwnerId);
                    break;
                case ContextTargetType.AllAllies:
                    list = (context.IsEnemy ? _battleAccessor.LiveEnemies : _battleAccessor.LiveAllies).ToList();
                    break;
                case ContextTargetType.AllEnemies:
                    list = (context.IsEnemy ? _battleAccessor.LiveAllies : _battleAccessor.LiveEnemies).ToList();
                    break;
                case ContextTargetType.AllUnits:
                    list = _unitAccessor.State.Units.Where(x => x.Stars > 0).Select(x => x.Id).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(target), target, null);
            }
            return list;
        }

        public List<int> FindExplorerTarget(ContextTargetType target)
        {
            if (target == ContextTargetType.AllUnits)
            {
                return _unitAccessor.State.Units.Where(x => x.Stars > 0).Select(x => x.Id).ToList();
            }
            var list = _unitAccessor.ExplorerUnits.ToList();
            if (_unitAccessor.State.Assist != null)
            {
                list.Add(_unitAccessor.State.Assist.Id);
            }
            return list;
        }
    }
}
