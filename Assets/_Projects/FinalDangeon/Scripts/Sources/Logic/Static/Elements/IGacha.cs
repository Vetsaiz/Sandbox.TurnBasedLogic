using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IGacha
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("default_item")]
        bool DefaultView { get; }

        [SerializableId("impact")]
        IImpact Impact { get; }

        [SerializableId("type")]
        GachaType GachaType { get; }

        [SerializableId("bonus_unit_id")]
        int BonusUnitId { get; }

        [SerializableId("bonus_quantity")]
        IFormula BonusQuantity { get; }

        [SerializableId("end_time")]
        IFormula EndTime { get; }

        [SerializableId("availability")]
        ICondition Visibility { get; }

        [SerializableId("start_free_time")]
        IFormula StartFreeTime { get; }

        [SerializableId("items")]
        IReadOnlyDictionary<int, IGachaItem> Items { get; }

        [SerializableId("promo")]
        bool IsPromo { get; }

        [SerializableId("prices1")]
        IReadOnlyDictionary<int, IUniversalPrice> Prices1 { get; }

        [SerializableId("prices10")]
        IReadOnlyDictionary<int, IUniversalPrice> Prices10 { get; }
        
        [SerializableId("resources")]
        IReadOnlyDictionary<int, int> Resources { get; }

    }

    public interface IGachaItem
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("item_id")]
        int ItemId { get; }

        [SerializableId("money_type_id")]
        int MoneyTypeId { get; }

        [SerializableId("chance")]
        int Chance { get; }

        [SerializableId("number")]
        int Number { get; }

        [SerializableId("promo")]
        bool IsPromo { get; }

        [SerializableId("count")]
        int Count { get; }
    }
}
