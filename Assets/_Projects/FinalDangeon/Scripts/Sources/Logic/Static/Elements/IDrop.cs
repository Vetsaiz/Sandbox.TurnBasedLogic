using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IDrop
    {
        [SerializableId("template_id")]
        DropType Type { get; }

        [SerializableId("unit_id")]
        int UnitId { get; }
        
        [SerializableId("money_type_id")]
        int MoneyId { get; }

        [SerializableId("item_id")]
        int ItemId { get; }
    }
}
