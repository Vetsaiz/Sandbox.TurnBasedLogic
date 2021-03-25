using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static.Conditions;

namespace MetaLogic.Logic.Conditions
{
    internal class ConditionStageChecker : ConditionChecker<IConditionStage>
    {
        private ExplorerAccessor _explorer;

        public ConditionStageChecker(ExplorerAccessor explorer)
        {
            _explorer = explorer;
        }

        public override bool Check(IConditionStage data)
        {
            return _explorer.CurrentStage == data.StageId;
        }

        public override ConditionType Id => ConditionType.CondStage;
    }
}
