using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactExecutor : ImpactExecutor<IImpactExecute>
    {
        private ImpactController _logic;

        public ImpactExecutor(ImpactController logic)
        {
            _logic = logic;
        }

        public override void Execute(IImpactExecute data)
        {
            _logic.ExecuteImpact(data.Impact);
        }

        public override ImpactType Id => ImpactType.ImpExecute;
    }
}
