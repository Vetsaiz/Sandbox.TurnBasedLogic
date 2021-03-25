using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IGoodGroupSlot
    {
        [SerializableId("slot")]
        int Slot { get; }

        //[SerializableId("goods")]
        //IReadOnlyDictionary<int, int> GoodWeights { get; }

        [SerializableId("elements")]
        IReadOnlyDictionary<int, IGoodGroupElement> Goods { get; }
    }

    public interface IGoodGroupElement
    {
        [SerializableId("good_id")]
        int GoodId { get; }

        [SerializableId("weight")]
        IFormula Weight { get; }
    }
}
