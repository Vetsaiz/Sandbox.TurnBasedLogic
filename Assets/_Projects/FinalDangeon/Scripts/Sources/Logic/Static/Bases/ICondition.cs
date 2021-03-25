using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    [BaseContainer("template_label")]
    public interface ICondition
    {
        [SerializableId("template_id")]
        ConditionType TemplateLabel { get; }
    }

    public interface IConditionBase : ICondition
    {
        [SerializableId("type")]
        ICondition Condition { get; }
    }
    
    public interface IConditionConjunction : ICondition
    {
        [SerializableId("and")]
        IReadOnlyDictionary<int, ICondition> RestrictionsAnd { get; }
    }

    public interface IConditionDisjunction : ICondition
    {
        [SerializableId("or")]
        IReadOnlyDictionary<int, ICondition> RestrictionsOr { get; }
    }

    public interface IConditionNegation : ICondition
    {
        [SerializableId("cond")]
        ICondition ConditionNot { get; }
    }

    public interface IUnitConditionCheck : ICondition
    {
        [SerializableId("type")]
        ICondition Condition { get; }

        [SerializableId("condition_type")]
        ContextConditionType ConditionType { get; }

        [SerializableId("context_target")]
        ContextTargetType ContextTarget { get; }
    }
}
