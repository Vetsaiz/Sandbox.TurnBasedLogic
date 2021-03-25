using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactInteractiveObjectExecutor : ImpactExecutor<IImpactInteractiveObject>
    {
        private readonly ExplorerAccessor _explorer;

        public ImpactInteractiveObjectExecutor(ExplorerAccessor explorer)
        {
            _explorer = explorer;
        }


        public override void Execute(IImpactInteractiveObject data)
        {
            _explorer.SetInteractiveObject(data.InteractiveObjectId, data);
        }

        public override ImpactType Id => ImpactType.ImpChangeInteractiveObject;
    }
}
