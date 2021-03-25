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
    internal class Internal_IUnitData : IUnitDataClient, IUnitData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "unitData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_Id = _Id;
            Interface_Shards = new ReactiveProperty<Int32>(_Shards);
            Interface_Stars = new ReactiveProperty<Int32>(_Stars);
            Interface_Exp = new ReactiveProperty<Int32>(_Exp);
            Interface_Level = new ReactiveProperty<Int32>(_Level);
            LD_Abilities?.Init($"{DataId}.abilities", storage, _Abilities);
            LD_PerkStars?.Init($"{DataId}.perks", storage, _PerkStars);
            LD_PerkCharges?.Init($"{DataId}.perk_charges", storage, _PerkCharges);
            LD_Equipment?.Init($"{DataId}.equipment", storage, _Equipment);
            Interface_EquipmentStars = new ReactiveProperty<Int32>(_EquipmentStars);
            LD_Buffs?.Init($"{DataId}.buffs", storage, _Buffs);
            Interface_ExplorerPosition = new ReactiveProperty<Int32>(_ExplorerPosition);
            Interface_Reserve = new ReactiveProperty<Boolean>(_Reserve);
            Interface_CurrentHp = new ReactiveProperty<Single>(_CurrentHp);
            Interface_FamiliarUnlock = new ReactiveProperty<Boolean>(_FamiliarUnlock);
            Interface_MissionCounter = new ReactiveProperty<Int32>(_MissionCounter);
        }
        public void PreSave()
        {
            _Abilities = LD_Abilities.Source;
            _PerkStars = LD_PerkStars.Source;
            _PerkCharges = LD_PerkCharges.Source;
            _Equipment = LD_Equipment.Source;
            _Buffs = LD_Buffs.Source;
        }

        #region Interface

        private Int32 Interface_Id;
        Int32 IUnitDataClient.Id => Interface_Id;
        private ReactiveProperty<Int32> Interface_Shards;
        IReadOnlyReactiveProperty<Int32> IUnitDataClient.Shards => Interface_Shards;
        private ReactiveProperty<Int32> Interface_Stars;
        IReadOnlyReactiveProperty<Int32> IUnitDataClient.Stars => Interface_Stars;
        private ReactiveProperty<Int32> Interface_Exp;
        IReadOnlyReactiveProperty<Int32> IUnitDataClient.Exp => Interface_Exp;
        private ReactiveProperty<Int32> Interface_Level;
        IReadOnlyReactiveProperty<Int32> IUnitDataClient.Level => Interface_Level;
        IReadOnlyReactiveDictionary<Int32, Int32> IUnitDataClient.Abilities => LD_Abilities.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetAbilitiesProperty(Int32 key)
        {
            return LD_Abilities.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int32> IUnitDataClient.PerkStars => LD_PerkStars.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetPerkStarsProperty(Int32 key)
        {
            return LD_PerkStars.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int32> IUnitDataClient.PerkCharges => LD_PerkCharges.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetPerkChargesProperty(Int32 key)
        {
            return LD_PerkCharges.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, Int32> IUnitDataClient.Equipment => LD_Equipment.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetEquipmentProperty(Int32 key)
        {
            return LD_Equipment.GetProperty(key);
        }
        private ReactiveProperty<Int32> Interface_EquipmentStars;
        IReadOnlyReactiveProperty<Int32> IUnitDataClient.EquipmentStars => Interface_EquipmentStars;
        IReadOnlyReactiveDictionary<Int32, Int32> IUnitDataClient.Buffs => LD_Buffs.Interface;
        public IReadOnlyReactiveProperty<Int32?> GetBuffsProperty(Int32 key)
        {
            return LD_Buffs.GetProperty(key);
        }
        private ReactiveProperty<Int32> Interface_ExplorerPosition;
        IReadOnlyReactiveProperty<Int32> IUnitDataClient.ExplorerPosition => Interface_ExplorerPosition;
        private ReactiveProperty<Boolean> Interface_Reserve;
        IReadOnlyReactiveProperty<Boolean> IUnitDataClient.Reserve => Interface_Reserve;
        private ReactiveProperty<Single> Interface_CurrentHp;
        IReadOnlyReactiveProperty<Single> IUnitDataClient.CurrentHp => Interface_CurrentHp;
        private ReactiveProperty<Boolean> Interface_FamiliarUnlock;
        IReadOnlyReactiveProperty<Boolean> IUnitDataClient.FamiliarUnlock => Interface_FamiliarUnlock;
        private ReactiveProperty<Int32> Interface_MissionCounter;
        IReadOnlyReactiveProperty<Int32> IUnitDataClient.MissionCounter => Interface_MissionCounter;

        #endregion

        #region Internal

        [JsonName("unit_id")]
        public Int32 _Id;
        [JsonName("shards")]
        public Int32 _Shards;
        [JsonName("stars")]
        public Int32 _Stars;
        [JsonName("exp")]
        public Int32 _Exp;
        [JsonName("level")]
        public Int32 _Level;
        [JsonName("abilities")]
        public Dictionary<string, Int32> _Abilities = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_Abilities = new StructLogicDictionary<Int32, Int32>();
        [JsonName("perks")]
        public Dictionary<string, Int32> _PerkStars = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_PerkStars = new StructLogicDictionary<Int32, Int32>();
        [JsonName("perk_charges")]
        public Dictionary<string, Int32> _PerkCharges = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_PerkCharges = new StructLogicDictionary<Int32, Int32>();
        [JsonName("equipment")]
        public Dictionary<string, Int32> _Equipment = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_Equipment = new StructLogicDictionary<Int32, Int32>();
        [JsonName("equipment_level")]
        public Int32 _EquipmentStars;
        [JsonName("buffs")]
        public Dictionary<string, Int32> _Buffs = new Dictionary<string, Int32>();
        private StructLogicDictionary<Int32, Int32> LD_Buffs = new StructLogicDictionary<Int32, Int32>();
        [JsonName("position")]
        public Int32 _ExplorerPosition;
        [JsonName("reserve")]
        public Boolean _Reserve;
        [JsonName("hp_current")]
        public Single _CurrentHp;
        [JsonName("has_familiar")]
        public Boolean _FamiliarUnlock;
        [JsonName("mission_counter")]
        public Int32 _MissionCounter;

        #endregion

        #region Source

        Int32 IUnitData.Id
        {
            get => _Id;
        }
        Int32 IUnitData.Shards
        {
            get => _Shards;
            set
            {
                if (_Shards == value)
                {
                    return;
                }
                _Shards = value;
                var dataId = DataId + $".shards.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Shards.Value = value; });
            }
        }
        Int32 IUnitData.Stars
        {
            get => _Stars;
            set
            {
                if (_Stars == value)
                {
                    return;
                }
                _Stars = value;
                var dataId = DataId + $".stars.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Stars.Value = value; });
            }
        }
        Int32 IUnitData.Exp
        {
            get => _Exp;
            set
            {
                if (_Exp == value)
                {
                    return;
                }
                _Exp = value;
                var dataId = DataId + $".exp.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Exp.Value = value; });
            }
        }
        Int32 IUnitData.Level
        {
            get => _Level;
            set
            {
                if (_Level == value)
                {
                    return;
                }
                _Level = value;
                var dataId = DataId + $".level.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Level.Value = value; });
            }
        }
        ILogicDictionary<Int32, Int32> IUnitData.Abilities
        {
            get => LD_Abilities;
        }
        ILogicDictionary<Int32, Int32> IUnitData.PerkStars
        {
            get => LD_PerkStars;
        }
        ILogicDictionary<Int32, Int32> IUnitData.PerkCharges
        {
            get => LD_PerkCharges;
        }
        ILogicDictionary<Int32, Int32> IUnitData.Equipment
        {
            get => LD_Equipment;
        }
        Int32 IUnitData.EquipmentStars
        {
            get => _EquipmentStars;
            set
            {
                if (_EquipmentStars == value)
                {
                    return;
                }
                _EquipmentStars = value;
                var dataId = DataId + $".equipment_level.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_EquipmentStars.Value = value; });
            }
        }
        ILogicDictionary<Int32, Int32> IUnitData.Buffs
        {
            get => LD_Buffs;
        }
        Int32 IUnitData.ExplorerPosition
        {
            get => _ExplorerPosition;
            set
            {
                if (_ExplorerPosition == value)
                {
                    return;
                }
                _ExplorerPosition = value;
                var dataId = DataId + $".position.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_ExplorerPosition.Value = value; });
            }
        }
        Boolean IUnitData.Reserve
        {
            get => _Reserve;
            set
            {
                if (_Reserve == value)
                {
                    return;
                }
                _Reserve = value;
                var dataId = DataId + $".reserve.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Reserve.Value = value; });
            }
        }
        Single IUnitData.CurrentHp
        {
            get => _CurrentHp;
            set
            {
                if (_CurrentHp == value)
                {
                    return;
                }
                _CurrentHp = value;
                var dataId = DataId + $".hp_current.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CurrentHp.Value = value; });
            }
        }
        Boolean IUnitData.FamiliarUnlock
        {
            get => _FamiliarUnlock;
            set
            {
                if (_FamiliarUnlock == value)
                {
                    return;
                }
                _FamiliarUnlock = value;
                var dataId = DataId + $".has_familiar.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_FamiliarUnlock.Value = value; });
            }
        }
        Int32 IUnitData.MissionCounter
        {
            get => _MissionCounter;
            set
            {
                if (_MissionCounter == value)
                {
                    return;
                }
                _MissionCounter = value;
                var dataId = DataId + $".mission_counter.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_MissionCounter.Value = value; });
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _Id;
            result += _Shards;
            result += _Stars;
            result += _Exp;
            result += _Level;
            result += LD_Abilities.ToString();
            result += LD_PerkStars.ToString();
            result += LD_PerkCharges.ToString();
            result += LD_Equipment.ToString();
            result += _EquipmentStars;
            result += LD_Buffs.ToString();
            result += _ExplorerPosition;
            result += _Reserve;
            result += _CurrentHp;
            result += _FamiliarUnlock;
            result += _MissionCounter;
            return result;
        }

        #endregion

    }
}
