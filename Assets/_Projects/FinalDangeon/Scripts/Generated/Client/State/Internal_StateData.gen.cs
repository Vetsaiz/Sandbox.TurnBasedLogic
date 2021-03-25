using VetsEngine.MetaLogic.Core;
using System;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Client.Internal.Containers;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Accessors;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_StateData : IStateData
    {
        string DataId = "root";
        [JsonIgnore]
        public Internal_IAchievementState _AchievementState;
        [JsonName("achievements")]
        public Dictionary<string, Internal_IAchievementData> Internal_IAchievementState_Achievements = new Dictionary<string, Internal_IAchievementData>();
        [JsonName(" battleState")] 
        public Internal_IBattleState _BattleState;
        [JsonIgnore]
        public Internal_ICutSceneState _CutSceneState;
        [JsonName("completedCutScene")]
        public Dictionary<string, Boolean> Internal_ICutSceneState_CompletedCutScene = new Dictionary<string, Boolean>();
        [JsonIgnore]
        public Internal_IExplorerState _ExplorerState;
        [JsonName("current_stage_id")]
        public Int32 Internal_IExplorerState_StageId;
        [JsonName("current_room_id")]
        public Int32 Internal_IExplorerState_RoomId;
        [JsonName("stages")]
        public Dictionary<string, Internal_IStageData> Internal_IExplorerState_Stages = new Dictionary<string, Internal_IStageData>();
        [JsonName("inventory")]
        public Dictionary<string, Int32> Internal_IExplorerState_Inventory = new Dictionary<string, Int32>();
        [JsonName("position")]
        public ExplorerPositionData Internal_IExplorerState_Position;
        [JsonName("last_interactive_id")]
        public Int32 Internal_IExplorerState_LastInteractiveId;
        [JsonName("player_buffs")]
        public Dictionary<string, Int32> Internal_IExplorerState_PlayerBuffs = new Dictionary<string, Int32>();
        [JsonName("isRun")]
        public Boolean Internal_IExplorerState_IsRun;
        [JsonName("refresh_number")]
        public Int32 Internal_IExplorerState_RefreshNumber;
        [JsonIgnore]
        public Internal_IInventoryState _InventoryState;
        [JsonName("storage")]
        public Dictionary<string, Int32> Internal_IInventoryState_Items = new Dictionary<string, Int32>();
        [JsonName("gacha")]
        public Dictionary<string, Int64> Internal_IInventoryState_Gacha = new Dictionary<string, Int64>();
        [JsonIgnore]
        public Internal_ILogState _LogState;
        [JsonName("log")]
        public Dictionary<string, LogData> Internal_ILogState_Log = new Dictionary<string, LogData>();
        [JsonIgnore]
        public Internal_IPlayerState _PlayerState;
        [JsonName("level")]
        public Int32 Internal_IPlayerState_Level;
        [JsonName("exp")]
        public Int32 Internal_IPlayerState_Exp;
        [JsonName("reg_time")]
        public String Internal_IPlayerState_RegisterTime;
        [JsonName("login_time")]
        public String Internal_IPlayerState_LastLoginTime;
        [JsonName("sync_time")]
        public String Internal_IPlayerState_SyncTime;
        [JsonIgnore]
        public Internal_IScorersState _ScorersState;
        [JsonName("global_scorers")]
        public Dictionary<string, Int64> Internal_IScorersState_Values = new Dictionary<string, Int64>();
        [JsonName("battle_scorers")]
        public Dictionary<string, Int64> Internal_IScorersState_BattleValues = new Dictionary<string, Int64>();
        [JsonName("impact_scorers")]
        public Dictionary<string, Int64> Internal_IScorersState_ImpactValues = new Dictionary<string, Int64>();
        [JsonIgnore]
        public Internal_ISettingsState _SettingsState;
        [JsonName("music_off")]
        public Boolean Internal_ISettingsState_MusicOff;
        [JsonName("sound_off")]
        public Boolean Internal_ISettingsState_SoundOff;
        [JsonName("reg_time")]
        public Int64 Internal_ISettingsState_RegTime;
        [JsonName("login_time")]
        public Int64 Internal_ISettingsState_LoginTime;
        [JsonName("sync_time")]
        public Int64 Internal_ISettingsState_SyncTime;
        [JsonName("locale")]
        public String Internal_ISettingsState_Locale;
        [JsonName("server_type")]
        public ServerType Internal_ISettingsState_Server;
        [JsonName("current_version")]
        public String Internal_ISettingsState_CurrentVersion;
        [JsonName("build_id")]
        public Int32 Internal_ISettingsState_Build;
        [JsonName("random_state")]
        public Int32 Internal_ISettingsState_RandomState;
        [JsonName("push_status")]
        public Boolean Internal_ISettingsState_PushStatus;
        [JsonIgnore]
        public Internal_IShopState _ShopState;
        [JsonName("good_groups")]
        public Dictionary<string, Internal_IGoodGroupItem> Internal_IShopState_Groups = new Dictionary<string, Internal_IGoodGroupItem>();
        [JsonName("offers")]
        public Dictionary<string, Internal_IGoodSlotItem> Internal_IShopState_Offers = new Dictionary<string, Internal_IGoodSlotItem>();
        [JsonName("transactions")]
        public Dictionary<string, PaymentProgress> Internal_IShopState_Transactions = new Dictionary<string, PaymentProgress>();
        [JsonIgnore]
        public Internal_IUnitsState _UnitsState;
        [JsonName("units")]
        public List<Internal_IUnitData> Internal_IUnitsState_Units = new List<Internal_IUnitData>();
        [JsonName("assist")]
        public Internal_IUnitData Internal_IUnitsState_Assist;
        [JsonName("last_team")]
        public Dictionary<string, Int32> Internal_IUnitsState_LastTeam = new Dictionary<string, Int32>();

        public IAchievementStateClient AchievementState => _AchievementState;
        public IBattleStateClient BattleState => _BattleState;
        public ICutSceneStateClient CutSceneState => _CutSceneState;
        public IExplorerStateClient ExplorerState => _ExplorerState;
        public IInventoryStateClient InventoryState => _InventoryState;
        public ILogStateClient LogState => _LogState;
        public IPlayerStateClient PlayerState => _PlayerState;
        public IScorersStateClient ScorersState => _ScorersState;
        public ISettingsStateClient SettingsState => _SettingsState;
        public IShopStateClient ShopState => _ShopState;
        public IUnitsStateClient UnitsState => _UnitsState;

        public Internal_StateData()
        {
            _AchievementState = new Internal_IAchievementState(); 
            _BattleState = new Internal_IBattleState(); 
            _CutSceneState = new Internal_ICutSceneState(); 
            _ExplorerState = new Internal_IExplorerState(); 
            _InventoryState = new Internal_IInventoryState(); 
            _LogState = new Internal_ILogState(); 
            _PlayerState = new Internal_IPlayerState(); 
            _ScorersState = new Internal_IScorersState(); 
            _SettingsState = new Internal_ISettingsState(); 
            _ShopState = new Internal_IShopState(); 
            _UnitsState = new Internal_IUnitsState(); 
        }

        public void InitData(ChangeStorage storage, InternalAccessors _accessors)
        {
            _AchievementState._Achievements = Internal_IAchievementState_Achievements;
            _AchievementState.InitData(DataId, storage, _accessors.AchievementAccessor);
            _BattleState.InitData(DataId, storage, _accessors.BattleAccessor);
            _CutSceneState._CompletedCutScene = Internal_ICutSceneState_CompletedCutScene;
            _CutSceneState.InitData(DataId, storage, _accessors.CutSceneAccessor);
            _ExplorerState._StageId = Internal_IExplorerState_StageId;
            _ExplorerState._RoomId = Internal_IExplorerState_RoomId;
            _ExplorerState._Stages = Internal_IExplorerState_Stages;
            _ExplorerState._Inventory = Internal_IExplorerState_Inventory;
            _ExplorerState._Position = Internal_IExplorerState_Position;
            _ExplorerState._LastInteractiveId = Internal_IExplorerState_LastInteractiveId;
            _ExplorerState._PlayerBuffs = Internal_IExplorerState_PlayerBuffs;
            _ExplorerState._IsRun = Internal_IExplorerState_IsRun;
            _ExplorerState._RefreshNumber = Internal_IExplorerState_RefreshNumber;
            _ExplorerState.InitData(DataId, storage, _accessors.ExplorerAccessor);
            _InventoryState._Items = Internal_IInventoryState_Items;
            _InventoryState._Gacha = Internal_IInventoryState_Gacha;
            _InventoryState.InitData(DataId, storage, _accessors.InventoryAccessor);
            _LogState._Log = Internal_ILogState_Log;
            _LogState.InitData(DataId, storage, _accessors.LogAccessor);
            _PlayerState._Level = Internal_IPlayerState_Level;
            _PlayerState._Exp = Internal_IPlayerState_Exp;
            _PlayerState._RegisterTime = Internal_IPlayerState_RegisterTime;
            _PlayerState._LastLoginTime = Internal_IPlayerState_LastLoginTime;
            _PlayerState._SyncTime = Internal_IPlayerState_SyncTime;
            _PlayerState.InitData(DataId, storage, _accessors.PlayerAccessor);
            _ScorersState._Values = Internal_IScorersState_Values;
            _ScorersState._BattleValues = Internal_IScorersState_BattleValues;
            _ScorersState._ImpactValues = Internal_IScorersState_ImpactValues;
            _ScorersState.InitData(DataId, storage, _accessors.ScorersAccessor);
            _SettingsState._MusicOff = Internal_ISettingsState_MusicOff;
            _SettingsState._SoundOff = Internal_ISettingsState_SoundOff;
            _SettingsState._RegTime = Internal_ISettingsState_RegTime;
            _SettingsState._LoginTime = Internal_ISettingsState_LoginTime;
            _SettingsState._SyncTime = Internal_ISettingsState_SyncTime;
            _SettingsState._Locale = Internal_ISettingsState_Locale;
            _SettingsState._Server = Internal_ISettingsState_Server;
            _SettingsState._CurrentVersion = Internal_ISettingsState_CurrentVersion;
            _SettingsState._Build = Internal_ISettingsState_Build;
            _SettingsState._RandomState = Internal_ISettingsState_RandomState;
            _SettingsState._PushStatus = Internal_ISettingsState_PushStatus;
            _SettingsState.InitData(DataId, storage, _accessors.SettingsAccessor);
            _ShopState._Groups = Internal_IShopState_Groups;
            _ShopState._Offers = Internal_IShopState_Offers;
            _ShopState._Transactions = Internal_IShopState_Transactions;
            _ShopState.InitData(DataId, storage, _accessors.ShopAccessor);
            _UnitsState._Units = Internal_IUnitsState_Units;
            _UnitsState._Assist = Internal_IUnitsState_Assist;
            _UnitsState._LastTeam = Internal_IUnitsState_LastTeam;
            _UnitsState.InitData(DataId, storage, _accessors.UnitsAccessor);
        }
        public void PreSave()
        {
            _AchievementState.PreSave();
            Internal_IAchievementState_Achievements = _AchievementState._Achievements;
            _BattleState.PreSave();
            _CutSceneState.PreSave();
            Internal_ICutSceneState_CompletedCutScene = _CutSceneState._CompletedCutScene;
            _ExplorerState.PreSave();
            Internal_IExplorerState_StageId = _ExplorerState._StageId;
            Internal_IExplorerState_RoomId = _ExplorerState._RoomId;
            Internal_IExplorerState_Stages = _ExplorerState._Stages;
            Internal_IExplorerState_Inventory = _ExplorerState._Inventory;
            Internal_IExplorerState_Position = _ExplorerState._Position;
            Internal_IExplorerState_LastInteractiveId = _ExplorerState._LastInteractiveId;
            Internal_IExplorerState_PlayerBuffs = _ExplorerState._PlayerBuffs;
            Internal_IExplorerState_IsRun = _ExplorerState._IsRun;
            Internal_IExplorerState_RefreshNumber = _ExplorerState._RefreshNumber;
            _InventoryState.PreSave();
            Internal_IInventoryState_Items = _InventoryState._Items;
            Internal_IInventoryState_Gacha = _InventoryState._Gacha;
            _LogState.PreSave();
            Internal_ILogState_Log = _LogState._Log;
            _PlayerState.PreSave();
            Internal_IPlayerState_Level = _PlayerState._Level;
            Internal_IPlayerState_Exp = _PlayerState._Exp;
            Internal_IPlayerState_RegisterTime = _PlayerState._RegisterTime;
            Internal_IPlayerState_LastLoginTime = _PlayerState._LastLoginTime;
            Internal_IPlayerState_SyncTime = _PlayerState._SyncTime;
            _ScorersState.PreSave();
            Internal_IScorersState_Values = _ScorersState._Values;
            Internal_IScorersState_BattleValues = _ScorersState._BattleValues;
            Internal_IScorersState_ImpactValues = _ScorersState._ImpactValues;
            _SettingsState.PreSave();
            Internal_ISettingsState_MusicOff = _SettingsState._MusicOff;
            Internal_ISettingsState_SoundOff = _SettingsState._SoundOff;
            Internal_ISettingsState_RegTime = _SettingsState._RegTime;
            Internal_ISettingsState_LoginTime = _SettingsState._LoginTime;
            Internal_ISettingsState_SyncTime = _SettingsState._SyncTime;
            Internal_ISettingsState_Locale = _SettingsState._Locale;
            Internal_ISettingsState_Server = _SettingsState._Server;
            Internal_ISettingsState_CurrentVersion = _SettingsState._CurrentVersion;
            Internal_ISettingsState_Build = _SettingsState._Build;
            Internal_ISettingsState_RandomState = _SettingsState._RandomState;
            Internal_ISettingsState_PushStatus = _SettingsState._PushStatus;
            _ShopState.PreSave();
            Internal_IShopState_Groups = _ShopState._Groups;
            Internal_IShopState_Offers = _ShopState._Offers;
            Internal_IShopState_Transactions = _ShopState._Transactions;
            _UnitsState.PreSave();
            Internal_IUnitsState_Units = _UnitsState._Units;
            Internal_IUnitsState_Assist = _UnitsState._Assist;
            Internal_IUnitsState_LastTeam = _UnitsState._LastTeam;
        }
    }
}
