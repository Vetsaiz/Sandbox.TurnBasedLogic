using System;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Logic.Static;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_StaticData : IStaticData, IInitStaticData
    {
        [JsonIgnore]
        public Internal_IAchievementStatic _AchievementStatic;
        public IAchievementStatic AchievementStatic => _AchievementStatic;
        [JsonName("achievements")]
        public Dictionary<String, Internal_IAchievement> Internal_IAchievementStatic_Achievements;
        [JsonIgnore]
        public Internal_IBattleStatic _BattleStatic;
        public IBattleStatic BattleStatic => _BattleStatic;
        [JsonName("buffs")]
        public Dictionary<String, Internal_IBuff> Internal_IBattleStatic_Buffs;
        [JsonName("buff_types")]
        public Dictionary<String, Internal_IBuffType> Internal_IBattleStatic_BuffType;
        [JsonName("mods")]
        public Dictionary<String, Internal_IModifier> Internal_IBattleStatic_Modifiers;
        [JsonName("params")]
        public Dictionary<String, Internal_IBattleParam> Internal_IBattleStatic_BattleParams;
        [JsonIgnore]
        public Internal_ICutScenesStatic _CutScenesStatic;
        public ICutScenesStatic CutScenesStatic => _CutScenesStatic;
        [JsonName("cutscenes")]
        public Dictionary<String, Internal_ICutScene> Internal_ICutScenesStatic_CutScenes;
        [JsonIgnore]
        public Internal_IExplorerStatic _ExplorerStatic;
        public IExplorerStatic ExplorerStatic => _ExplorerStatic;
        [JsonName("interactive_objects")]
        public Dictionary<String, Internal_IInteractiveObject> Internal_IExplorerStatic_Objects;
        [JsonName("stages")]
        public Dictionary<String, Internal_IStage> Internal_IExplorerStatic_Stages;
        [JsonName("rooms")]
        public Dictionary<String, Internal_IRoom> Internal_IExplorerStatic_Rooms;
        [JsonName("zones")]
        public Dictionary<String, Internal_IZone> Internal_IExplorerStatic_Zones;
        [JsonName("mobs")]
        public Dictionary<String, Internal_IMob> Internal_IExplorerStatic_Mobs;
        [JsonName("worlds")]
        public Dictionary<String, Internal_IWorld> Internal_IExplorerStatic_Worlds;
        [JsonIgnore]
        public Internal_IInventoryStatic _InventoryStatic;
        public IInventoryStatic InventoryStatic => _InventoryStatic;
        [JsonName("items")]
        public Dictionary<String, Internal_IInventoryItem> Internal_IInventoryStatic_Items;
        [JsonName("gacha")]
        public Dictionary<String, Internal_IGacha> Internal_IInventoryStatic_GachaItems;
        [JsonIgnore]
        public Internal_ILogStatic _LogStatic;
        public ILogStatic LogStatic => _LogStatic;
        [JsonName("events")]
        public Dictionary<String, Internal_ILogEvent> Internal_ILogStatic_Events;
        [JsonIgnore]
        public Internal_IPlayerStatic _PlayerStatic;
        public IPlayerStatic PlayerStatic => _PlayerStatic;
        [JsonName("player_levels")]
        public Dictionary<String, Internal_IPlayerLevel> Internal_IPlayerStatic_Levels;
        [JsonIgnore]
        public Internal_IScorerStatic _ScorerStatic;
        public IScorerStatic ScorerStatic => _ScorerStatic;
        [JsonName("scorers")]
        public Dictionary<String, Internal_IScorer> Internal_IScorerStatic_Scorers;
        [JsonName("money_types")]
        public Dictionary<String, Internal_IMoneyType> Internal_IScorerStatic_MoneyTypes;
        [JsonName("consts")]
        public Dictionary<String, Internal_IConstant> Internal_IScorerStatic_Consts;
        [JsonIgnore]
        public Internal_ISettingsStatic _SettingsStatic;
        public ISettingsStatic SettingsStatic => _SettingsStatic;
        [JsonName("pushes")]
        public Dictionary<String, Internal_IPush> Internal_ISettingsStatic_Pushes;
        [JsonName("ui")]
        public Dictionary<String, Internal_IUI> Internal_ISettingsStatic_UiElements;
        [JsonName("emoji")]
        public Dictionary<String, Internal_IEmoji> Internal_ISettingsStatic_Emojies;
        [JsonName("buildings")]
        public Dictionary<String, Internal_IBuilding> Internal_ISettingsStatic_Buildings;
        [JsonName("ui_text")]
        public Dictionary<String, Internal_IUIText> Internal_ISettingsStatic_Texts;
        [JsonName("ui_locale")]
        public Dictionary<String, Internal_ILocale> Internal_ISettingsStatic_Locales;
        [JsonName("ui_windows")]
        public Dictionary<String, Internal_IUIWindow> Internal_ISettingsStatic_Windows;
        [JsonName("abl_action_info_types")]
        public Dictionary<String, Internal_IAbilityActionInfo> Internal_ISettingsStatic_AbilityActionInfo;
        [JsonName("settings")]
        public Internal_IGameSettings Internal_ISettingsStatic_GameSettings;
        [JsonName("player_settings")]
        public Internal_IPlayerSettings Internal_ISettingsStatic_PlayerSettings;
        [JsonName("embed_impacts")]
        public Dictionary<String, Internal_IImpact> Internal_ISettingsStatic_Impacts;
        [JsonName("builds")]
        public Dictionary<String, Internal_IBuild> Internal_ISettingsStatic_Builds;
        [JsonIgnore]
        public Internal_IShopStatic _ShopStatic;
        public IShopStatic ShopStatic => _ShopStatic;
        [JsonName("goods")]
        public Dictionary<String, Internal_IGood> Internal_IShopStatic_Goods;
        [JsonName("good_groups")]
        public Dictionary<String, Internal_IGoodGroup> Internal_IShopStatic_GoodGroups;
        [JsonName("real_prices")]
        public Dictionary<String, Internal_IRealPrice> Internal_IShopStatic_RealPrices;
        [JsonName("offers")]
        public Dictionary<String, Internal_IOffer> Internal_IShopStatic_Offers;
        [JsonIgnore]
        public Internal_IUnitsStatic _UnitsStatic;
        public IUnitsStatic UnitsStatic => _UnitsStatic;
        [JsonName("units")]
        public Dictionary<String, Internal_IUnit> Internal_IUnitsStatic_Units;
        [JsonName("unit_classes")]
        public Dictionary<String, Internal_IUnitClass> Internal_IUnitsStatic_UnitClasses;
        [JsonName("unit_levels")]
        public Dictionary<String, Internal_IUnitLevel> Internal_IUnitsStatic_UnitLevels;
        [JsonName("ability_levels")]
        public Dictionary<String, Internal_IAbilityLevel> Internal_IUnitsStatic_AbilityLevels;
        [JsonName("abilities")]
        public Dictionary<String, Internal_IAbility> Internal_IUnitsStatic_Abilities;
        [JsonName("perks")]
        public Dictionary<String, Internal_IPerk> Internal_IUnitsStatic_Perks;
        [JsonName("perk_classes")]
        public Dictionary<String, Internal_IPerkClass> Internal_IUnitsStatic_PerkClasses;
        [JsonName("familiars")]
        public Dictionary<String, Internal_IFamiliar> Internal_IUnitsStatic_Familiars;

        public Internal_StaticData()
        {
            _AchievementStatic = new Internal_IAchievementStatic();
            _BattleStatic = new Internal_IBattleStatic();
            _CutScenesStatic = new Internal_ICutScenesStatic();
            _ExplorerStatic = new Internal_IExplorerStatic();
            _InventoryStatic = new Internal_IInventoryStatic();
            _LogStatic = new Internal_ILogStatic();
            _PlayerStatic = new Internal_IPlayerStatic();
            _ScorerStatic = new Internal_IScorerStatic();
            _SettingsStatic = new Internal_ISettingsStatic();
            _ShopStatic = new Internal_IShopStatic();
            _UnitsStatic = new Internal_IUnitsStatic();
        }
        public void PostSerialize()
        {
            _AchievementStatic._Achievements = Internal_IAchievementStatic_Achievements;
            _AchievementStatic.PostSerialize(); 
            _BattleStatic._Buffs = Internal_IBattleStatic_Buffs;
            _BattleStatic._BuffType = Internal_IBattleStatic_BuffType;
            _BattleStatic._Modifiers = Internal_IBattleStatic_Modifiers;
            _BattleStatic._BattleParams = Internal_IBattleStatic_BattleParams;
            _BattleStatic.PostSerialize(); 
            _CutScenesStatic._CutScenes = Internal_ICutScenesStatic_CutScenes;
            _CutScenesStatic.PostSerialize(); 
            _ExplorerStatic._Objects = Internal_IExplorerStatic_Objects;
            _ExplorerStatic._Stages = Internal_IExplorerStatic_Stages;
            _ExplorerStatic._Rooms = Internal_IExplorerStatic_Rooms;
            _ExplorerStatic._Zones = Internal_IExplorerStatic_Zones;
            _ExplorerStatic._Mobs = Internal_IExplorerStatic_Mobs;
            _ExplorerStatic._Worlds = Internal_IExplorerStatic_Worlds;
            _ExplorerStatic.PostSerialize(); 
            _InventoryStatic._Items = Internal_IInventoryStatic_Items;
            _InventoryStatic._GachaItems = Internal_IInventoryStatic_GachaItems;
            _InventoryStatic.PostSerialize(); 
            _LogStatic._Events = Internal_ILogStatic_Events;
            _LogStatic.PostSerialize(); 
            _PlayerStatic._Levels = Internal_IPlayerStatic_Levels;
            _PlayerStatic.PostSerialize(); 
            _ScorerStatic._Scorers = Internal_IScorerStatic_Scorers;
            _ScorerStatic._MoneyTypes = Internal_IScorerStatic_MoneyTypes;
            _ScorerStatic._Consts = Internal_IScorerStatic_Consts;
            _ScorerStatic.PostSerialize(); 
            _SettingsStatic._Pushes = Internal_ISettingsStatic_Pushes;
            _SettingsStatic._UiElements = Internal_ISettingsStatic_UiElements;
            _SettingsStatic._Emojies = Internal_ISettingsStatic_Emojies;
            _SettingsStatic._Buildings = Internal_ISettingsStatic_Buildings;
            _SettingsStatic._Texts = Internal_ISettingsStatic_Texts;
            _SettingsStatic._Locales = Internal_ISettingsStatic_Locales;
            _SettingsStatic._Windows = Internal_ISettingsStatic_Windows;
            _SettingsStatic._AbilityActionInfo = Internal_ISettingsStatic_AbilityActionInfo;
            _SettingsStatic._GameSettings = Internal_ISettingsStatic_GameSettings;
            _SettingsStatic._PlayerSettings = Internal_ISettingsStatic_PlayerSettings;
            _SettingsStatic._Impacts = Internal_ISettingsStatic_Impacts;
            _SettingsStatic._Builds = Internal_ISettingsStatic_Builds;
            _SettingsStatic.PostSerialize(); 
            _ShopStatic._Goods = Internal_IShopStatic_Goods;
            _ShopStatic._GoodGroups = Internal_IShopStatic_GoodGroups;
            _ShopStatic._RealPrices = Internal_IShopStatic_RealPrices;
            _ShopStatic._Offers = Internal_IShopStatic_Offers;
            _ShopStatic.PostSerialize(); 
            _UnitsStatic._Units = Internal_IUnitsStatic_Units;
            _UnitsStatic._UnitClasses = Internal_IUnitsStatic_UnitClasses;
            _UnitsStatic._UnitLevels = Internal_IUnitsStatic_UnitLevels;
            _UnitsStatic._AbilityLevels = Internal_IUnitsStatic_AbilityLevels;
            _UnitsStatic._Abilities = Internal_IUnitsStatic_Abilities;
            _UnitsStatic._Perks = Internal_IUnitsStatic_Perks;
            _UnitsStatic._PerkClasses = Internal_IUnitsStatic_PerkClasses;
            _UnitsStatic._Familiars = Internal_IUnitsStatic_Familiars;
            _UnitsStatic.PostSerialize(); 
        }

        public void Init(IStaticStorage storage)
        {
            throw new NotImplementedException();
        }
    }
}
