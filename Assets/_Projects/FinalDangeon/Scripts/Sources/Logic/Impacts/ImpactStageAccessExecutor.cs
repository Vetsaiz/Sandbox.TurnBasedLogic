using System;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactStageAccessExecutor : ImpactExecutor<IImpactStageAccess>
    {
        private ExplorerAccessor _explorer;
        private SettingsAccessor _settings;

        public ImpactStageAccessExecutor(ExplorerAccessor explorer, SettingsAccessor settings) {
            _explorer = explorer;
            _settings = settings;
        }

        public override void Execute(IImpactStageAccess data)
        {
            var stage = _explorer.GetStage(data.StageId);
            switch (data.Access)
            {
                case AccessType.Lock:
                    stage.IsUnlock = false;
                    break;
                case AccessType.Unlock:
                    stage.IsUnlock = true;
                    stage.DailyNumber = _settings.Settings.PlayerSettings.StageDailyNumber;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            LogicLog.StageAccess(data.StageId, data.Access);

        }

        public override ImpactType Id => ImpactType.ImpStageAccess;
    }
}
