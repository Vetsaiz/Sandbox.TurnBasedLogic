using MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Collections;

namespace MigrationLogic.Logic.StateData
{
    [StateData(IsRoot = true)]
    internal interface IMigrationSampleState
    {
        [SerializableId("field1")]
        int Field1 { get; }

        [SerializableId("field2")]
        ILogicList<IMigrationSubState_1> FieldString { get; }

        [SerializableId("test_state1")]
        IMigrationSubState_1 State1 { get; }

        [SerializableId("test_state2")]
        ILogicDictionary<int, IMigrationSubState> State2 { get; }

        [SerializableId("test_state3")]
        ILogicList<IMigrationSubState> State3 { get; }

        [SerializableId("test_state3")]
        ILogicList<IMigrationSubState> State4 { get; }

        [SerializableId("test_state2")]
        ILogicDictionary<int, ILogicList<int>> State5 { get; }

        [SerializableId("test_state2")]
        ILogicDictionary<int, ILogicList<IMigrationSubState>> State6 { get; }

    }

    internal interface IMigrationSubState
    {
        [SerializableId("field1")]
        IMigrationSubState_1 Field1 { get; }
    }

    internal interface IMigrationSubState_1
    {
        [SerializableId("field1")]
        int Field1 { get; }
    }
}