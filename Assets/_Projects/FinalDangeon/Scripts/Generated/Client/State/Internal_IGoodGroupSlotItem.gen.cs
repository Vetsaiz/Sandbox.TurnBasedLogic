using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using System.Globalization;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IGoodGroupSlotItem : IGoodGroupSlotItemClient, IGoodGroupSlotItem 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "goodGroupSlotItem";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            if (_Value != null)
            {
                foreach (var temp in _Value)
                {
                    temp.InitData($"{DataId}.value", storage);
                }
            }
            Interface_Value = _Value;
        }
        public void PreSave()
        {
        }

        #region Interface

        private IGoodSlotItemClient[] Interface_Value;
        IGoodSlotItemClient[] IGoodGroupSlotItemClient.Value => Interface_Value;

        #endregion

        #region Internal

        [JsonName("value")]
        public Internal_IGoodSlotItem[] _Value;

        #endregion

        #region Source

        IGoodSlotItem[] IGoodGroupSlotItem.Value
        {
            get => _Value;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Value != null ? string.Join("", _Value.Select(x=>x?.ToString())) : "";
            return result;
        }

        #endregion

    }
}
