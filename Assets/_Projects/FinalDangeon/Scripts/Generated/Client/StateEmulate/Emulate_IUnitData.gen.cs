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
    internal class Emulate_IUnitData : IUnitDataEmulate, IUnitData 
    , IInitStateData<IUnitDataClient>, IInitStateData<IUnitData>
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        public void InitData(IUnitDataClient client, ChangeStorage storage)
        {
            _storage = storage;
            Id = client.Id;
            client.Shards.Subscribe(x => _Shards = x).AddTo(_disposables);
            client.Stars.Subscribe(x => _Stars = x).AddTo(_disposables);
            client.Exp.Subscribe(x => _Exp = x).AddTo(_disposables);
            client.Level.Subscribe(x => _Level = x).AddTo(_disposables);
            LD_Abilities.Init(client.Abilities, storage);
            LD_PerkStars.Init(client.PerkStars, storage);
            LD_PerkCharges.Init(client.PerkCharges, storage);
            LD_Equipment.Init(client.Equipment, storage);
            client.EquipmentStars.Subscribe(x => _EquipmentStars = x).AddTo(_disposables);
            LD_Buffs.Init(client.Buffs, storage);
            client.ExplorerPosition.Subscribe(x => _ExplorerPosition = x).AddTo(_disposables);
            client.Reserve.Subscribe(x => _Reserve = x).AddTo(_disposables);
            client.CurrentHp.Subscribe(x => _CurrentHp = x).AddTo(_disposables);
            client.FamiliarUnlock.Subscribe(x => _FamiliarUnlock = x).AddTo(_disposables);
            client.MissionCounter.Subscribe(x => _MissionCounter = x).AddTo(_disposables);
        }

        public void InitData(IUnitData data, ChangeStorage storage)
        {
            _storage = storage;
            Id = data.Id;
            Shards = data.Shards;
            Stars = data.Stars;
            Exp = data.Exp;
            Level = data.Level;
            LD_Abilities.Init(data.Abilities, storage);
            LD_PerkStars.Init(data.PerkStars, storage);
            LD_PerkCharges.Init(data.PerkCharges, storage);
            LD_Equipment.Init(data.Equipment, storage);
            EquipmentStars = data.EquipmentStars;
            LD_Buffs.Init(data.Buffs, storage);
            ExplorerPosition = data.ExplorerPosition;
            Reserve = data.Reserve;
            CurrentHp = data.CurrentHp;
            FamiliarUnlock = data.FamiliarUnlock;
            MissionCounter = data.MissionCounter;
        }

        #region Common

        public Int32 Id { get; private set; }
        private Int32 _Shards;
        public Int32  Shards
        {
            get => _Shards;
               set
            {
                 var backValue = _Shards;
                _storage.AddBackAction(() => _Shards = backValue);
                _Shards = value;
            }
        }
        private Int32 _Stars;
        public Int32  Stars
        {
            get => _Stars;
               set
            {
                 var backValue = _Stars;
                _storage.AddBackAction(() => _Stars = backValue);
                _Stars = value;
            }
        }
        private Int32 _Exp;
        public Int32  Exp
        {
            get => _Exp;
               set
            {
                 var backValue = _Exp;
                _storage.AddBackAction(() => _Exp = backValue);
                _Exp = value;
            }
        }
        private Int32 _Level;
        public Int32  Level
        {
            get => _Level;
               set
            {
                 var backValue = _Level;
                _storage.AddBackAction(() => _Level = backValue);
                _Level = value;
            }
        }
        private Int32 _EquipmentStars;
        public Int32  EquipmentStars
        {
            get => _EquipmentStars;
               set
            {
                 var backValue = _EquipmentStars;
                _storage.AddBackAction(() => _EquipmentStars = backValue);
                _EquipmentStars = value;
            }
        }
        private Int32 _ExplorerPosition;
        public Int32  ExplorerPosition
        {
            get => _ExplorerPosition;
               set
            {
                 var backValue = _ExplorerPosition;
                _storage.AddBackAction(() => _ExplorerPosition = backValue);
                _ExplorerPosition = value;
            }
        }
        private Boolean _Reserve;
        public Boolean  Reserve
        {
            get => _Reserve;
               set
            {
                 var backValue = _Reserve;
                _storage.AddBackAction(() => _Reserve = backValue);
                _Reserve = value;
            }
        }
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
        private Boolean _FamiliarUnlock;
        public Boolean  FamiliarUnlock
        {
            get => _FamiliarUnlock;
               set
            {
                 var backValue = _FamiliarUnlock;
                _storage.AddBackAction(() => _FamiliarUnlock = backValue);
                _FamiliarUnlock = value;
            }
        }
        private Int32 _MissionCounter;
        public Int32  MissionCounter
        {
            get => _MissionCounter;
               set
            {
                 var backValue = _MissionCounter;
                _storage.AddBackAction(() => _MissionCounter = backValue);
                _MissionCounter = value;
            }
        }

        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, Int32> IUnitDataEmulate.Abilities => LD_Abilities;
        IEmulateClientDictionary<Int32, Int32> IUnitDataEmulate.PerkStars => LD_PerkStars;
        IEmulateClientDictionary<Int32, Int32> IUnitDataEmulate.PerkCharges => LD_PerkCharges;
        IEmulateClientDictionary<Int32, Int32> IUnitDataEmulate.Equipment => LD_Equipment;
        IEmulateClientDictionary<Int32, Int32> IUnitDataEmulate.Buffs => LD_Buffs;

        #endregion

        #region Internal

        ILogicDictionary<Int32, Int32> IUnitData.Abilities => LD_Abilities;
        ILogicDictionary<Int32, Int32> IUnitData.PerkStars => LD_PerkStars;
        ILogicDictionary<Int32, Int32> IUnitData.PerkCharges => LD_PerkCharges;
        ILogicDictionary<Int32, Int32> IUnitData.Equipment => LD_Equipment;
        ILogicDictionary<Int32, Int32> IUnitData.Buffs => LD_Buffs;

        #endregion

        #region Source

        public ValueEmulateDictionary<Int32, Int32> LD_Abilities { get; } = new ValueEmulateDictionary<Int32, Int32>();
        public ValueEmulateDictionary<Int32, Int32> LD_PerkStars { get; } = new ValueEmulateDictionary<Int32, Int32>();
        public ValueEmulateDictionary<Int32, Int32> LD_PerkCharges { get; } = new ValueEmulateDictionary<Int32, Int32>();
        public ValueEmulateDictionary<Int32, Int32> LD_Equipment { get; } = new ValueEmulateDictionary<Int32, Int32>();
        public ValueEmulateDictionary<Int32, Int32> LD_Buffs { get; } = new ValueEmulateDictionary<Int32, Int32>();

        #endregion

    }
}
