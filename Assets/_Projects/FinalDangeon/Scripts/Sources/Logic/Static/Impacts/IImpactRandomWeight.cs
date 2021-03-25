using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactRandomWeight : IImpact
    {
        [SerializableId("random")]
        IReadOnlyDictionary<int, IWeightImpact> Weights { get; }
    }
    
    public interface IWeightImpact
    {
        [SerializableId("weight")]
        IFormula Formula { get; }
        [SerializableId("impact")]
        IImpact Impact { get; }
    }
}
