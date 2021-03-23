using System;
using MigrationLogic.Logic.StateData;
using Pathfinding.Serialization.JsonFx;
using VetsEngine.MetaLogic.Core;
using VetsEngine.MetaLogic.Core.Common;

namespace MigrationLogic.Server.State
{
    internal class Internal_IMigrationSubState_1 : IMigrationSubState_1 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "migrationSubState_1";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
        }
        public void PreSave()
        {
        }

        #region Internal

        [JsonName("field1")]
        public Int32 _Field1;

        #endregion

        #region Source

        Int32 IMigrationSubState_1.Field1
        {
            get => _Field1;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Field1;
            return result;
        }

        #endregion

    }
}
