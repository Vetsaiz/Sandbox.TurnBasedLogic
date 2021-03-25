using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactUnitAdd : IImpact
    {
        [SerializableId("unit")]
        IUnitAdd Unit{ get; }
    }

    public interface IUnitAdd
    {
        [SerializableId("unit_id")]
        int Id { get; }
        [SerializableId("shards")]
        int Shards { get; }
        [SerializableId("stars")]
        int Stars { get;}
        [SerializableId("exp")]
        int Exp { get; }
        [SerializableId("level")]
        int Level { get; }

        [SerializableId("perk_charges")]
        IReadOnlyDictionary<int, int> PerkCharges { get; }

        [SerializableId("equipment")]
        IReadOnlyDictionary<int, int> Equipment { get; }

        [SerializableId("equipment_level")]
        int EquipmentRarity { get; }

        [SerializableId("has_familiar")]
        bool FamiliarUnlock { get; }

        [SerializableId("assist")]
        bool Assist { get; }

        [SerializableId("reserve")]
        bool Reserve { get; }

        [SerializableId("position")]
        int SlotExplorer { get; }
    }
}
