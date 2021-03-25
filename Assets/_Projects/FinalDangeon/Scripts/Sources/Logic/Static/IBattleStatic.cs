using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface IBattleStatic
    {
        [SerializableId("buffs")]
        IReadOnlyDictionary<int, IBuff> Buffs { get; }

        [SerializableId("buff_types")]
        IReadOnlyDictionary<int, IBuffType> BuffType { get; }

        [SerializableId("mods")]
        IReadOnlyDictionary<int, IModifier> Modifiers { get; }

        [SerializableId("params")]
        IReadOnlyDictionary<int, IBattleParam> BattleParams { get; }
    }
}
