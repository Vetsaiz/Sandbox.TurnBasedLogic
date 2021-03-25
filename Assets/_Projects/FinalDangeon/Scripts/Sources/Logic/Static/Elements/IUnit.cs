using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{

    public interface IUnit
    {
        int Id { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("world_id")]
        int WorldId { get; }
        [SerializableId("class_id")]
        int ClassId { get; }
        [SerializableId("unity_id")]
        string UnityId { get; }
        [SerializableId("rarities")]
        IReadOnlyDictionary<int, IRarity> Rarities { get; }
        [SerializableId("equipment_rarity")]
        IReadOnlyDictionary<int, IRarity> EquipmentRarities { get; }
        [SerializableId("familiar_title")]
        string FamiliarTitle { get; }
        [SerializableId("familiar_description")]
        string FamiliarDescription { get; }
        [SerializableId("equipment")]
        IReadOnlyDictionary<int, IEquipment> Equipment { get; }
        [SerializableId("missions")]
        IReadOnlyDictionary<int, IMission> Missions { get; }
        [SerializableId("strength")]
        IFormula Strength { get; }
        [SerializableId("hp_max")]
        IFormula HpMax { get; }
        [SerializableId("initiative")]
        IFormula Initiative { get; }
        [SerializableId("intro")]
        string Intro { get; }
        [SerializableId("has_familiar")]
        bool HasFamiliar { get; }
        [SerializableId("impact_init")]
        IImpact ImpactInit { get; }
        [SerializableId("impact_upgrade")]
        IImpact ImpactUpdrade { get; }

    }

    public interface IMission
    {
        [SerializableId("number")]
        int Number { get; }

        [SerializableId("stage_id")]
        int StageId { get; }
        
        [SerializableId("description")]
        string Description { get; }
    }

    public interface IUnitClass
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("ui_title")]
        string Title { get; }
        [SerializableId("unity_id")]
        string IconUnityId { get; }
        [SerializableId("description")]
        string Description { get;}
    }

    public interface IUnitLevel
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("level")]
        int Level { get; }
        [SerializableId("exp_min")]
        int ExpMin { get; }
        [SerializableId("price")]
        IReadOnlyDictionary<int, IPrice> Prices { get; }
        [SerializableId("impact_init")]
        IImpact Impact { get; }
    }

}
