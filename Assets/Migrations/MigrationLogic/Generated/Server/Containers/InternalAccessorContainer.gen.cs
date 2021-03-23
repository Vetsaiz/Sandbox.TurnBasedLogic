using MigrationLogic.Logic.Accessors;
using MigrationLogic.Server.State;
using MigrationLogic.Server.Static;
using MigrationLogic.Shared;

namespace MigrationLogic.Server
{
    internal partial class InternalAccessors
    {
        public readonly Internal_IMigrationFactory Factory;
        public readonly MigrationsAccessor MigrationsAccessor;
        public InternalAccessors()
        {
            Factory = new Internal_IMigrationFactory();
            MigrationsAccessor = new MigrationsAccessor();
        }

        public void SetStateData(Internal_StateData stateData)
        {
            MigrationsAccessor.SampleState = stateData._MigrationSampleState;
        }
        public void SetStaticData(IStaticData staticData)
        {
            MigrationsAccessor.Static = staticData.MigrationsStatic;
            MigrationsAccessor.Factory = Factory;
        }
        public void SetData(Internal_StateData stateData, Internal_StaticData staticData)
        {
            SetStaticData(staticData);
            SetStateData(stateData);
        }
    }
}
