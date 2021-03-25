using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;
using MetaLogic.Data;

namespace MetaLogic.Logic.State
{
    [StateData(IsRoot = true)]
    internal interface IShopState
    {
        [SerializableId("good_groups")]
        ILogicDictionary<int, IGoodGroupItem> Groups { get; }
        
        [SerializableId("offers")]
        ILogicDictionary<int, IGoodSlotItem> Offers { get; }

        [SerializableId("transactions")]
        ILogicDictionary<string, PaymentProgress> Transactions { get; }
    }

    internal interface IGoodGroupSlotItem //TODO костыль (обертка над массивом)
    {
        IGoodSlotItem[] Value { get; }
    }

    internal interface IGoodGroupItem
    {
        [SerializableId("slots")]
        IGoodGroupSlotItem CurrentSlots { get; set; }

        [SerializableId("refresh_number")]
        int RefreshNumber { get; set; }

        [SerializableId("refresh_time")]
        long FinishTime { get; set; }
    }

    internal interface IGoodSlotItem
    {
        [SerializableId("good_id")]
        int GoodId { get; }

        [SerializableId("buy")]
        bool IsBuy { get; set; }

        [SerializableId("refresh_time")]
        long WaitTime { get; set; }
    }
}
