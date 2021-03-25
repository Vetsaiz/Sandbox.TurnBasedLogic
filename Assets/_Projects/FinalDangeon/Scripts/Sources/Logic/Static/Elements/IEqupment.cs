using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IEquipment
    {
        int Stars { get; }
        int Slot { get; }
        [SerializableId("item_id")]
        int ItemId { get; }

        [SerializableId("strength")]
        int Strength { get; }

        [SerializableId("hp_max")]
        int HpMax { get; }

        [SerializableId("initiative")]
        int Initiative { get; }
    }
}
