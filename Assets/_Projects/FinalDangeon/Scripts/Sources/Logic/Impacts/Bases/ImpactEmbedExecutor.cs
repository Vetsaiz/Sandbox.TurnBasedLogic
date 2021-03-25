using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactEmbedExecutor : ImpactExecutor<IImpactEmbed>
    {
        private ImpactController _logic;
        private SettingsAccessor _settings;

        public ImpactEmbedExecutor(ImpactController logic, SettingsAccessor settings)
        {
            _settings = settings;
            _logic = logic;
        }

        public override void Execute(IImpactEmbed data)
        {
            var impact = _settings.Settings.Impacts[data.ImpactId];
            _logic.ExecuteImpact((impact as IImpactExecute).Impact);
        }

        public override ImpactType Id => ImpactType.ImpEmbed;
    }
}
