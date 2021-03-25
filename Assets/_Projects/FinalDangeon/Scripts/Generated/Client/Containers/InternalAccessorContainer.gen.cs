using MetaLogic.Client.Internal.State;
using MetaLogic.Client.Internal.Static;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Accessors;
namespace MetaLogic.Client.Internal.Containers
{
    internal partial class InternalAccessors
    {
        public readonly IStateFactory Factory;
        public readonly AchievementAccessor AchievementAccessor;
        public readonly BattleAccessor BattleAccessor;
        public readonly CutSceneAccessor CutSceneAccessor;
        public readonly ExplorerAccessor ExplorerAccessor;
        public readonly InventoryAccessor InventoryAccessor;
        public readonly LogAccessor LogAccessor;
        public readonly PlayerAccessor PlayerAccessor;
        public readonly ScorersAccessor ScorersAccessor;
        public readonly SettingsAccessor SettingsAccessor;
        public readonly ShopAccessor ShopAccessor;
        public readonly UnitsAccessor UnitsAccessor;
        public readonly ConditionController ConditionController;
        public readonly FormulaController FormulaController;
        public InternalAccessors(LogicData LogicData, IStateFactory factory)
        {
            Factory = factory;
            ConditionController = new ConditionController();
            FormulaController = new FormulaController();
            AchievementAccessor = new AchievementAccessor();
            BattleAccessor = new BattleAccessor();
            CutSceneAccessor = new CutSceneAccessor();
            ExplorerAccessor = new ExplorerAccessor();
            InventoryAccessor = new InventoryAccessor();
            LogAccessor = new LogAccessor();
            LogAccessor.Data = LogicData;
            PlayerAccessor = new PlayerAccessor();
            ScorersAccessor = new ScorersAccessor();
            SettingsAccessor = new SettingsAccessor();
            ShopAccessor = new ShopAccessor();
            UnitsAccessor = new UnitsAccessor();
        }

        public void SetStateData(Internal_StateData stateData)
        {
            AchievementAccessor.State = stateData._AchievementState;
            BattleAccessor.State = stateData._BattleState;
            CutSceneAccessor.State = stateData._CutSceneState;
            ExplorerAccessor.State = stateData._ExplorerState;
            InventoryAccessor.State = stateData._InventoryState;
            LogAccessor.State = stateData._LogState;
            PlayerAccessor.State = stateData._PlayerState;
            ScorersAccessor.State = stateData._ScorersState;
            SettingsAccessor.State = stateData._SettingsState;
            ShopAccessor.State = stateData._ShopState;
            UnitsAccessor.State = stateData._UnitsState;
        }
        public void SetStateData(Emulate_StateData stateData)
        {
            AchievementAccessor.State = stateData._AchievementState;
            BattleAccessor.State = stateData._BattleState;
            CutSceneAccessor.State = stateData._CutSceneState;
            ExplorerAccessor.State = stateData._ExplorerState;
            InventoryAccessor.State = stateData._InventoryState;
            LogAccessor.State = stateData._LogState;
            PlayerAccessor.State = stateData._PlayerState;
            ScorersAccessor.State = stateData._ScorersState;
            SettingsAccessor.State = stateData._SettingsState;
            ShopAccessor.State = stateData._ShopState;
            UnitsAccessor.State = stateData._UnitsState;
        }
        public void SetStaticData(IStaticData staticData)
        {
            AchievementAccessor.Static = staticData.AchievementStatic;
            BattleAccessor.Static = staticData.BattleStatic;
            CutSceneAccessor.Static = staticData.CutScenesStatic;
            ExplorerAccessor.Static = staticData.ExplorerStatic;
            InventoryAccessor.Static = staticData.InventoryStatic;
            LogAccessor.Static = staticData.LogStatic;
            PlayerAccessor.Static = staticData.PlayerStatic;
            ScorersAccessor.Static = staticData.ScorerStatic;
            SettingsAccessor.Settings = staticData.SettingsStatic;
            ShopAccessor.Static = staticData.ShopStatic;
            UnitsAccessor.Static = staticData.UnitsStatic;
            AchievementAccessor.Factory = Factory;
            BattleAccessor.Factory = Factory;
            ExplorerAccessor.Factory = Factory;
            LogAccessor.Factory = Factory;
            ShopAccessor.Factory = Factory;
            UnitsAccessor.Factory = Factory;
        }
        public void SetData(Internal_StateData stateData, Internal_StaticData staticData)
        {
            SetStaticData(staticData);
            SetStateData(stateData);
        }
    }
}
