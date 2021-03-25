using VetsEngine.MetaLogic.Core;
using System;
using VetsEngine.MetaLogic.Contracts;
using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.AdditionalLogic;
namespace MetaLogic.Client.Internal.Containers
{
    internal partial class InternalAdditionalLogics : ILogicAPI
    {
        public readonly ContextLogic ContextLogic;
        public readonly DropLogic DropLogic;
        public readonly ScorersLogic ScorersLogic;
        public readonly ShopLogic ShopLogic;
        public readonly ApplyChangeLogic ApplyChangeLogic;
        public readonly FormulaLogic FormulaLogic;
        public readonly BuffLogic BuffLogic;
        public readonly ExplorerLogic ExplorerLogic;
        public readonly TriggerLogic TriggerLogic;
        public readonly ConditionLogic ConditionLogic;
        public readonly BattleLogic BattleLogic;
        public readonly ImpactLogic ImpactLogic;
        public readonly ImpactController ImpactController;
        public InternalAdditionalLogics(InternalAccessors accessors, IApplyManager storage, LogicData data, IServerAPI api)
        {
            ImpactController = new ImpactController(data.IsEmulate);
            ContextLogic = ContextLogic.CreateClient(accessors.BattleAccessor, accessors.UnitsAccessor);
            DropLogic = DropLogic.CreateClient(accessors.ScorersAccessor, accessors.InventoryAccessor, accessors.UnitsAccessor, accessors.ExplorerAccessor, accessors.FormulaController, ImpactController);
            ScorersLogic = ScorersLogic.CreateClient(accessors.BattleAccessor, accessors.ScorersAccessor, accessors.ExplorerAccessor);
            ShopLogic = ShopLogic.CreateClient(accessors.SettingsAccessor, accessors.ShopAccessor, accessors.FormulaController);
            ApplyChangeLogic = ApplyChangeLogic.CreateClient(storage, ContextLogic);
            FormulaLogic = FormulaLogic.CreateClient(ContextLogic, accessors.ScorersAccessor, accessors.UnitsAccessor, accessors.BattleAccessor, accessors.ExplorerAccessor, data, accessors.PlayerAccessor, accessors.SettingsAccessor, accessors.ConditionController, accessors.FormulaController, ScorersLogic);
            BuffLogic = BuffLogic.CreateClient(accessors.BattleAccessor, ContextLogic, ApplyChangeLogic);
            ExplorerLogic = ExplorerLogic.CreateClient(accessors.ScorersAccessor, accessors.ExplorerAccessor, accessors.UnitsAccessor, accessors.FormulaController, ScorersLogic, ContextLogic, DropLogic, ImpactController);
            TriggerLogic = TriggerLogic.CreateClient(accessors.BattleAccessor, FormulaLogic);
            ConditionLogic = ConditionLogic.CreateClient(accessors.InventoryAccessor, accessors.ScorersAccessor, accessors.PlayerAccessor, accessors.UnitsAccessor, accessors.BattleAccessor, accessors.ExplorerAccessor, accessors.SettingsAccessor, accessors.AchievementAccessor, FormulaLogic, ContextLogic, ScorersLogic, data, accessors.ConditionController);
            BattleLogic = BattleLogic.CreateClient(ApplyChangeLogic, ContextLogic, ConditionLogic, accessors.FormulaController, accessors.BattleAccessor, accessors.ScorersAccessor, accessors.UnitsAccessor, accessors.ExplorerAccessor, accessors.SettingsAccessor);
            ImpactLogic = ImpactLogic.CreateClient(accessors.ScorersAccessor, accessors.PlayerAccessor, accessors.InventoryAccessor, accessors.ExplorerAccessor, accessors.UnitsAccessor, accessors.BattleAccessor, accessors.SettingsAccessor, accessors.AchievementAccessor, BattleLogic, FormulaLogic, accessors.ConditionController, ApplyChangeLogic, BuffLogic, ScorersLogic, ContextLogic, ImpactController, data);
        }
        public void PostInit()
        {
            FormulaLogic.RegisterCalculators();
            TriggerLogic.PostInit();
            ConditionLogic.RegisterRestrictions();
            ImpactLogic.PostInit();
        }
        public ContextAbilityData GetPublicContext()
        {
            return ContextLogic.GetPublicContext();
        }
        public void BatchAction(Action callback)
        {
            ApplyChangeLogic.BatchAction(callback);
        }
        public CutSceneResult[] GetCutSceneResults()
        {
            return ApplyChangeLogic.GetCutSceneResults();
        }
        public BattleTurnResult[] GetCallbacks()
        {
            return ApplyChangeLogic.GetCallbacks();
        }
        public IFormulaLogic GetStateFormula()
        {
            return FormulaLogic.GetStateFormula();
        }
        public Double Calculate(IFormula data, Int32 unit)
        {
            return FormulaLogic.Calculate(data, unit);
        }
        public IFormulaLogic CreateClientFormula()
        {
            return FormulaLogic.CreateClientFormula();
        }
        public void RegisterTrigger<T>(ITriggerChecker<T> checker) where T: ITrigger
        {
            TriggerLogic.RegisterTrigger(checker);
        }
        public void UnregisterTrigger(TriggerType id)
        {
            TriggerLogic.UnregisterTrigger(id);
        }
        public Boolean CheckUnit(ICondition condition, Int32 unit)
        {
            return ConditionLogic.CheckUnit(condition, unit);
        }
        public void RegisterCondition<T>(IConditionChecker<T> checker) where T: ICondition
        {
            ConditionLogic.RegisterCondition(checker);
        }
        public void UnregisterCondition(ConditionType id)
        {
            ConditionLogic.UnregisterCondition(id);
        }
        public void RegisterImpact<T>(IImpactExecutor<T> executor) where T: IImpact
        {
            ImpactLogic.RegisterImpact(executor);
        }
        public void UnregisterImpact(ImpactType id)
        {
            ImpactLogic.UnregisterImpact(id);
        }
        public Boolean ExecuteImpact(IImpact impact, Boolean checkCondition)
        {
            return ImpactLogic.ExecuteImpact(impact, checkCondition);
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class ContextLogic
    {
        public static ContextLogic CreateClient(BattleAccessor _battleAccessor, UnitsAccessor _unitAccessor)
        {
            return new ContextLogic
            {
                _battleAccessor = _battleAccessor,
                _unitAccessor = _unitAccessor,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class DropLogic
    {
        public static DropLogic CreateClient(ScorersAccessor _scorers, InventoryAccessor _inventory, UnitsAccessor _units, ExplorerAccessor _explorer, FormulaController _formula, ImpactController _impact)
        {
            return new DropLogic
            {
                _scorers = _scorers,
                _inventory = _inventory,
                _units = _units,
                _explorer = _explorer,
                _formula = _formula,
                _impact = _impact,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class ScorersLogic
    {
        public static ScorersLogic CreateClient(BattleAccessor _battle, ScorersAccessor _scorers, ExplorerAccessor _explorer)
        {
            return new ScorersLogic
            {
                _battle = _battle,
                _scorers = _scorers,
                _explorer = _explorer,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class ShopLogic
    {
        public static ShopLogic CreateClient(SettingsAccessor _settings, ShopAccessor _shop, FormulaController _formula)
        {
            return new ShopLogic
            {
                _settings = _settings,
                _shop = _shop,
                _formula = _formula,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class ApplyChangeLogic
    {
        public static ApplyChangeLogic CreateClient(IApplyManager _manager, ContextLogic _context)
        {
            return new ApplyChangeLogic
            {
                _manager = _manager,
                _context = _context,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class FormulaLogic
    {
        public static FormulaLogic CreateClient(ContextLogic _contextLogic, ScorersAccessor _scorers, UnitsAccessor _units, BattleAccessor _battle, ExplorerAccessor _explorer, LogicData _data, PlayerAccessor _player, SettingsAccessor _settings, ConditionController _controller, FormulaController _formula, ScorersLogic _scorerLogic)
        {
            return new FormulaLogic
            {
                _contextLogic = _contextLogic,
                _scorers = _scorers,
                _units = _units,
                _battle = _battle,
                _explorer = _explorer,
                _data = _data,
                _player = _player,
                _settings = _settings,
                _controller = _controller,
                _formula = _formula,
                _scorerLogic = _scorerLogic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class BuffLogic
    {
        public static BuffLogic CreateClient(BattleAccessor _accessor, ContextLogic _contextLogic, ApplyChangeLogic _logic)
        {
            return new BuffLogic
            {
                _accessor = _accessor,
                _contextLogic = _contextLogic,
                _logic = _logic,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class ExplorerLogic
    {
        public static ExplorerLogic CreateClient(ScorersAccessor _scorers, ExplorerAccessor _explorer, UnitsAccessor _units, FormulaController _formula, ScorersLogic _scorersLogic, ContextLogic _context, DropLogic _drop, ImpactController _impact)
        {
            return new ExplorerLogic
            {
                _scorers = _scorers,
                _explorer = _explorer,
                _units = _units,
                _formula = _formula,
                _scorersLogic = _scorersLogic,
                _context = _context,
                _drop = _drop,
                _impact = _impact,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class TriggerLogic
    {
        public static TriggerLogic CreateClient(BattleAccessor _battle, FormulaLogic _formula)
        {
            return new TriggerLogic
            {
                _battle = _battle,
                _formula = _formula,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class ConditionLogic
    {
        public static ConditionLogic CreateClient(InventoryAccessor _inventoryAccessor, ScorersAccessor _scorersAccessor, PlayerAccessor _profileAccessor, UnitsAccessor _unitAccessor, BattleAccessor _battleAccessor, ExplorerAccessor _explorerAccessor, SettingsAccessor _settingsAccessor, AchievementAccessor _achievementAccessor, FormulaLogic _formulaLogic, ContextLogic _contextLogic, ScorersLogic _scorerLogic, LogicData _data, ConditionController _controller)
        {
            return new ConditionLogic
            {
                _inventoryAccessor = _inventoryAccessor,
                _scorersAccessor = _scorersAccessor,
                _profileAccessor = _profileAccessor,
                _unitAccessor = _unitAccessor,
                _battleAccessor = _battleAccessor,
                _explorerAccessor = _explorerAccessor,
                _settingsAccessor = _settingsAccessor,
                _achievementAccessor = _achievementAccessor,
                _formulaLogic = _formulaLogic,
                _contextLogic = _contextLogic,
                _scorerLogic = _scorerLogic,
                _data = _data,
                _controller = _controller,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class BattleLogic
    {
        public static BattleLogic CreateClient(ApplyChangeLogic _manager, ContextLogic _context, ConditionLogic _condition, FormulaController _formula, BattleAccessor _battle, ScorersAccessor _scorers, UnitsAccessor _units, ExplorerAccessor _explorer, SettingsAccessor _settings)
        {
            return new BattleLogic
            {
                _manager = _manager,
                _context = _context,
                _condition = _condition,
                _formula = _formula,
                _battle = _battle,
                _scorers = _scorers,
                _units = _units,
                _explorer = _explorer,
                _settings = _settings,
            }
            ;
        }
    }
}
namespace MetaLogic.Logic.AdditionalLogic
{
    internal partial class ImpactLogic
    {
        public static ImpactLogic CreateClient(ScorersAccessor _scorers, PlayerAccessor _player, InventoryAccessor _inventory, ExplorerAccessor _explorer, UnitsAccessor _units, BattleAccessor _battle, SettingsAccessor _settings, AchievementAccessor _achievement, BattleLogic _battleLogic, FormulaLogic _formulaLogic, ConditionController _condition, ApplyChangeLogic _applyChangeLogic, BuffLogic _buff, ScorersLogic _scorersLogic, ContextLogic _contextLogic, ImpactController _impactController, LogicData _data)
        {
            return new ImpactLogic
            {
                _scorers = _scorers,
                _player = _player,
                _inventory = _inventory,
                _explorer = _explorer,
                _units = _units,
                _battle = _battle,
                _settings = _settings,
                _achievement = _achievement,
                _battleLogic = _battleLogic,
                _formulaLogic = _formulaLogic,
                _condition = _condition,
                _applyChangeLogic = _applyChangeLogic,
                _buff = _buff,
                _scorersLogic = _scorersLogic,
                _contextLogic = _contextLogic,
                _impactController = _impactController,
                _data = _data,
            }
            ;
        }
    }
}
