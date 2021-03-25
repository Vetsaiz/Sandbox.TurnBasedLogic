using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IGoodGroup
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }

        [SerializableId("period")]
        int Period { get; }

        [SerializableId("wide_slots")]
        bool WideSlots { get; }

        [SerializableId("slots")]
        IReadOnlyDictionary<int, IGoodGroupSlot> Slots { get; }

        [SerializableId("recharge_prices")]
        IReadOnlyDictionary<int, IChangePrice> RechargePrices { get; }
    }
}
