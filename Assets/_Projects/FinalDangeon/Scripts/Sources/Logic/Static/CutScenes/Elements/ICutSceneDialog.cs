using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    public interface ICutSceneDialog : ICutSceneFrame
    {
        [SerializableId("back_unity_id")]
        string IconBackId { get; }

        [SerializableId("events")]
        IReadOnlyDictionary<int, ICutSceneContainer> Events { get; }

    }

    public interface ICutSceneContainer
    {
        [SerializableId("events")]
        ICutSceneEvent Event { get; }
    }
}
