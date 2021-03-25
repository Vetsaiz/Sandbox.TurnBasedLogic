using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class LogAccessor
    {
        public LogicData Data;

        public IStateFactory Factory { get; set; }
        public ILogState State { get; set; }
        public ILogStatic Static { get; set; }

        public void AddLog(LogData param)
        {
            if (Data.IsEmulate)
            {
                return;
            }

            if (LogicLog.IsClear)
            {
                LogicLog.IsClear = false;
                State.Log.Clear();
            }
            State.Log[State.Log.Count] = param;
        }

        public void ClearLog()
        {
            State.Log.Clear();
        }
    }
}
