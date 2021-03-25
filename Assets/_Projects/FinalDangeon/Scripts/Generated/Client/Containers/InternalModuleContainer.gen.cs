using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Modules;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Accessors;
namespace MetaLogic.Client.Internal.Containers
{
    internal partial class InternalModules
    {
        public readonly AchievementModule AchievementModule;
        public readonly ActivationModule ActivationModule;
        public readonly AutowinModule AutowinModule;
        public readonly BattleModule BattleModule;
        public readonly CheatModule CheatModule;
        public readonly CutSceneModule CutSceneModule;
        public readonly EquipmentModule EquipmentModule;
        public readonly ExplorerProgressModule ExplorerProgressModule;
        public readonly GachaModule GachaModule;
        public readonly SettingsModule SettingsModule;
        public readonly ShopModule ShopModule;
        public readonly StartSessionModule StartSessionModule;
        public readonly StorageModule StorageModule;
        public readonly UnitProgressModule UnitProgressModule;
        public InternalModules(InternalAccessors accessors, InternalAdditionalLogics additionalLogics, LogicData data, IServerAPI api)
        {
            AchievementModule = AchievementModule.CreateClient(accessors.AchievementAccessor, additionalLogics.ScorersLogic, additionalLogics.DropLogic, accessors.FormulaController, additionalLogics.ImpactController);
            ActivationModule = ActivationModule.CreateClient(accessors.FormulaController, additionalLogics.ImpactController, accessors.ExplorerAccessor, accessors.ScorersAccessor, accessors.PlayerAccessor, accessors.UnitsAccessor, additionalLogics.ApplyChangeLogic);
            AutowinModule = AutowinModule.CreateClient(additionalLogics.ImpactController, accessors.ExplorerAccessor, accessors.ScorersAccessor, additionalLogics.FormulaLogic, additionalLogics.ExplorerLogic);
            BattleModule = BattleModule.CreateClient(accessors.BattleAccessor, accessors.ExplorerAccessor, accessors.UnitsAccessor, additionalLogics.ContextLogic, additionalLogics.ImpactController, additionalLogics.TriggerLogic, additionalLogics.BattleLogic, additionalLogics.BuffLogic);
            CheatModule = CheatModule.CreateClient(accessors.UnitsAccessor, accessors.ScorersAccessor, accessors.BattleAccessor, accessors.InventoryAccessor, accessors.PlayerAccessor, accessors.ExplorerAccessor, accessors.LogAccessor, accessors.SettingsAccessor, additionalLogics.ExplorerLogic, additionalLogics.BattleLogic, additionalLogics.ContextLogic, additionalLogics.ImpactController, additionalLogics.DropLogic, additionalLogics.ScorersLogic);
            CutSceneModule = CutSceneModule.CreateClient(accessors.CutSceneAccessor, additionalLogics.ImpactController, additionalLogics.ApplyChangeLogic);
            EquipmentModule = EquipmentModule.CreateClient(accessors.InventoryAccessor, accessors.ScorersAccessor, accessors.UnitsAccessor, additionalLogics.ImpactController, additionalLogics.FormulaLogic);
            ExplorerProgressModule = ExplorerProgressModule.CreateClient(accessors.ExplorerAccessor, accessors.InventoryAccessor, accessors.UnitsAccessor, accessors.SettingsAccessor, accessors.ScorersAccessor, accessors.BattleAccessor, additionalLogics.ExplorerLogic, additionalLogics.FormulaLogic, additionalLogics.ImpactController);
            GachaModule = GachaModule.CreateClient(additionalLogics.ImpactController, accessors.ScorersAccessor, accessors.InventoryAccessor, accessors.UnitsAccessor, accessors.ExplorerAccessor, additionalLogics.DropLogic, accessors.ConditionController, additionalLogics.FormulaLogic);
            SettingsModule = SettingsModule.CreateClient(accessors.SettingsAccessor, accessors.ScorersAccessor, additionalLogics.ImpactController);
            ShopModule = ShopModule.CreateClient(accessors.ScorersAccessor, accessors.ShopAccessor, additionalLogics.FormulaLogic, additionalLogics.ImpactController, additionalLogics.ShopLogic, additionalLogics.DropLogic);
            StartSessionModule = StartSessionModule.CreateClient(accessors.UnitsAccessor, accessors.ScorersAccessor, accessors.BattleAccessor, accessors.InventoryAccessor, accessors.PlayerAccessor, accessors.ExplorerAccessor, accessors.LogAccessor, accessors.SettingsAccessor, accessors.ShopAccessor, accessors.LogAccessor, accessors.AchievementAccessor, additionalLogics.BattleLogic, additionalLogics.ShopLogic, additionalLogics.ExplorerLogic, accessors.FormulaController, additionalLogics.ImpactController);
            StorageModule = StorageModule.CreateClient(accessors.ScorersAccessor, accessors.InventoryAccessor);
            UnitProgressModule = UnitProgressModule.CreateClient(accessors.UnitsAccessor, accessors.ScorersAccessor, accessors.BattleAccessor, additionalLogics.FormulaLogic, accessors.PlayerAccessor, additionalLogics.ImpactController);
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class AchievementModule
    {
        public static AchievementModule CreateClient(AchievementAccessor _accessor, ScorersLogic _scorersLogic, DropLogic _dropLogic, FormulaController _formula, ImpactController _impacts)
        {
            return new AchievementModule
            {
                _accessor = _accessor,
                _scorersLogic = _scorersLogic,
                _dropLogic = _dropLogic,
                _formula = _formula,
                _impacts = _impacts,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class ActivationModule
    {
        public static ActivationModule CreateClient(FormulaController _formulaLogic, ImpactController _impactLogic, ExplorerAccessor _explorer, ScorersAccessor _scorers, PlayerAccessor Player, UnitsAccessor _units, ApplyChangeLogic _changeLogic)
        {
            return new ActivationModule
            {
                _formulaLogic = _formulaLogic,
                _impactLogic = _impactLogic,
                _explorer = _explorer,
                _scorers = _scorers,
                Player = Player,
                _units = _units,
                _changeLogic = _changeLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class AutowinModule
    {
        public static AutowinModule CreateClient(ImpactController Impact, ExplorerAccessor _explorer, ScorersAccessor Scorers, FormulaLogic Formula, ExplorerLogic _explorerLogic)
        {
            return new AutowinModule
            {
                Impact = Impact,
                _explorer = _explorer,
                Scorers = Scorers,
                Formula = Formula,
                _explorerLogic = _explorerLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class BattleModule
    {
        public static BattleModule CreateClient(BattleAccessor _battle, ExplorerAccessor _explorer, UnitsAccessor _units, ContextLogic _contextLogic, ImpactController _impactLogic, TriggerLogic _triggerLogic, BattleLogic _battleLogic, BuffLogic _buffLogic)
        {
            return new BattleModule
            {
                _battle = _battle,
                _explorer = _explorer,
                _units = _units,
                _contextLogic = _contextLogic,
                _impactLogic = _impactLogic,
                _triggerLogic = _triggerLogic,
                _battleLogic = _battleLogic,
                _buffLogic = _buffLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Accessors
{
    internal partial class CheatModule
    {
        public static CheatModule CreateClient(UnitsAccessor _units, ScorersAccessor _scorers, BattleAccessor _battle, InventoryAccessor _inventory, PlayerAccessor _player, ExplorerAccessor _explorer, LogAccessor _accessor, SettingsAccessor _settings, ExplorerLogic _explorerLogic, BattleLogic _battleLogic, ContextLogic _contextLogic, ImpactController _logic, DropLogic _drop, ScorersLogic _scorerLogic)
        {
            return new CheatModule
            {
                _units = _units,
                _scorers = _scorers,
                _battle = _battle,
                _inventory = _inventory,
                _player = _player,
                _explorer = _explorer,
                _accessor = _accessor,
                _settings = _settings,
                _explorerLogic = _explorerLogic,
                _battleLogic = _battleLogic,
                _contextLogic = _contextLogic,
                _logic = _logic,
                _drop = _drop,
                _scorerLogic = _scorerLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class CutSceneModule
    {
        public static CutSceneModule CreateClient(CutSceneAccessor _cutscene, ImpactController _logic, ApplyChangeLogic _changeLogic)
        {
            return new CutSceneModule
            {
                _cutscene = _cutscene,
                _logic = _logic,
                _changeLogic = _changeLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class EquipmentModule
    {
        public static EquipmentModule CreateClient(InventoryAccessor _resources, ScorersAccessor _scorers, UnitsAccessor _units, ImpactController _impact, FormulaLogic _formula)
        {
            return new EquipmentModule
            {
                _resources = _resources,
                _scorers = _scorers,
                _units = _units,
                _impact = _impact,
                _formula = _formula,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class ExplorerProgressModule
    {
        public static ExplorerProgressModule CreateClient(ExplorerAccessor _explorer, InventoryAccessor _inventory, UnitsAccessor _units, SettingsAccessor _settings, ScorersAccessor _scorers, BattleAccessor _battle, ExplorerLogic _explorerLogic, FormulaLogic _formula, ImpactController _impactLogic)
        {
            return new ExplorerProgressModule
            {
                _explorer = _explorer,
                _inventory = _inventory,
                _units = _units,
                _settings = _settings,
                _scorers = _scorers,
                _battle = _battle,
                _explorerLogic = _explorerLogic,
                _formula = _formula,
                _impactLogic = _impactLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class GachaModule
    {
        public static GachaModule CreateClient(ImpactController _impactLogic, ScorersAccessor _scorers, InventoryAccessor _resources, UnitsAccessor _units, ExplorerAccessor _explorer, DropLogic _dropLogic, ConditionController _condition, FormulaLogic _formuls)
        {
            return new GachaModule
            {
                _impactLogic = _impactLogic,
                _scorers = _scorers,
                _resources = _resources,
                _units = _units,
                _explorer = _explorer,
                _dropLogic = _dropLogic,
                _condition = _condition,
                _formuls = _formuls,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class SettingsModule
    {
        public static SettingsModule CreateClient(SettingsAccessor _settings, ScorersAccessor _scorers, ImpactController _impactLogic)
        {
            return new SettingsModule
            {
                _settings = _settings,
                _scorers = _scorers,
                _impactLogic = _impactLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class ShopModule
    {
        public static ShopModule CreateClient(ScorersAccessor _scorers, ShopAccessor _shop, FormulaLogic _formula, ImpactController _impacts, ShopLogic _shopLogic, DropLogic _dropLogic)
        {
            return new ShopModule
            {
                _scorers = _scorers,
                _shop = _shop,
                _formula = _formula,
                _impacts = _impacts,
                _shopLogic = _shopLogic,
                _dropLogic = _dropLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Accessors
{
    internal partial class StartSessionModule
    {
        public static StartSessionModule CreateClient(UnitsAccessor _units, ScorersAccessor _scorers, BattleAccessor _battle, InventoryAccessor _inventory, PlayerAccessor _player, ExplorerAccessor _explorer, LogAccessor _accessor, SettingsAccessor _settings, ShopAccessor _shop, LogAccessor _log, AchievementAccessor _achievement, BattleLogic _battleLogic, ShopLogic _shopLogic, ExplorerLogic _explorerLogic, FormulaController _formula, ImpactController _logic)
        {
            return new StartSessionModule
            {
                _units = _units,
                _scorers = _scorers,
                _battle = _battle,
                _inventory = _inventory,
                _player = _player,
                _explorer = _explorer,
                _accessor = _accessor,
                _settings = _settings,
                _shop = _shop,
                _log = _log,
                _achievement = _achievement,
                _battleLogic = _battleLogic,
                _shopLogic = _shopLogic,
                _explorerLogic = _explorerLogic,
                _formula = _formula,
                _logic = _logic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class StorageModule
    {
        public static StorageModule CreateClient(ScorersAccessor _scorers, InventoryAccessor _resources)
        {
            return new StorageModule
            {
                _scorers = _scorers,
                _resources = _resources,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.Modules
{
    internal partial class UnitProgressModule
    {
        public static UnitProgressModule CreateClient(UnitsAccessor _units, ScorersAccessor _scorers, BattleAccessor _battle, FormulaLogic _formuls, PlayerAccessor _player, ImpactController _impact)
        {
            return new UnitProgressModule
            {
                _units = _units,
                _scorers = _scorers,
                _battle = _battle,
                _formuls = _formuls,
                _player = _player,
                _impact = _impact,
            }
            ;
        }
    }
}
