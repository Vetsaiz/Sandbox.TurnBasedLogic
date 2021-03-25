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
    internal class Emulate_StateData : IEmulateStateData
    {
        public Emulate_IAchievementState _AchievementState;
        public Emulate_IBattleState _BattleState;
        public Emulate_ICutSceneState _CutSceneState;
        public Emulate_IExplorerState _ExplorerState;
        public Emulate_IInventoryState _InventoryState;
        public Emulate_ILogState _LogState;
        public Emulate_IPlayerState _PlayerState;
        public Emulate_IScorersState _ScorersState;
        public Emulate_ISettingsState _SettingsState;
        public Emulate_IShopState _ShopState;
        public Emulate_IUnitsState _UnitsState;

        public IAchievementStateEmulate AchievementState => _AchievementState;
        public IBattleStateEmulate BattleState => _BattleState;
        public ICutSceneStateEmulate CutSceneState => _CutSceneState;
        public IExplorerStateEmulate ExplorerState => _ExplorerState;
        public IInventoryStateEmulate InventoryState => _InventoryState;
        public ILogStateEmulate LogState => _LogState;
        public IPlayerStateEmulate PlayerState => _PlayerState;
        public IScorersStateEmulate ScorersState => _ScorersState;
        public ISettingsStateEmulate SettingsState => _SettingsState;
        public IShopStateEmulate ShopState => _ShopState;
        public IUnitsStateEmulate UnitsState => _UnitsState;

        public Emulate_StateData()
        {
            _AchievementState = new Emulate_IAchievementState(); 
            _BattleState = new Emulate_IBattleState(); 
            _CutSceneState = new Emulate_ICutSceneState(); 
            _ExplorerState = new Emulate_IExplorerState(); 
            _InventoryState = new Emulate_IInventoryState(); 
            _LogState = new Emulate_ILogState(); 
            _PlayerState = new Emulate_IPlayerState(); 
            _ScorersState = new Emulate_IScorersState(); 
            _SettingsState = new Emulate_ISettingsState(); 
            _ShopState = new Emulate_IShopState(); 
            _UnitsState = new Emulate_IUnitsState(); 
        }

        public void InitData(IStateData data, InternalAccessors _accessors, ChangeStorage storage)
        {
            _AchievementState.InitData(data.AchievementState, _accessors.AchievementAccessor, storage);
            _BattleState.InitData(data.BattleState, _accessors.BattleAccessor, storage);
            _CutSceneState.InitData(data.CutSceneState, _accessors.CutSceneAccessor, storage);
            _ExplorerState.InitData(data.ExplorerState, _accessors.ExplorerAccessor, storage);
            _InventoryState.InitData(data.InventoryState, _accessors.InventoryAccessor, storage);
            _LogState.InitData(data.LogState, _accessors.LogAccessor, storage);
            _PlayerState.InitData(data.PlayerState, _accessors.PlayerAccessor, storage);
            _ScorersState.InitData(data.ScorersState, _accessors.ScorersAccessor, storage);
            _SettingsState.InitData(data.SettingsState, _accessors.SettingsAccessor, storage);
            _ShopState.InitData(data.ShopState, _accessors.ShopAccessor, storage);
            _UnitsState.InitData(data.UnitsState, _accessors.UnitsAccessor, storage);
        }
    }
}
