using MigrationLogic.Logic.StaticData;
using MigrationLogic.Shared;
using Pathfinding.Serialization.JsonFx;

namespace MigrationLogic.Client.Static
{
    internal class Internal_StaticData : IStaticData
    {
        [JsonName(" migrationsStatic")] 
        public Internal_IMigrationsStatic _MigrationsStatic;
        public IMigrationsStatic MigrationsStatic => _MigrationsStatic;

        public Internal_StaticData()
        {
            _MigrationsStatic = new Internal_IMigrationsStatic();
        }
        public void PostSerialize()
        {
            _MigrationsStatic.PostSerialize(); 
        }
    }
}
