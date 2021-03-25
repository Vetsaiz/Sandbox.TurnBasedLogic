using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IAbilityParam
    {
        [SerializableId("unit_id")]
        int UnitId { get; }

        [SerializableId("mob_id")]
        int MobId { get; }

        [SerializableId("mode")]
        AbilityType Mode { get; }
    }

}
