using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static.Formula
{
    public interface IFormulaBuff : IFormula
    {
        [SerializableId("target")]
        TargetType Target { get; }

        [SerializableId("buff_id")]
        int BuffId { get; }
    }
}
