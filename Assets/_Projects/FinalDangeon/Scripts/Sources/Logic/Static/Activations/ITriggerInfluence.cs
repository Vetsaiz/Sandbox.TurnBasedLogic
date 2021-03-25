using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static.Activations
{
    public interface ITriggerInfluence : ITrigger
    {
        [SerializableId("influence_type")]
        InfluenceTargetType InfluenceType { get; }
    }
}
