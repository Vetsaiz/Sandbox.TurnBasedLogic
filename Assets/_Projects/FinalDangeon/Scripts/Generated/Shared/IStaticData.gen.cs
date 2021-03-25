using System;
using System.Collections.Generic;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic
{
    public interface IStaticData
    {
        IAchievementStatic AchievementStatic {get;}
        IBattleStatic BattleStatic {get;}
        ICutScenesStatic CutScenesStatic {get;}
        IExplorerStatic ExplorerStatic {get;}
        IInventoryStatic InventoryStatic {get;}
        ILogStatic LogStatic {get;}
        IPlayerStatic PlayerStatic {get;}
        IScorerStatic ScorerStatic {get;}
        ISettingsStatic SettingsStatic {get;}
        IShopStatic ShopStatic {get;}
        IUnitsStatic UnitsStatic {get;}
    }
}
