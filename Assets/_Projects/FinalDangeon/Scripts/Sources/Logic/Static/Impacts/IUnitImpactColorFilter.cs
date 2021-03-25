using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactColorFilter : IImpact
    {
        [SerializableId("color")]
        string Color { get; }
    }
}
