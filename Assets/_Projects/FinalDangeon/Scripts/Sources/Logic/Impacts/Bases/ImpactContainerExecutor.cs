using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactContainerExecutor : ImpactExecutor<IImpactContainer>
    {
        private ImpactController _logic;

        public ImpactContainerExecutor(ImpactController logic)
        {
            _logic = logic;
        }

        public override void Execute(IImpactContainer data)
        {
            foreach (var impact in data.Impacts.OrderBy(x=> x.Key)) {
                _logic.ExecuteImpact(impact.Value);
            }
        }

        public override ImpactType Id => ImpactType.ImpContainer;
    }
}
