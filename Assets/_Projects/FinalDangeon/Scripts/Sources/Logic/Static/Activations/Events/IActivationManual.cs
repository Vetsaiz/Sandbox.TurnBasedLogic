using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static.Activations
{
    public interface IActivationManual : ITrigger
    {
        [SerializableId("target")]
        TargetActivationType Target { get; }
    }
}
