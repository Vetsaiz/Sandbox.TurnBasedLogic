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
using VetsEngine.MetaLogic.Core.Collections;
namespace MetaLogic.Client.Internal.State
{
    internal class Internal_IMemberBattleData : IMemberBattleDataClient, IMemberBattleData 
    , IInitStateData 
    {
        private ChangeStorage _storage;
        private string DataId = "memberBattleData";
        public void InitData(string root, ChangeStorage storage)
        {
            _storage = storage;
            DataId = $"{root}.{DataId}";
            Interface_StaticId = _StaticId;
            Interface_Position = _Position;
            Interface_CurrentHp = new ReactiveProperty<Single>(_CurrentHp);
            Interface_Status = new ReactiveProperty<UnitBattleStatus>(_Status);
            LL_TurnInfluence?.Init($"{DataId}.turn_influence", storage, _TurnInfluence);
            LL_TurnBuffTypes?.Init($"{DataId}.turn_buff_types", storage, _TurnBuffTypes);
            LL_TurnBuffs?.Init($"{DataId}.turn_buffs", storage, _TurnBuffs);
            Interface_TurnFamiliarSummoned = new ReactiveProperty<Boolean>(_TurnFamiliarSummoned);
            LD_Buffs?.Init($"{DataId}.buffs", storage, _Buffs);
            LD_Abilities?.Init($"{DataId}.abilities", storage, _Abilities);
            Interface_HpMax = new ReactiveProperty<BattleParamData>(_HpMax);
            Interface_Strength = new ReactiveProperty<BattleParamData>(_Strength);
            Interface_Initiative = new ReactiveProperty<BattleParamData>(_Initiative);
            Interface_MemberType = new ReactiveProperty<BattleMemberType>(_MemberType);
            Interface_FamiliarSummoned = new ReactiveProperty<Boolean>(_FamiliarSummoned);
            Interface_Assist = new ReactiveProperty<Boolean>(_Assist);
        }
        public void PreSave()
        {
            foreach (var temp in LL_TurnInfluence)
            {
            }
            foreach (var temp in LL_TurnBuffTypes)
            {
            }
            foreach (var temp in LL_TurnBuffs)
            {
            }
            foreach (var temp in LD_Buffs.Source)
            {
                temp.Value.PreSave();
            }
            _Buffs = LD_Buffs.Source;
            foreach (var temp in LD_Abilities.Source)
            {
                temp.Value.PreSave();
            }
            _Abilities = LD_Abilities.Source;
        }

        #region Interface

        private Int32 Interface_StaticId;
        Int32 IMemberBattleDataClient.StaticId => Interface_StaticId;
        private Int32 Interface_Position;
        Int32 IMemberBattleDataClient.Position => Interface_Position;
        private ReactiveProperty<Single> Interface_CurrentHp;
        IReadOnlyReactiveProperty<Single> IMemberBattleDataClient.CurrentHp => Interface_CurrentHp;
        private ReactiveProperty<UnitBattleStatus> Interface_Status;
        IReadOnlyReactiveProperty<UnitBattleStatus> IMemberBattleDataClient.Status => Interface_Status;
        IReadOnlyReactiveCollection<InfluenceTargetType> IMemberBattleDataClient.TurnInfluence => LL_TurnInfluence.Interface;
        IReadOnlyReactiveCollection<Int32> IMemberBattleDataClient.TurnBuffTypes => LL_TurnBuffTypes.Interface;
        IReadOnlyReactiveCollection<Int32> IMemberBattleDataClient.TurnBuffs => LL_TurnBuffs.Interface;
        private ReactiveProperty<Boolean> Interface_TurnFamiliarSummoned;
        IReadOnlyReactiveProperty<Boolean> IMemberBattleDataClient.TurnFamiliarSummoned => Interface_TurnFamiliarSummoned;
        IReadOnlyReactiveDictionary<Int32, IBuffBattleDataClient> IMemberBattleDataClient.Buffs => LD_Buffs.Interface;
        public IReadOnlyReactiveProperty<IBuffBattleDataClient> GetBuffsProperty(Int32 key)
        {
            return LD_Buffs.GetProperty(key);
        }
        IReadOnlyReactiveDictionary<Int32, IAbilityBattleDataClient> IMemberBattleDataClient.Abilities => LD_Abilities.Interface;
        public IReadOnlyReactiveProperty<IAbilityBattleDataClient> GetAbilitiesProperty(Int32 key)
        {
            return LD_Abilities.GetProperty(key);
        }
        private ReactiveProperty<BattleParamData> Interface_HpMax;
        IReadOnlyReactiveProperty<BattleParamData> IMemberBattleDataClient.HpMax => Interface_HpMax;
        private ReactiveProperty<BattleParamData> Interface_Strength;
        IReadOnlyReactiveProperty<BattleParamData> IMemberBattleDataClient.Strength => Interface_Strength;
        private ReactiveProperty<BattleParamData> Interface_Initiative;
        IReadOnlyReactiveProperty<BattleParamData> IMemberBattleDataClient.Initiative => Interface_Initiative;
        private ReactiveProperty<BattleMemberType> Interface_MemberType;
        IReadOnlyReactiveProperty<BattleMemberType> IMemberBattleDataClient.MemberType => Interface_MemberType;
        private ReactiveProperty<Boolean> Interface_FamiliarSummoned;
        IReadOnlyReactiveProperty<Boolean> IMemberBattleDataClient.FamiliarSummoned => Interface_FamiliarSummoned;
        private ReactiveProperty<Boolean> Interface_Assist;
        IReadOnlyReactiveProperty<Boolean> IMemberBattleDataClient.Assist => Interface_Assist;

        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _StaticId;
        [JsonName("position")]
        public Int32 _Position;
        [JsonName("current_hp")]
        public Single _CurrentHp;
        [JsonName("status")]
        public UnitBattleStatus _Status;
        [JsonName("turn_influence")]
        public List<InfluenceTargetType> _TurnInfluence = new List<InfluenceTargetType>();
        private ValueLogicList<InfluenceTargetType> LL_TurnInfluence = new ValueLogicList<InfluenceTargetType>();
        [JsonName("turn_buff_types")]
        public List<Int32> _TurnBuffTypes = new List<Int32>();
        private ValueLogicList<Int32> LL_TurnBuffTypes = new ValueLogicList<Int32>();
        [JsonName("turn_buffs")]
        public List<Int32> _TurnBuffs = new List<Int32>();
        private ValueLogicList<Int32> LL_TurnBuffs = new ValueLogicList<Int32>();
        [JsonName("familiar_summoned")]
        public Boolean _TurnFamiliarSummoned;
        [JsonName("buffs")]
        public Dictionary<string, Internal_IBuffBattleData> _Buffs = new Dictionary<string, Internal_IBuffBattleData>();
        private InternalLogicDictionary<Int32, Internal_IBuffBattleData, IBuffBattleData, IBuffBattleDataClient> LD_Buffs = new InternalLogicDictionary<Int32, Internal_IBuffBattleData, IBuffBattleData, IBuffBattleDataClient>();
        [JsonName("abilities")]
        public Dictionary<string, Internal_IAbilityBattleData> _Abilities = new Dictionary<string, Internal_IAbilityBattleData>();
        private InternalLogicDictionary<Int32, Internal_IAbilityBattleData, IAbilityBattleData, IAbilityBattleDataClient> LD_Abilities = new InternalLogicDictionary<Int32, Internal_IAbilityBattleData, IAbilityBattleData, IAbilityBattleDataClient>();
        [JsonName("max_hp")]
        public BattleParamData _HpMax;
        [JsonName("strength")]
        public BattleParamData _Strength;
        [JsonName("initiative")]
        public BattleParamData _Initiative;
        [JsonName("member_type")]
        public BattleMemberType _MemberType;
        [JsonName("familiar_summoned")]
        public Boolean _FamiliarSummoned;
        [JsonName("assist")]
        public Boolean _Assist;

        #endregion

        #region Source

        Int32 IMemberBattleData.StaticId
        {
            get => _StaticId;
        }
        Int32 IMemberBattleData.Position
        {
            get => _Position;
        }
        Single IMemberBattleData.CurrentHp
        {
            get => _CurrentHp;
            set
            {
                _CurrentHp = value;
                var dataId = DataId + $".current_hp.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, ()=> {Logger.ChangeImmediately($"Apply {dataId}"); Interface_CurrentHp.SetValueAndForceNotify(value);});
            }
        }
        UnitBattleStatus IMemberBattleData.Status
        {
            get => _Status;
            set
            {
                if (_Status == value)
                {
                    return;
                }
                _Status = value;
                var dataId = DataId + $".status.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Status.Value = value; });
            }
        }
        ILogicList<InfluenceTargetType> IMemberBattleData.TurnInfluence
        {
            get => LL_TurnInfluence;
        }
        ILogicList<Int32> IMemberBattleData.TurnBuffTypes
        {
            get => LL_TurnBuffTypes;
        }
        ILogicList<Int32> IMemberBattleData.TurnBuffs
        {
            get => LL_TurnBuffs;
        }
        Boolean IMemberBattleData.TurnFamiliarSummoned
        {
            get => _TurnFamiliarSummoned;
            set
            {
                if (_TurnFamiliarSummoned == value)
                {
                    return;
                }
                _TurnFamiliarSummoned = value;
                var dataId = DataId + $".familiar_summoned.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_TurnFamiliarSummoned.Value = value; });
            }
        }
        ILogicDictionary<Int32, IBuffBattleData> IMemberBattleData.Buffs
        {
            get => LD_Buffs;
        }
        ILogicDictionary<Int32, IAbilityBattleData> IMemberBattleData.Abilities
        {
            get => LD_Abilities;
        }
        BattleParamData IMemberBattleData.HpMax
        {
            get => _HpMax;
            set
            {
                if (_HpMax == value)
                {
                    return;
                }
                _HpMax = value;
                var dataId = DataId + $".max_hp.{value?.ToString()}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_HpMax.Value = value; });
            }
        }
        BattleParamData IMemberBattleData.Strength
        {
            get => _Strength;
            set
            {
                if (_Strength == value)
                {
                    return;
                }
                _Strength = value;
                var dataId = DataId + $".strength.{value?.ToString()}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Strength.Value = value; });
            }
        }
        BattleParamData IMemberBattleData.Initiative
        {
            get => _Initiative;
            set
            {
                if (_Initiative == value)
                {
                    return;
                }
                _Initiative = value;
                var dataId = DataId + $".initiative.{value?.ToString()}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Initiative.Value = value; });
            }
        }
        BattleMemberType IMemberBattleData.MemberType
        {
            get => _MemberType;
            set
            {
                if (_MemberType == value)
                {
                    return;
                }
                _MemberType = value;
                var dataId = DataId + $".member_type.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_MemberType.Value = value; });
            }
        }
        Boolean IMemberBattleData.FamiliarSummoned
        {
            get => _FamiliarSummoned;
            set
            {
                if (_FamiliarSummoned == value)
                {
                    return;
                }
                _FamiliarSummoned = value;
                var dataId = DataId + $".familiar_summoned.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_FamiliarSummoned.Value = value; });
            }
        }
        Boolean IMemberBattleData.Assist
        {
            get => _Assist;
            set
            {
                if (_Assist == value)
                {
                    return;
                }
                _Assist = value;
                var dataId = DataId + $".assist.{value.ToString(CultureInfo.InvariantCulture)}";
                _storage?.AddChange(this, dataId, () => {Logger.ChangeImmediately($"Apply {dataId}"); Interface_Assist.Value = value; });
            }
        }

        #endregion

        #region Hash

        public override string ToString()
        {
            var result = "";
            result += _StaticId;
            result += _Position;
            result += _CurrentHp;
            result += _Status;
            result += LL_TurnInfluence.ToString();
            result += LL_TurnBuffTypes.ToString();
            result += LL_TurnBuffs.ToString();
            result += _TurnFamiliarSummoned;
            result += LD_Buffs.ToString();
            result += LD_Abilities.ToString();
            result += _HpMax?.ToString();
            result += _Strength?.ToString();
            result += _Initiative?.ToString();
            result += _MemberType;
            result += _FamiliarSummoned;
            result += _Assist;
            return result;
        }

        #endregion

    }
}
