using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IGood
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("description")]
        string Description { get; }

        [SerializableId("price")]
        IReadOnlyDictionary<int, IPrice> Price { get; }

        [SerializableId("price_real")]
        int RealPrice { get; }

        [SerializableId("end_time")]
        IFormula EndTime { get; }

        [SerializableId("quantity")]
        IFormula Quantity { get; }

        [SerializableId("impact")]
        IImpact Impact { get; }

        [SerializableId("visibility")]
        ICondition Visibility { get; }

        [SerializableId("items")]
        IReadOnlyDictionary<int, IDropItem> Items { get; }

        [SerializableId("badge")]
        GoodLabelType GoodType { get; }
    }
    public interface IDropItem
    {
        [SerializableId("item")]
        IDrop Item { get; }
        
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
