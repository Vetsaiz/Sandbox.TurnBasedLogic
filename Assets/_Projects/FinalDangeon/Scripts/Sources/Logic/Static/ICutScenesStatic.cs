using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface ICutScenesStatic
    {
        [SerializableId("cutscenes")]
        IReadOnlyDictionary<int, ICutScene> CutScenes { get; }
    }
    
    public interface ICutScene
    {
        [SerializableId("title")]
        string Name { get; }

        [SerializableId("id")]
        int Id { get; }

        [SerializableId("skip")]
        bool Skip { get; }

        [SerializableId("frames")]
        IReadOnlyDictionary<int, ICutSceneType> Frames { get; }
    }
}
