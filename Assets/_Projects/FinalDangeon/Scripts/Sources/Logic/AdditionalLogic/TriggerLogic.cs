using System;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.EventTriggers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class TriggerLogic
    {
        public BattleAccessor _battle;
        public FormulaLogic _formula;

        private readonly Dictionary<TriggerType, Func<TriggerUnitData, ITrigger, bool>> _triggers =  new Dictionary<TriggerType, Func<TriggerUnitData, ITrigger, bool>>();

        public bool CheckTrigger(TriggerUnitData data, IActivationEvent activation, ActivationType type)
        {
            if (activation.Type == TriggerType.TriggerManual)
            {
                return false;
            }
            if (type == ActivationType.StartBattle)
            {
                return activation.Type == TriggerType.TriggerStartBattle;
            }
            
            if (activation.Events == null)
            {
                return false;
            }

            if (!_battle.IsTarget(data, activation.Target))
            {
                return false;
            }
            foreach (var temp in activation.Events)
            {
                if (!_triggers.TryGetValue(temp.Value.Activation.Type, out Func<TriggerUnitData, ITrigger, bool> action))
                {
                    throw new Exception($"no register impact executor type = {temp.Value.Activation.Type}");
                }
                if (action.Invoke(data, temp.Value.Activation))
                {
                    return true;
                }
            }
            return false;
        }

        [ClientAPI]
        public void RegisterTrigger<T>(ITriggerChecker<T> checker) where T : ITrigger
        {
            _triggers.Add(checker.Id, (owner, data) => checker.CheckTrigger(owner, (T)data));
        }

        [ClientAPI]
        public void UnregisterTrigger(TriggerType id)
        {
            _triggers.Remove(id);
        }

        [PostInit]
        public void PostInit()
        {
            RegisterTrigger(new TriggerHpChecker(_formula, _battle));
            RegisterTrigger(new TriggerInflienceChecker(_battle));
            RegisterTrigger(new TriggerBuffChecker(_formula, _battle));
            RegisterTrigger(new TriggerBuffTypeChecker(_formula, _battle));
            RegisterTrigger(new TriggerFamiliarSummonChecker(_battle));
        }
    }
}
