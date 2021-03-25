using Pathfinding.Serialization.JsonFx;
using System;
using System.Linq;
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
using VetsEngine.MetaLogic.Contracts;

namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IUnitsState : IUnitsStateEmulate, IUnitsState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private UnitsAccessor _accessor;
        public void InitData(IUnitsStateClient client, UnitsAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            LL_Units.Init(client.Units, storage);
            client.Assist.Subscribe(x =>
            {
                _Assist = new Emulate_IUnitData();
                if (x != null)
                {
                    _Assist.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
            LD_LastTeam.Init(client.LastTeam, storage);
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

        #region Common


        #endregion

        #region Interface

        IEmulateClientList<IUnitDataEmulate> IUnitsStateEmulate.Units => LL_Units;
        IUnitDataEmulate IUnitsStateEmulate.Assist => _Assist;
        IEmulateClientDictionary<Int32, Int32> IUnitsStateEmulate.LastTeam => LD_LastTeam;

        #endregion

        #region Internal

        ILogicList<IUnitData> IUnitsState.Units => LL_Units;
        IUnitData IUnitsState.Assist
        {
            get => _Assist;
            set => _Assist = value as Emulate_IUnitData;
        }
        ILogicDictionary<Int32, Int32> IUnitsState.LastTeam => LD_LastTeam;

        #endregion

        #region Source

        public InternalEmulateList<Emulate_IUnitData, IUnitData, IUnitDataEmulate> LL_Units { get; } = new InternalEmulateList<Emulate_IUnitData, IUnitData, IUnitDataEmulate>();
        Emulate_IUnitData _Assist;
        public ValueEmulateDictionary<Int32, Int32> LD_LastTeam { get; } = new ValueEmulateDictionary<Int32, Int32>();

        #endregion

    }
}
