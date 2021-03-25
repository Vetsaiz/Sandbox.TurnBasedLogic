using MetaLogic.Data;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactBaseExecutor : ImpactExecutor<IImpactBase>
    {
        private ImpactController _logic;

        public ImpactBaseExecutor(ImpactController logic, ImpactType type)
        {
            _logic = logic;
            Id = type;
        }

        public override void Execute(IImpactBase data)
        {
            var check = true;
            if (data.ImpactType != null)
            {
                check = data.ImpactType.TemplateLabel != ImpactType.ImpCondition;
            }
            _logic.ExecuteImpact(data.ImpactType, check);
        }

        public override ImpactType Id { get; }
    }

    internal class ImpactEmptyExecutor : ImpactExecutor<IImpact>
    {
        public ImpactEmptyExecutor(ImpactType id)
        {
            Id = id;
        }

        public override void Execute(IImpact data)
        {

        }

        public override ImpactType Id { get; }
    }
}
