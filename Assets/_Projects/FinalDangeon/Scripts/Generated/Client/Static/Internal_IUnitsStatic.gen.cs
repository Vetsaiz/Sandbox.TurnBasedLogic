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
    internal class Internal_IUnitsStatic : IUnitsStatic 
    {
        public void PostSerialize()
        {
            ROD_Units = _Units != null ? _Units.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUnit;
            }
            ) : null;
            ROD_UnitClasses = _UnitClasses != null ? _UnitClasses.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUnitClass;
            }
            ) : null;
            ROD_UnitLevels = _UnitLevels != null ? _UnitLevels.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUnitLevel;
            }
            ) : null;
            ROD_AbilityLevels = _AbilityLevels != null ? _AbilityLevels.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IAbilityLevel;
            }
            ) : null;
            ROD_Abilities = _Abilities != null ? _Abilities.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IAbility;
            }
            ) : null;
            ROD_Perks = _Perks != null ? _Perks.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPerk;
            }
            ) : null;
            ROD_PerkClasses = _PerkClasses != null ? _PerkClasses.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPerkClass;
            }
            ) : null;
            ROD_Familiars = _Familiars != null ? _Familiars.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IFamiliar;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IUnit> Units => ROD_Units;

        public  IReadOnlyDictionary<Int32, IUnitClass> UnitClasses => ROD_UnitClasses;

        public  IReadOnlyDictionary<Int32, IUnitLevel> UnitLevels => ROD_UnitLevels;

        public  IReadOnlyDictionary<Int32, IAbilityLevel> AbilityLevels => ROD_AbilityLevels;

        public  IReadOnlyDictionary<Int32, IAbility> Abilities => ROD_Abilities;

        public  IReadOnlyDictionary<Int32, IPerk> Perks => ROD_Perks;

        public  IReadOnlyDictionary<Int32, IPerkClass> PerkClasses => ROD_PerkClasses;

        public  IReadOnlyDictionary<Int32, IFamiliar> Familiars => ROD_Familiars;


        #endregion

        #region Internal

        [JsonName("units")]
        public Dictionary<String, Internal_IUnit> _Units;
        private Dictionary<Int32, IUnit> ROD_Units;
        [JsonName("unit_classes")]
        public Dictionary<String, Internal_IUnitClass> _UnitClasses;
        private Dictionary<Int32, IUnitClass> ROD_UnitClasses;
        [JsonName("unit_levels")]
        public Dictionary<String, Internal_IUnitLevel> _UnitLevels;
        private Dictionary<Int32, IUnitLevel> ROD_UnitLevels;
        [JsonName("ability_levels")]
        public Dictionary<String, Internal_IAbilityLevel> _AbilityLevels;
        private Dictionary<Int32, IAbilityLevel> ROD_AbilityLevels;
        [JsonName("abilities")]
        public Dictionary<String, Internal_IAbility> _Abilities;
        private Dictionary<Int32, IAbility> ROD_Abilities;
        [JsonName("perks")]
        public Dictionary<String, Internal_IPerk> _Perks;
        private Dictionary<Int32, IPerk> ROD_Perks;
        [JsonName("perk_classes")]
        public Dictionary<String, Internal_IPerkClass> _PerkClasses;
        private Dictionary<Int32, IPerkClass> ROD_PerkClasses;
        [JsonName("familiars")]
        public Dictionary<String, Internal_IFamiliar> _Familiars;
        private Dictionary<Int32, IFamiliar> ROD_Familiars;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
