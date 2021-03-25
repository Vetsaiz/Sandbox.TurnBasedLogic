using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IRarity
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("stars")]
        int Stars { get; }

        [SerializableId("shards")]
        int Shards { get; }

        [SerializableId("price")]
        IReadOnlyDictionary<int, IPrice> Prices { get; }

        [SerializableId("charges")]
        int Charges { get; }

        [SerializableId("upgrade_condition")]
        int UpgradeRestriction { get; }

        [SerializableId("stamina")]
        int Stamina { get; }

        [SerializableId("strength")]
        int Strength { get; }

        [SerializableId("hp_max")]
        int HpMax { get; }

        [SerializableId("initiative")]
        int Initiative { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("prev_diff_description")]
        string ChangesDescription { get; }

        [SerializableId("color")]
        string Color { get; }

        [SerializableId("title")]
        string Title { get; }
    }
}
