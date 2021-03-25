using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class CutSceneAccessor
    {
        public ICutSceneState State { get; set; }
        public ICutScenesStatic Static { get; set; }


        [Query]
        public ICutScene GetCutScene(int id)
        {
            return Static.CutScenes[id];
        }

        public void CompleteCutScene(int id)
        {
            State.CompletedCutScene[id] = true;
        }

        [Query]
        public bool IsCompleteCutScene(int id)
        {
            return State.CompletedCutScene.ContainsKey(id);
        }
    }
}
