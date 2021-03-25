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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IUnitsState : IUnitsStateClient, IUnitsState 
    {
        private ChangeStorage _storage;
        private string DataId = "unitsState";
        private UnitsAccessor _accessor;
        public void InitData(string root, ChangeStorage storage, UnitsAccessor accessor)
        {
            _accessor = accessor;
            _storage = storage;
            DataId = root;
            LL_Units?.Init($"{DataId}.units", storage, _Units);
            _Assist?.InitData(DataId, storage);
            Interface_Assist = new ReactiveProperty<IUnitDataClient>(_Assist);
            LD_LastTeam?.Init($"{DataId}.last_team", storage, _LastTeam);
        }
        public void PreSave()
        {
            foreach (var temp in LL_Units)
            {
                (temp as Internal_IUnitData).PreSave();
            }
            _Assist?.PreSave();
            _LastTeam = LD_LastTeam.Source;
        }

        #region Queries

        public IPrice[] GetAbilityPrices(System.Int32 countLevel, MetaLogic.Data.AbilityType type)
        {
            return _accessor.GetAbilityPrices(countLevel, type);
        }
        public Int32 GetShardsForUpgrage(System.Int32 unitId, System.Int32 countStars)
        {
            return _accessor.GetShardsForUpgrage(unitId, countStars);
        }
        public Int32 CalculateMaxStamina(System.Int32 unitId)
        {
            return _accessor.CalculateMaxStamina(unitId);
        }
        public Int32 CalculatePerkCharges(System.Int32 unitId, System.Int32 perkId)
        {
            return _accessor.CalculatePerkCharges(unitId, perkId);
        }
        public IUnitsStatic StaticStatic => _accessor.Static;
        public IReadOnlyDictionary<Int32, IUnit> UnitsStatic => _accessor.Units;
        public Int32[] ExplorerUnitsStatic => _accessor.ExplorerUnits;

        #endregion

        #region Interface

        IReadOnlyReactiveCollection<IUnitDataClient> IUnitsStateClient.Units => LL_Units.Interface;
        private ReactiveProperty<IUnitDataClient> Interface_Assist;
        IReadOnlyReactiveProperty<IUnitDataClient> IUnitsStateClient.Assist => Interface_Assist;
        IReadOnlyReactiveDictionary<Int32, Int32> IUnitsStateClient.LastTeam => LD_LastTeam.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetLastTeamProperty(Int32 key)
        {
            return LD_LastTeam.GetProperty(key);
        }

        #endregion

        #region Internal

        [JsonName("units")]
        public List<Internal_IUnitData> _Units = new List<Internal_IUnitData>();
        private InternalLogicList<Internal_IUnitData, IUnitData, IUnitDataClient> LL_Units = new InternalLogicList<Internal_IUnitData, IUnitData, IUnitDataClient>();
        [JsonName("assist")]
        public Internal_IUnitData _Assist;
        [JsonName("last_team")]
        public Dictionary<string, Int32> _LastTeam = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_LastTeam = new StructLogicDictionary<Int32, Int32>();

        #endregion

        #region Source

        ILogicList<IUnitData> IUnitsState.Units
        {
            get => LL_Units;
        }
        IUnitData IUnitsState.Assist
        {
            get => _Assist;
            set
            {
                var castValue = (Internal_IUnitData) value;
                if (_storage != null)
                {
                    castValue?.PreSave();
                    castValue?.InitData(DataId, _storage);
                }
                _Assist = castValue;
                _storage?.AddChange(this, DataId + $".assist.{castValue?.ToString()}", () => Interface_Assist.Value = castValue);
            }
        }
        ILogicDictionary<Int32, Int32> IUnitsState.LastTeam
        {
            get => LD_LastTeam;
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += LL_Units.ToString();
            result += _Assist?.ToString();
            result += LD_LastTeam.ToString();
            return result;
        }

        #endregion

    }
}
