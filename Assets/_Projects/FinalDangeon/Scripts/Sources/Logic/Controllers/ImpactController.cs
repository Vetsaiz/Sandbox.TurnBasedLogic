using System;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Formula;
using VetsEngine.MetaLogic.Core.Impacts;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Controllers
{
    [LogicElement(ElementType.LogicTechnical)]
    internal class ImpactController : BaseImpactController<IImpact>
    {
        private ConditionController _condition;
        private Action _postExecuteAction;

        private int counter;
        private ContextLogic _context;

        public override int[] ContainersTemplateId => new int[]
        {
            (int)ImpactType.Impacts,
            (int)ImpactType.UnitImpacts,
        };

        public override string GetStrTemplate(int templateId)
        {
            return ((ImpactType)templateId).ToString();
        }

        public bool ExecuteImpact(IImpact impact, bool checkCondition = true)
        {
            counter++;
            var value = ExecuteImpact(new ImpactData(impact, checkCondition));
            counter--;
            if (counter == 0)
            {
                _postExecuteAction?.Invoke();
            }
            return value;
        }

        public bool ExecuteContextImpact(IImpact impact, int unitId, bool checkCondition = true)
        {
            _context.SetContextFormula(unitId);
            _context.SetContextCondition(unitId, unitId, false);
            _context.SetContextImpact(unitId, unitId, false);
            var value = ExecuteImpact(impact, checkCondition);
            _context.SetContextCondition(-1, -1, false);
            _context.SetContextFormula(null);
            _context.SetContextImpact(-1, -1, false);
            return value;
        }

        public void Init(ContextLogic context, ConditionController condition, Action postExecuteAction)
        {
            _context = context;
            _postExecuteAction = postExecuteAction;
            _condition = condition;
        }

        public void UnregisterImpact(ImpactType id)
        {
            UnregisterImpact((int)id);
        }

        public override bool CheckRun(BaseImpactData<IImpact> impact)
        {
            if (impact is ImpactData data && data.CheckCondition && data.Data.Condition != null && !_condition.Check(data.Data.Condition))
            {
                return false;
            }
            return true;
        }

        public ImpactController(bool dataIsEmulate) : base(dataIsEmulate)
        {
        }
    }

    internal class ImpactData : BaseImpactData<IImpact>
    {
        public bool CheckCondition;

        public ImpactData(IImpact impact, bool checkCondition)
        {
            CheckCondition = checkCondition;
            Data = impact;
            TemplateId = (int)(impact?.TemplateLabel ?? ImpactType.None);
        }
    }
}
