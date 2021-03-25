using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
using UniRx;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core.Collections;
using VetsEngine.MetaLogic.Core;

using MetaLogic.Logic.Static;
using MetaLogic.Data;
using MetaLogic.Logic.State;
using VetsEngine.MetaLogic.Contracts;

namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IMemberBattleData : IMemberBattleDataEmulate, IMemberBattleData 
    , IInitStateData<IMemberBattleDataClient>, IInitStateData<IMemberBattleData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IMemberBattleDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            StaticId = client.StaticId;
            Position = client.Position;
            client.CurrentHp.Subscribe(x => _CurrentHp = x).AddTo(_disposables);
            client.Status.Subscribe(x => _Status = x).AddTo(_disposables);
            LL_TurnInfluence.Init(client.TurnInfluence, storage);
            LL_TurnBuffTypes.Init(client.TurnBuffTypes, storage);
            LL_TurnBuffs.Init(client.TurnBuffs, storage);
            client.TurnFamiliarSummoned.Subscribe(x => _TurnFamiliarSummoned = x).AddTo(_disposables);
            LD_Buffs.Init(client.Buffs, storage);
            LD_Abilities.Init(client.Abilities, storage);
            client.HpMax.Subscribe(x => _HpMax = x).AddTo(_disposables);
            client.Strength.Subscribe(x => _Strength = x).AddTo(_disposables);
            client.Initiative.Subscribe(x => _Initiative = x).AddTo(_disposables);
            client.MemberType.Subscribe(x => _MemberType = x).AddTo(_disposables);
            client.FamiliarSummoned.Subscribe(x => _FamiliarSummoned = x).AddTo(_disposables);
            client.Assist.Subscribe(x => _Assist = x).AddTo(_disposables);
        }

        public void InitData(IMemberBattleData data, ChangeStorage storage)
        {
            _storage = storage;
            StaticId = data.StaticId;
            Position = data.Position;
            CurrentHp = data.CurrentHp;
            Status = data.Status;
            LL_TurnInfluence.Init(data.TurnInfluence, storage);
            LL_TurnBuffTypes.Init(data.TurnBuffTypes, storage);
            LL_TurnBuffs.Init(data.TurnBuffs, storage);
            TurnFamiliarSummoned = data.TurnFamiliarSummoned;
            LD_Buffs.Init(data.Buffs, storage);
            LD_Abilities.Init(data.Abilities, storage);
            HpMax = data.HpMax;
            Strength = data.Strength;
            Initiative = data.Initiative;
            MemberType = data.MemberType;
            FamiliarSummoned = data.FamiliarSummoned;
            Assist = data.Assist;
        }

        #region Common

        public Int32 StaticId { get; private set; }
        public Int32 Position { get; private set; }
        private Single _CurrentHp;
        public Single  CurrentHp
        {
            get => _CurrentHp;
               set
            {
                 var backValue = _CurrentHp;
                _storage.AddBackAction(() => _CurrentHp = backValue);
                _CurrentHp = value;
            }
        }
        private UnitBattleStatus _Status;
        public UnitBattleStatus  Status
        {
            get => _Status;
               set
            {
                 var backValue = _Status;
                _storage.AddBackAction(() => _Status = backValue);
                _Status = value;
            }
        }
        private Boolean _TurnFamiliarSummoned;
        public Boolean  TurnFamiliarSummoned
        {
            get => _TurnFamiliarSummoned;
               set
            {
                 var backValue = _TurnFamiliarSummoned;
                _storage.AddBackAction(() => _TurnFamiliarSummoned = backValue);
                _TurnFamiliarSummoned = value;
            }
        }
        private BattleParamData _HpMax;
        public BattleParamData  HpMax
        {
            get => _HpMax;
               set
            {
                 var backValue = _HpMax;
                _storage.AddBackAction(() => _HpMax = backValue);
                _HpMax = value;
            }
        }
        private BattleParamData _Strength;
        public BattleParamData  Strength
        {
            get => _Strength;
               set
            {
                 var backValue = _Strength;
                _storage.AddBackAction(() => _Strength = backValue);
                _Strength = value;
            }
        }
        private BattleParamData _Initiative;
        public BattleParamData  Initiative
        {
            get => _Initiative;
               set
            {
                 var backValue = _Initiative;
                _storage.AddBackAction(() => _Initiative = backValue);
                _Initiative = value;
            }
        }
        private BattleMemberType _MemberType;
        public BattleMemberType  MemberType
        {
            get => _MemberType;
               set
            {
                 var backValue = _MemberType;
                _storage.AddBackAction(() => _MemberType = backValue);
                _MemberType = value;
            }
        }
        private Boolean _FamiliarSummoned;
        public Boolean  FamiliarSummoned
        {
            get => _FamiliarSummoned;
               set
            {
                 var backValue = _FamiliarSummoned;
                _storage.AddBackAction(() => _FamiliarSummoned = backValue);
                _FamiliarSummoned = value;
            }
        }
        private Boolean _Assist;
        public Boolean  Assist
        {
            get => _Assist;
               set
            {
                 var backValue = _Assist;
                _storage.AddBackAction(() => _Assist = backValue);
                _Assist = value;
            }
        }

        #endregion

        #region Interface

        IEmulateClientList<InfluenceTargetType> IMemberBattleDataEmulate.TurnInfluence => LL_TurnInfluence;
        IEmulateClientList<Int32> IMemberBattleDataEmulate.TurnBuffTypes => LL_TurnBuffTypes;
        IEmulateClientList<Int32> IMemberBattleDataEmulate.TurnBuffs => LL_TurnBuffs;
        IEmulateClientDictionary<Int32, IBuffBattleDataEmulate> IMemberBattleDataEmulate.Buffs => LD_Buffs;
        IEmulateClientDictionary<Int32, IAbilityBattleDataEmulate> IMemberBattleDataEmulate.Abilities => LD_Abilities;

        #endregion

        #region Internal

        ILogicList<InfluenceTargetType> IMemberBattleData.TurnInfluence => LL_TurnInfluence;
        ILogicList<Int32> IMemberBattleData.TurnBuffTypes => LL_TurnBuffTypes;
        ILogicList<Int32> IMemberBattleData.TurnBuffs => LL_TurnBuffs;
        ILogicDictionary<Int32, IBuffBattleData> IMemberBattleData.Buffs => LD_Buffs;
        ILogicDictionary<Int32, IAbilityBattleData> IMemberBattleData.Abilities => LD_Abilities;

        #endregion

        #region Source

        public ValueEmulateList<InfluenceTargetType> LL_TurnInfluence { get; } = new ValueEmulateList<InfluenceTargetType>();
        public ValueEmulateList<Int32> LL_TurnBuffTypes { get; } = new ValueEmulateList<Int32>();
        public ValueEmulateList<Int32> LL_TurnBuffs { get; } = new ValueEmulateList<Int32>();
        public InternalEmulateDictionary<Int32,Emulate_IBuffBattleData, IBuffBattleData, IBuffBattleDataEmulate> LD_Buffs { get; } = new InternalEmulateDictionary<Int32,Emulate_IBuffBattleData, IBuffBattleData, IBuffBattleDataEmulate>();
        public InternalEmulateDictionary<Int32,Emulate_IAbilityBattleData, IAbilityBattleData, IAbilityBattleDataEmulate> LD_Abilities { get; } = new InternalEmulateDictionary<Int32,Emulate_IAbilityBattleData, IAbilityBattleData, IAbilityBattleDataEmulate>();

        #endregion

    }
}
