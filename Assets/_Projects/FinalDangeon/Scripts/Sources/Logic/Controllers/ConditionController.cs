using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Condition;
using MetaLogic.Data;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Controllers
{
    [LogicElement(ElementType.AccessorTechnical)]
    internal class ConditionController : BaseConditionController<ICondition>
    {
        public override int[] ContainersTemplateId => new int[]
        {
            (int)ConditionType.Conditions,
            (int)ConditionType.ConditionsUnit,
        };

        public override string GetStrTemplate(int templateId)
        {
            return ((ConditionType) templateId).ToString();
        }

        public bool Check(ICondition condition)
        {
            return Check(new ConditionData(condition));
        }
    }

    internal class ConditionData : BaseConditionData<ICondition>
    {
        public ConditionData(ICondition condition)
        {
            Data = condition;
            TemplateId = (int)(condition?.TemplateLabel ?? ConditionType.None);
        }
    }
}
