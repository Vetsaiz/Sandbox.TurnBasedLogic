using System;
using UniRx;

namespace MigrationLogic.Client
{
    public interface IStateData
    {
        IMigrationSampleStateClient MigrationSampleState {get;}
    }

    public interface IMigrationSampleStateClient
    {
        Int32 Field1 {get;}
        IMigrationSubState_1Client[] FieldString {get;}
        IMigrationSubState_1Client State1 {get;}
        IReadOnlyReactiveProperty<IMigrationSubStateClient> GetState2Property(Int32 key);
        IReadOnlyReactiveDictionary<Int32, IMigrationSubStateClient> State2 {get;}
        IReadOnlyReactiveCollection<IMigrationSubStateClient> State3 {get;}
        IReadOnlyReactiveCollection<IMigrationSubStateClient> State4 {get;}
        IReadOnlyReactiveProperty<IReadOnlyReactiveCollection<Int32>> GetState5Property(Int32 key);
        IReadOnlyReactiveProperty<IReadOnlyReactiveCollection<IMigrationSubStateClient>> GetState6Property(Int32 key);
    }
    public interface IMigrationSubStateClient
    {
        IMigrationSubState_1Client Field1 {get;}
    }
    public interface IMigrationSubState_1Client
    {
        Int32 Field1 {get;}
    }
}
