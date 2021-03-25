using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class UnitImpactContainerExecutor : ImpactExecutor<IUnitImpactContainer>
    {
        private readonly ImpactController _impactLogic;

        public UnitImpactContainerExecutor(ImpactController impactLogic)
        {
            _impactLogic = impactLogic;
        }

        public override void Execute(IUnitImpactContainer data)
        {
            foreach (var temp in data.Impacts.Keys.OrderBy(x=> x))
            {
                var isComplete = _impactLogic.ExecuteImpact(data.Impacts[temp]);
                if (data.UnitImpactType == UnitImpactType.First && isComplete)
                {
                    break;
                }
            }
        }

        public override ImpactType Id => ImpactType.UnitImpContainer;
    }
}
