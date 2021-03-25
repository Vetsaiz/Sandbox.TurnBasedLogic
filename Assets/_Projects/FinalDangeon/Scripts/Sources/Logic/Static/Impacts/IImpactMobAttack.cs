using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactMobAttack : IImpact
    {
        [SerializableId("mobs")]
        IReadOnlyDictionary<int, IImpactMobData> Mobs { get; }

        [SerializableId("unity_id")]
        string UnityObjectId { get; }

        [SerializableId("impact_win")]
        IImpact ImpactWin { get; }

        [SerializableId("impact_lose")]
        IImpact ImpactLose { get; }

        [SerializableId("impact_init")]
        IImpact ImpactInit { get; }
        
        [SerializableId("description")]
        string Description { get; }
    }

    public interface IImpactMobData
    {
        [SerializableId("mob_id")]
        int MobId { get; }

        [SerializableId("wave")]
        int Wave { get; }

        [SerializableId("position")]
        int Position { get; }

        [SerializableId("impact_init")]
        IImpact Impact { get; }
    }
}
