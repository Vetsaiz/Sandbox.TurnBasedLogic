using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using System.Globalization;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Static;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
using MetaLogic.Data;
using MetaLogic.Logic.State;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IInventoryState : IInventoryStateClient, IInventoryState 
    {
        private ChangeStorage _storage;
        private string DataId = "inventoryState";
        private InventoryAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, InventoryAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            LD_Items?.Init($"{DataId}.storage", storage, _Items);
            LD_Gacha?.Init($"{DataId}.gacha", storage, _Gacha);
        }
        public void PreSave()
        {
            _Items = LD_Items.Source;
            _Gacha = LD_Gacha.Source;
        }

        #region Queries

        public Int64 GetNextUpdate()
        {
            return _accessor.GetNextUpdate();
        }
        public IInventoryStatic StaticStatic => _accessor.Static;

        #endregion

        #region Interface

        IReadOnlyReactiveDictionary<Int32, Int32> IInventoryStateClient.Items => LD_Items.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetItemsProperty(Int32 key)
        {
            return LD_Items.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int64> IInventoryStateClient.Gacha => LD_Gacha.Interface;
        public IReadOnlyReactiveProperty<Int64?> GetGachaProperty(Int32 key)
        {
            return LD_Gacha.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("storage")]
        public Dictionary<string, Int32> _Items = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_Items = new StructLogicDictionary<Int32, Int32>();
        [JsonName("gacha")]
        public Dictionary<string, Int64> _Gacha = new Dictionary<string, Int64>();
        private StructLogicDictionary<Int32, Int64> LD_Gacha = new StructLogicDictionary<Int32, Int64>();

        #endregion

        #region Source

        ILogicDictionary<Int32, Int32> IInventoryState.Items
        {
            get => LD_Items;
        }
        ILogicDictionary<Int32, Int64> IInventoryState.Gacha
        {
            get => LD_Gacha;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LD_Items.ToString();
            result += LD_Gacha.ToString();
            return result;
        }

        #endregion

    }
}
