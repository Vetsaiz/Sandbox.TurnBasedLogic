using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface IFamiliar
    {
        int Id { get; }
        [SerializableId("pipup_unity_id")]
        string PipupUnityId { get; }

        [SerializableId("base_strength")]
        IReadOnlyDictionary<int, int> BaseStrength { get; }
    }
}
