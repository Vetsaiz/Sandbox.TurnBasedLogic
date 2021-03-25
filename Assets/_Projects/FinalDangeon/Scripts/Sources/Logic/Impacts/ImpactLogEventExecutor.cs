using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Impacts
{
    class ImpactLogEventExecutor : ImpactExecutor<IImpactLogEvent>
    {
        public override void Execute(IImpactLogEvent data)
        {
            LogicLog.Event(data.EventId, data.EventValue);
        }

        public override ImpactType Id => ImpactType.ImpLogEvent;
    }
}
