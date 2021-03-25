using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IAbilityLevel
    {
        int Id { get; }
        int Level { get; }
        
        [SerializableId("base_attack_price")]
        IReadOnlyDictionary<int, IPrice> BaseAttackPrice { get; }

        [SerializableId("alter_attack_price")]
        IReadOnlyDictionary<int, IPrice> UpgradeAttackPrice { get; }

        [SerializableId("ultimate_attack_price")]
        IReadOnlyDictionary<int, IPrice> UltAttackPrice { get; }
    }
}
