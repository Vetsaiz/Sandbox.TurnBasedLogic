using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IAbilityAction
    {
        int Id { get; }

        [SerializableId("block")]
        IAblityActionBlock Block { get; }

        [SerializableId("condition")]
        ICondition Condition { get; }
    }

    public interface IAblityActionBlock
    {
        [SerializableId("template_id")]
        AbilityActionType Template { get; }
        
        [SerializableId("buff_id")]
        int BuffId { get; }

        [SerializableId("type")]
        int ActionInfoId { get; }
        
        [SerializableId("value")]
        IFormula Value { get; }
    }
}
