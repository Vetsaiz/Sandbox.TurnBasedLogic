using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFormulaPerkRarity : IFormula
    {
        [SerializableId("perk_id")]
        int PerkId { get; }
    }
}
