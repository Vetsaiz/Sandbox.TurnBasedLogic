using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface IUnitsStatic
    {
        [SerializableId("units")]
        IReadOnlyDictionary<int, IUnit> Units { get; }

        [SerializableId("unit_classes")]
        IReadOnlyDictionary<int, IUnitClass> UnitClasses { get; }

        [SerializableId("unit_levels")]
        IReadOnlyDictionary<int, IUnitLevel> UnitLevels { get; }

        [SerializableId("ability_levels")]
        IReadOnlyDictionary<int, IAbilityLevel> AbilityLevels { get; }

        [SerializableId("abilities")]
        IReadOnlyDictionary<int, IAbility> Abilities { get; }

        [SerializableId("perks")]
        IReadOnlyDictionary<int, IPerk> Perks { get; }

        [SerializableId("perk_classes")]
        IReadOnlyDictionary<int, IPerkClass> PerkClasses { get; }

        [SerializableId("familiars")]
        IReadOnlyDictionary<int, IFamiliar> Familiars { get; }
    }
}
