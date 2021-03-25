using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using UnityEngine;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class AutowinModule
    {
        public ImpactController Impact;        
        public ExplorerAccessor _explorer;
        public ScorersAccessor Scorers;
        public FormulaLogic Formula;

        public ExplorerLogic _explorerLogic;

        [Command]
        public void StageAutowin(int selectedStageId, int tryCount)
        {
            var stage = _explorer.Stages[selectedStageId];
            var stageData = _explorer.GetStage(stage.Id);

            for (var i = 0; i < tryCount; i++)
            {
                _explorer.SetCurrentStage(selectedStageId);
                Impact.ExecuteImpact(stage.ImpactAutowin);
                Scorers.Spend(stage.Price, Formula);
                _explorer.ClearCurrentStage();
                LogicLog.SetExplorer(selectedStageId, LogExplorerType.AutoWin);
            }

            stageData.DailyNumber = Mathf.Clamp(stageData.DailyNumber - tryCount, 0, int.MaxValue);
        }
    }
}
