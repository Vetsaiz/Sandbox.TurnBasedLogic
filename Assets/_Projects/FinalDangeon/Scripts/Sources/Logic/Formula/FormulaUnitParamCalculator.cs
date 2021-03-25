using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaUnitParamCalculator : FormulaCalculator<IFormulaUnitsParam>
    {
        private readonly BattleAccessor _battle;
        private readonly ContextLogic _context;
        private readonly UnitsAccessor _units;
        private FormulaController _formula;
        private PlayerAccessor _player;

        public FormulaUnitParamCalculator(FormulaController formula, ContextLogic context, BattleAccessor battle, UnitsAccessor units, PlayerAccessor player)
        {
            _formula = formula;
            _player = player;
            _context = context;
            _units = units;
            _battle = battle;
        }

        public override double Calculate(IFormulaUnitsParam formulaData)
        {
            if (!_battle.Static.BattleParams.TryGetValue(formulaData.Param, out var param)){
                //var param = _battle.Static.BattleParams[formulaData.Param];
                Logger.Error($"FormulaUnitParam no param id = {formulaData.Param}. return 1", this);
                return 1;
            }
            switch (param.Label) {
                case ParamType.EnergyMax:
                    return _formula.Calculate(_player.GetLevel(_player.State.Level).EnergyMax);
                case ParamType.UnitEquipStars:
                    if (_context.ContextFormula == null)
                    {
                        return 1;
                    }
                    if (_units.TryGetUnit(_context.ContextFormula.Value, true, out var unitData))
                    {
                        return unitData.EquipmentStars;
                    }
                    else
                    {
                        return 1;
                    }

            }
            if (_context.NeedExploreParam || !_context.BattleMode)
            {
                if (_context.ContextFormula == null)
                {
                    return 1;
                }
                var (data1, unit) = _units.GetUnit(_context.ContextFormula.Value);
                var sum = 0;
                switch (param.Label)
                {
                    case ParamType.UserLevel:
                        return data1.Level;
                    case ParamType.UnitHp:
                        return data1.CurrentHp;
                    case ParamType.UnitStrength:
                        return _formula.Calculate(unit.Strength);
                    case ParamType.UnitStrBase:
                        return unit.Rarities.Where(x => x.Value.Stars == data1.Stars).Sum(x => x.Value.Strength);
                    case ParamType.UnitStrEquip:
                        return _units.CalculateEquipStrength(_context.ContextFormula.Value);
                    case ParamType.UnitHpMax:
                        return _formula.Calculate(unit.HpMax);
                    case ParamType.UnitHpBase:
                        return unit.Rarities.Where(x => x.Value.Stars == data1.Stars).Sum(x => x.Value.HpMax);
                    case ParamType.UnitHpEquip:
                        return _units.CalculateEquipHp(_context.ContextFormula.Value);
                    case ParamType.UnitInitiative:
                        return _formula.Calculate(unit.Initiative);
                    case ParamType.UnitInitBase:
                        return unit.Rarities.Where(x => x.Value.Stars == data1.Stars).Sum(x => x.Value.Initiative);
                    case ParamType.UnitInitEquip:
                        return _units.CalculateEquipInit(_context.ContextFormula.Value);
                    case ParamType.UnitAblBase:
                        return GetAbilityParam(unit.Id, AbilityType.BaseAttack);
                    case ParamType.UnitAblFamiliar:
                        return GetAbilityParam(unit.Id, AbilityType.UpgradeAttack);
                    case ParamType.UnitAblUlta:
                        return GetAbilityParam(unit.Id, AbilityType.Ultimate);
                    case ParamType.UnitStamina:
                        return unit.Rarities.Where(x => x.Value.Stars == data1.Stars).Sum(x=> x.Value.Stamina);
                }
                return 1;
            }

            IMemberBattleData member = _context.GetMember(formulaData.TargetType);

            if (member == null)
            {
                Logger.Error($"FormulaUnitParam no param id = {formulaData.Param} return 1", this);
                return 1;
            }

            switch (param.Label)
            {
                case ParamType.UserLevel:
                    return 1;
                case ParamType.UnitHp:
                    return member.CurrentHp;
                case ParamType.UnitStrength:
                    return member.Strength.Value;
                case ParamType.UnitStrBase:
                    return member.Strength.Base;
                case ParamType.UnitStrEquip:
                    return member.Strength.Equip;
                case ParamType.UnitHpMax:
                    return member.HpMax.Value;
                case ParamType.UnitHpBase:
                    return member.HpMax.Base;
                case ParamType.UnitHpEquip:
                    return member.HpMax.Equip;
                case ParamType.UnitInitiative:
                    return member.Initiative.Value;
                case ParamType.UnitInitBase:
                    return member.Initiative.Base;
                case ParamType.UnitInitEquip:
                    return member.Initiative.Equip;
                case ParamType.UnitAblBase:
                    return member.MemberType == BattleMemberType.Unit ? GetAbilityParam(member.StaticId, AbilityType.BaseAttack) : 0;
                case ParamType.UnitAblFamiliar:
                    return member.MemberType == BattleMemberType.Unit ? GetAbilityParam(member.StaticId, AbilityType.UpgradeAttack) : 0;
                case ParamType.UnitAblUlta:
                    return member.MemberType == BattleMemberType.Unit ? GetAbilityParam(member.StaticId, AbilityType.Ultimate) : 0;
                default:
                    throw new ArgumentOutOfRangeException(param.Label);
            }

            float GetAbilityParam(int id, AbilityType type)
            {
                var ability = _units.Static.Abilities.Values.FirstOrDefault(y => y.Params.UnitId == id && y.Params.Mode == type);
                if (ability == null)
                {
                    Logger.Error($"FormulaUnitParam param id = {formulaData.Param}. userId = {id} abilityType = {type} no ability. return 1", this);
                    return 1;
                }
                if (!_units.GetUnit(id).data.Abilities.TryGetValue(ability.Id, out var level))
                {
                    Logger.Error($"FormulaUnitParam param id = {formulaData.Param}. userId = {id} abilityType = {type} no ability. return 1", this);
                    return 1;
                }
                return level;
            }
        }

        public override FormulaType Id => FormulaType.FormulaUnitParam;
    }
}
