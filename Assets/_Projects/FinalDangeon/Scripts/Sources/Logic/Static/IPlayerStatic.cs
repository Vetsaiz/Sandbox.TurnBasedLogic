using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface IPlayerStatic
    {
        [SerializableId("player_levels")]
        IReadOnlyDictionary<int, IPlayerLevel> Levels { get; }
    }



    public interface IPlayerLevel
    {
        [SerializableId("id")]
        int Id { get; }
        [SerializableId("level")]
        int Level { get; }
        [SerializableId("exp_min")]
        int ExpMin { get; }
        [SerializableId("impact_init")]
        IImpact Impact { get; }
        [SerializableId("energy_max")]
        IFormula EnergyMax {get;}
        [SerializableId("description")]
        string Description { get; }
        [SerializableId("reward_money_types")]
        IReadOnlyDictionary<int, int> RewardMoneyTypes { get; }
        [SerializableId("reward_units")]
        IReadOnlyDictionary<int, int> RewardUnits { get; }
        [SerializableId("reward_items")]
        IReadOnlyDictionary<int, int> RewardItems { get; }
    }
}
