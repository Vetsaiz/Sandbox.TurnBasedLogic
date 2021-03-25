using VetsEngine.MetaLogic.Core;
using MigrationLogic.Logic.StateData;
using MigrationLogic.Logic.StaticData;

namespace MigrationLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class MigrationsAccessor
    {
        public IMigrationSampleState SampleState { get; set; }
        public IMigrationsStatic Static { get; set; }
        public IMigrationFactory Factory { get; set; }

        public void MigrationTest()
        {
            
        }
    }
}
