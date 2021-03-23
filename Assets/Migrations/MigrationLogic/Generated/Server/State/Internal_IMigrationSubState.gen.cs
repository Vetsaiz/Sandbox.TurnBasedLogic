using MigrationLogic.Logic.StateData;
using Pathfinding.Serialization.JsonFx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Server.State
{
    internal class Internal_IMigrationSubState : IMigrationSubState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "migrationSubState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _Field1?.InitData(DataId, storage);
        }
        public void PreSave()
        {
            _Field1?.PreSave();
        }

        #region Internal

        [JsonName("field1")]
        public Internal_IMigrationSubState_1 _Field1;

        #endregion

        #region Source

        IMigrationSubState_1 IMigrationSubState.Field1
        {
            get => _Field1;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Field1?.ToString();
            return result;
        }

        #endregion

    }
}
