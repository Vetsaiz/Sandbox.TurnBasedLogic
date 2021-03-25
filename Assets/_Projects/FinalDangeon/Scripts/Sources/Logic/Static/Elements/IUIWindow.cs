using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;

namespace MetaLogic.Logic.Static
{
    public interface IUIWindow
    {
        [SerializableId("id")]
        int Id { get; }

        [SerializableId("impact")]
        IImpact Impact { get; }

        [SerializableId("resources")]
        IReadOnlyDictionary<int, int> Resources { get; }

        [SerializableId("ui_title")]
        string Title { get; }

        [SerializableId("unity_id")]
        string UnityId { get; }
    }
}
