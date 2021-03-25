using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IPlayerSettings : IPlayerSettings 
    {
        public void PostSerialize()
        {
            ROD_ResourcesHead = _ResourcesHead != null ? _ResourcesHead.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_HpSegments = _HpSegments != null ? _HpSegments.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IHpSegment;
            }
            ) : null;
            ROD_StageRefreshCost = _StageRefreshCost != null ? _StageRefreshCost.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IChangePrice;
            }
            ) : null;
            ROD_ExploreRefreshCost = _ExploreRefreshCost != null ? _ExploreRefreshCost.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IChangePrice;
            }
            ) : null;
            ROD_MoneySegments = _MoneySegments != null ? _MoneySegments.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IMoneySegment;
            }
            ) : null;
        }

        #region Interface

        public Single DailyTaskLevel => _DailyTaskLevel;

        public Single HpCrit => _HpCrit;

        public Single ManaUIMax => _ManaUIMax;

        public Int32 ExpMax => _ExpMax;

        public Int32 UnitMax => _UnitMax;

        public Int32 InventoryMax => _InventoryMax;

        public Int32 ManaMax => _ManaMax;

        public  IReadOnlyDictionary<Int32, Int32> ResourcesHead => ROD_ResourcesHead;

        public Int32 ReserveCost => _ReserveCost;

        public Int32 EscapeCost => _EscapeCost;

        public Int32 UnitDuplicateCost => _UnitDuplicateCost;

        public Int32 ShardsCurrency => _ShardsCurrency;

        public  IReadOnlyDictionary<Int32, IHpSegment> HpSegments => ROD_HpSegments;

        public  IReadOnlyDictionary<Int32, IChangePrice> StageRefreshCost => ROD_StageRefreshCost;

        public Int32 StageDailyNumber => _StageDailyNumber;

        public  IReadOnlyDictionary<Int32, IChangePrice> ExploreRefreshCost => ROD_ExploreRefreshCost;

        public Int32 BuyStamina => _BuyStamina;

        public  IReadOnlyDictionary<Int32, IMoneySegment> MoneySegments => ROD_MoneySegments;


        #endregion

        #region Internal

        [JsonName("daily_task_level")]
        public Single _DailyTaskLevel;
        [JsonName("hp_crit")]
        public Single _HpCrit;
        [JsonName("mana_ui_max")]
        public Single _ManaUIMax;
        [JsonName("exp_max")]
        public Int32 _ExpMax;
        [JsonName("unit_max")]
        public Int32 _UnitMax;
        [JsonName("inventory_max")]
        public Int32 _InventoryMax;
        [JsonName("mana_max")]
        public Int32 _ManaMax;
        [JsonName("resources_head")]
        public Dictionary<String, Int32> _ResourcesHead;
        private Dictionary<Int32, Int32> ROD_ResourcesHead;
        [JsonName("reserve_cost")]
        public Int32 _ReserveCost;
        [JsonName("escape_cost")]
        public Int32 _EscapeCost;
        [JsonName("unit_duplicate_cost")]
        public Int32 _UnitDuplicateCost;
        [JsonName("shards_currency")]
        public Int32 _ShardsCurrency;
        [JsonName("hp_segments")]
        public Dictionary<String, Internal_IHpSegment> _HpSegments;
        private Dictionary<Int32, IHpSegment> ROD_HpSegments;
        [JsonName("stage_refresh_cost")]
        public Dictionary<String, Internal_IChangePrice> _StageRefreshCost;
        private Dictionary<Int32, IChangePrice> ROD_StageRefreshCost;
        [JsonName("stage_daily_number")]
        public Int32 _StageDailyNumber;
        [JsonName("explore_stamina_cost")]
        public Dictionary<String, Internal_IChangePrice> _ExploreRefreshCost;
        private Dictionary<Int32, IChangePrice> ROD_ExploreRefreshCost;
        [JsonName("explore_buy_stamina")]
        public Int32 _BuyStamina;
        [JsonName("money_type_segments")]
        public Dictionary<String, Internal_IMoneySegment> _MoneySegments;
        private Dictionary<Int32, IMoneySegment> ROD_MoneySegments;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
