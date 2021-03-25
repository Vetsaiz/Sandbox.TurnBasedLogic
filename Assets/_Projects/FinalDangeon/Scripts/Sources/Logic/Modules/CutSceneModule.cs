using System;
using System.Linq;
using VetsEngine.MetaLogic.Contracts;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class CutSceneModule
    {
        public CutSceneAccessor _cutscene;
        public ImpactController _logic;

        public ApplyChangeLogic _changeLogic;


        [Command]
        public void RunCutSceneImpact(int cutsceneId, int index)
        {
            _changeLogic.SetMode(ApplyMode.Manual);

            var cutscene = _cutscene.GetCutScene(cutsceneId);
            var frame = cutscene.Frames.OrderBy(x => x.Key).Select(x => x.Value.Data).ToArray()[index];
            if (frame.TemplateLabel != CutSceneType.Impact || (frame as ICutSceneImpact) == null)
            {
                throw new Exception($"RunCutSceneImpact cutsceneid = {cutsceneId} index = {index} no type impact");
            }
            _logic.ExecuteImpact((frame as ICutSceneImpact).Impact);
            
            _changeLogic.BatchCutScene(0);
            _changeLogic.SetMode(ApplyMode.Auto);
        }
    }
}
