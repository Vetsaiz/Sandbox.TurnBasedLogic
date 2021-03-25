using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IMob
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("boss")]
        bool Boss { get; }

        [SerializableId("strength")]
        IFormula Strength { get; }

        [SerializableId("hp_max")]
        IFormula HpMax { get; }

        [SerializableId("initiative")]
        IFormula Initiative { get; }

        [SerializableId("ai")]
        IImpact Impact { get; }

        [SerializableId("impact_win")]
        IImpact ImpactWin { get; }
    }
}
