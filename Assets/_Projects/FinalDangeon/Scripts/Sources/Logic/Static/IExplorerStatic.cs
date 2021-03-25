using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{

    [StaticData(IsRoot = true)]
    public interface IExplorerStatic
    {
        [SerializableId("interactive_objects")]
        IReadOnlyDictionary<int, IInteractiveObject> Objects { get; }

        [SerializableId("stages")]
        IReadOnlyDictionary<int, IStage> Stages { get; }

        [SerializableId("rooms")]
        IReadOnlyDictionary<int, IRoom> Rooms { get; }

        [SerializableId("zones")]
        IReadOnlyDictionary<int, IZone> Zones { get; }

        [SerializableId("mobs")]
        IReadOnlyDictionary<int, IMob> Mobs { get; }

        [SerializableId("worlds")]
        IReadOnlyDictionary<int, IWorld> Worlds { get; }
    }
}
