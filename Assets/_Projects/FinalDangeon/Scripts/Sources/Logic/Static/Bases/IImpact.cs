using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    [BaseContainer("template_label")]
    public interface IImpact
    {
        [SerializableId("template_id")]
        ImpactType TemplateLabel { get; }

        [SerializableId("condition")]
        ICondition Condition { get; }
    }

    public interface IImpactBase : IImpact 
    {
        [SerializableId("type")]
        IImpact ImpactType { get; }
    }

    public interface IImpactExecute : IImpact
    {
        [SerializableId("impact")]
        IImpact Impact { get; }
    }

    public interface IUnitImpactExecute : IImpact
    {
        [SerializableId("impact_unit")]
        IImpact ImpactUnit { get; }

        [SerializableId("condition_type")]
        ConditionTargetType ConditionType { get; }

        [SerializableId("target")]
        ContextTargetType Target { get; }
    }

    public interface IUnitImpactContainer : IImpact
    {
        [SerializableId("target_type")]
        UnitImpactType UnitImpactType { get; }

        [SerializableId("block")]
        IReadOnlyDictionary<int, IImpact> Impacts { get; }
    }

    public interface IImpactContainer : IImpact{
        [SerializableId("block")]
        IReadOnlyDictionary<int, IImpact> Impacts { get; }
    }

    public interface IImpactEmbed : IImpact
    {
        [SerializableId("impact_id")]
        int ImpactId { get; }
    }
}
