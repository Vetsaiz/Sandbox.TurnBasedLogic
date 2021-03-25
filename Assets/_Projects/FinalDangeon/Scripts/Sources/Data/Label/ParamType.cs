using System;

namespace MetaLogic.Data
{
    public class ParamType
    {
        public const string UnitStrength = "strength";
        public const string UnitStrBase = "str_base";
        public const string UnitStrEquip = "str_equip";
        public const string UnitHp = "hp";
        public const string UnitHpMax = "hp_max";
        public const string UnitHpBase = "hp_base";
        public const string UnitHpEquip = "hp_equip";
        public const string UnitInitiative = "initiative";
        public const string UnitAblBase = "abl_base";
        public const string UnitAblFamiliar = "abl_familiar";
        public const string UnitAblUlta = "abl_ulta";
        public const string UserLevel = "level";
        public const string UnitInitBase = "init_base";
        public const string UnitInitEquip = "init_equip";
        public const string UnitStamina = "stamina";
        public const string UnitEquipStars = "equip_rarity";
        public const string EnergyMax = "energy_max";
    }

    public enum UpgradeType
    {
        None,
        AbilityAttackLevel,
        AbilitySpecLevel,
        AbilityUltLevel,
        UnitLevel,
        EquipmentRarity,
        UnitRarity,
        EquipmentSlots
    }

    public static class UpgradeTypeUtility
    {
        public static UpgradeType ToUpgradeType(this AbilityType type)
        {
            switch (type)
            {
                case AbilityType.BaseAttack:
                    return UpgradeType.AbilityAttackLevel;
                case AbilityType.UpgradeAttack:
                    return UpgradeType.AbilitySpecLevel;
                case AbilityType.Ultimate:
                    return UpgradeType.AbilityUltLevel;
               default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}
