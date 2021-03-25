using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IPerk {

        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("class_id")]
        int ClassId { get; }

        [SerializableId("rarity")]
        IReadOnlyDictionary<int, IRarity> Rarities { get; }

        [SerializableId("owner")]
        string Owner { get; }

        [SerializableId("endless")]
        bool OnlyActive { get; }

        [SerializableId("actable")]
        ICondition Actable { get; }
    }

    public interface IPerkClass
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("stage_id")]
        int StateId { get; }
        [SerializableId("unity_id")]
        string UnityId { get; }
        [SerializableId("impact_init")]
        IImpact Impact { get; }
    }
}
