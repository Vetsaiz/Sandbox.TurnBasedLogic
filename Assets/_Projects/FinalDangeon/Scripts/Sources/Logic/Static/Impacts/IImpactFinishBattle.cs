using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactFinishBattle : IImpact
    {
        [SerializableId("result")]
        bool IsVictory { get; }
    }
}
