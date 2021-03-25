using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface IShopStatic
    {
        [SerializableId("goods")]
        IReadOnlyDictionary<int, IGood> Goods { get; }

        [SerializableId("good_groups")]
        IReadOnlyDictionary<int, IGoodGroup> GoodGroups { get; }
        
        [SerializableId("real_prices")]
        IReadOnlyDictionary<int, IRealPrice> RealPrices { get; }

        [SerializableId("offers")]
        IReadOnlyDictionary<int,IOffer> Offers { get;  }
    }
}
