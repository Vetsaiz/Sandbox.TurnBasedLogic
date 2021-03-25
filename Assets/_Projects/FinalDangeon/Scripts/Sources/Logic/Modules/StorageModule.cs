using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Accessors;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class StorageModule
    {
        public ScorersAccessor _scorers;
        public InventoryAccessor _resources;

        [Command]
        public void SellItem(int itemId, int count)
        {
            _resources.SpendItem(itemId, count);
        }
    }
}
