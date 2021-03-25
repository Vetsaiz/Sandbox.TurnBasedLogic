using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IPrice
    {
        [SerializableId("value")]
        IFormula Value { get; }

        [SerializableId("money_type")]
        int MoneyType { get; }
    }

    public interface IUniversalPrice
    {
        [SerializableId("price")]
        IReadOnlyDictionary<int, IPrice> Prices { get; }
        
        [SerializableId("impact")]
        IImpact Impact { get; }

        [SerializableId("availability")]
        ICondition Condition { get; }
    }

    public interface IRealPrice
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("product_id")]
        string StoreId { get; }
    }

    public interface IChangePrice
    {
        [SerializableId("number")]
        int Numbler { get; }

        [SerializableId("price")]
        IPrice Price { get; }
    }
}
