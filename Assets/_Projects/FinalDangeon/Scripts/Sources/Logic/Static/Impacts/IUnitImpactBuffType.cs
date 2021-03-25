using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactBuffType : IImpact
    {
        [SerializableId("buff_type_id")]
        IReadOnlyDictionary<int, int> BuffTypeIds { get; }

        [SerializableId("value")]
        IFormula Value { get; }
    }
}
