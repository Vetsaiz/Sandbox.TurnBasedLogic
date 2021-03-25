using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IUnitImpactAnimFrame : IImpact
    {
        [SerializableId("time")]
        IFormula TimeFormula { get; }

        [SerializableId("familiar_anim_start")]
        bool FamiliarAnimStart { get; }

        [SerializableId("unity_id")]
        string UnityObjectId { get; }

        [SerializableId("shell_duration")]
        string ShellDuration { get; }
    }
}
