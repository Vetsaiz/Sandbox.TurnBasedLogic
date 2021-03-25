using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IStage : IStage 
    {
        public void PostSerialize()
        {
            _ImpactInit?.PostSerialize();
            _ImpactFinish?.PostSerialize();
            ROD_InteractiveObjectList = _InteractiveObjectList != null ? _InteractiveObjectList.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_RewardMoneyTypes = _RewardMoneyTypes != null ? _RewardMoneyTypes.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_RewardUnits = _RewardUnits != null ? _RewardUnits.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            ROD_RewardItems = _RewardItems != null ? _RewardItems.ToDictionary(
            x =>{ return Int32.Parse(x.Key); },
            y =>{ return y.Value;}
            ) : null;
            _Price?.PostSerialize();
            _ImpactAutowin?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public Int32 ZoneId => _ZoneId;

        public Int32 StageNumber => _StageNumber;

        public Int32 PlotChapter => _PlotChapter;

        public String Title => _Title;

        public String PlotPhrase => _PlotPhrase;

        public String Description => _Description;

        public Int32 StartRoomId => _StartRoomId;

        public String StartRoomPositionId => _StartRoomPositionId;

        public IImpact ImpactInit => _ImpactInit;

        public IImpact ImpactFinish => _ImpactFinish;

        public String Star1Description => _Star1Description;

        public String Star2Description => _Star2Description;

        public String Star3Description => _Star3Description;

        public String GoalDescription => _GoalDescription;

        public  IReadOnlyDictionary<Int32, Int32> InteractiveObjectList => ROD_InteractiveObjectList;

        public String UnityId => _UnityId;

        public  IReadOnlyDictionary<Int32, Int32> RewardMoneyTypes => ROD_RewardMoneyTypes;

        public  IReadOnlyDictionary<Int32, Int32> RewardUnits => ROD_RewardUnits;

        public  IReadOnlyDictionary<Int32, Int32> RewardItems => ROD_RewardItems;

        public IPrice Price => _Price;

        public Boolean Repeatable => _Repeatable;

        public Boolean IsTransfer => _IsTransfer;

        public Boolean NoExit => _NoExit;

        public IImpact ImpactAutowin => _ImpactAutowin;

        public Boolean ComingSoon => _ComingSoon;

        public String SpecDiscription => _SpecDiscription;

        public String SpecTitle => _SpecTitle;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("zone_id")]
        public Int32 _ZoneId;
        [JsonName("stage_number")]
        public Int32 _StageNumber;
        [JsonName("plot_chapter")]
        public Int32 _PlotChapter;
        [JsonName("ui_title")]
        public String _Title;
        [JsonName("plot_phrase")]
        public String _PlotPhrase;
        [JsonName("description")]
        public String _Description;
        [JsonName("start_room_id")]
        public Int32 _StartRoomId;
        [JsonName("start_room_position_id")]
        public String _StartRoomPositionId;
        [JsonName("impact_init")]
        public Internal_IImpact _ImpactInit;
        [JsonName("impact_finish")]
        public Internal_IImpact _ImpactFinish;
        [JsonName("star_1_description")]
        public String _Star1Description;
        [JsonName("star_2_description")]
        public String _Star2Description;
        [JsonName("star_3_description")]
        public String _Star3Description;
        [JsonName("goal_description")]
        public String _GoalDescription;
        [JsonName("interactive_object_list")]
        public Dictionary<String, Int32> _InteractiveObjectList;
        private Dictionary<Int32, Int32> ROD_InteractiveObjectList;
        [JsonName("unity_id")]
        public String _UnityId;
        [JsonName("reward_money_types")]
        public Dictionary<String, Int32> _RewardMoneyTypes;
        private Dictionary<Int32, Int32> ROD_RewardMoneyTypes;
        [JsonName("reward_units")]
        public Dictionary<String, Int32> _RewardUnits;
        private Dictionary<Int32, Int32> ROD_RewardUnits;
        [JsonName("reward_items")]
        public Dictionary<String, Int32> _RewardItems;
        private Dictionary<Int32, Int32> ROD_RewardItems;
        [JsonName("price")]
        public Internal_IPrice _Price;
        [JsonName("repeatable")]
        public Boolean _Repeatable;
        [JsonName("transfer")]
        public Boolean _IsTransfer;
        [JsonName("no_exit")]
        public Boolean _NoExit;
        [JsonName("impact_autowin")]
        public Internal_IImpact _ImpactAutowin;
        [JsonName("coming_soon")]
        public Boolean _ComingSoon;
        [JsonName("ui_specialgoal_desc")]
        public String _SpecDiscription;
        [JsonName("ui_specialgoal_title")]
        public String _SpecTitle;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
