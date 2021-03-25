using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface IInventoryStatic
    {
        [SerializableId("items")]
        IReadOnlyDictionary<int, IInventoryItem> Items { get; }

        [SerializableId("gacha")]
        IReadOnlyDictionary<int, IGacha> GachaItems { get; }

    }
}
