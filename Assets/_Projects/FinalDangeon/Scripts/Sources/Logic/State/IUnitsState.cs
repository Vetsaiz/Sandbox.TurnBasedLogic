using System;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface IUnitsState
    {
        [SerializableId("units")]
        ILogicList<IUnitData> Units { get; }

        [SerializableId("assist")]
        IUnitData Assist { get; set; }

        [SerializableId("last_team")]
        ILogicDictionary<int, int> LastTeam { get; }
    }

    internal interface IUnitData
    {
        [SerializableId("unit_id")]
        int Id { get; }

        [SerializableId("shards")]
        int Shards { get; set; }

        [SerializableId("stars")]
        int Stars { get; set; }

        [SerializableId("exp")]
        int Exp { get; set; }

        [SerializableId("level")]
        int Level { get; set; }

        [SerializableId("abilities")]
        ILogicDictionary<int, int> Abilities { get; }

        [SerializableId("perks")]
        ILogicDictionary<int, int> PerkStars { get; }

        [SerializableId("perk_charges")]
        ILogicDictionary<int, int> PerkCharges { get; }

        [SerializableId("equipment")]
        ILogicDictionary<int, int> Equipment { get; }

        [SerializableId("equipment_level")]
        int EquipmentStars { get; set; }

        [SerializableId("buffs")]
        ILogicDictionary<int, int> Buffs { get; }

        [SerializableId("position")]
        int ExplorerPosition { get; set; }

        //[SerializableId("assist")]
        //bool Assist { get; set; }

        [SerializableId("reserve")]
        bool Reserve { get; set; }

        [SerializableId("hp_current")]
        float CurrentHp { get; set; }

        //[SerializableId("familiar_summoned")]
        //bool FamiliarSummoned { get; set; }

        [SerializableId("has_familiar")]
        bool FamiliarUnlock { get; set; }

        [SerializableId("mission_counter")]
        int MissionCounter { get; set; }
    }
}
