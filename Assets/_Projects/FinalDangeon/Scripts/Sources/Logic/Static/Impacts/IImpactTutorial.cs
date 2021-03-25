using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IImpactTutorial : IImpact
    {
        [SerializableId("tutorial_id")]
        int TutorialId { get; }
    }
}
