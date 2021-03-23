using MigrationLogic.Logic.StateData;
using Pathfinding.Serialization.JsonFx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Client.State
{
    internal class Internal_IMigrationSubState : IMigrationSubStateClient, IMigrationSubState 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "migrationSubState";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            _Field1?.InitData(DataId, storage);
            Interface_Field1 = _Field1;
        }
        public void PreSave()
        {
            _Field1?.PreSave();
        }

        #region Interface

        private IMigrationSubState_1Client Interface_Field1;
        IMigrationSubState_1Client IMigrationSubStateClient.Field1 => Interface_Field1;

        #endregion

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
