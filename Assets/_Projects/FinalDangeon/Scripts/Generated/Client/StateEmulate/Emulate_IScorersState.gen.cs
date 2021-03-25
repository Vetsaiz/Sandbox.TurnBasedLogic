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
    internal class Emulate_IScorersState : IScorersStateEmulate, IScorersState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private ScorersAccessor _accessor;
        public void InitData(IScorersStateClient client, ScorersAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            LD_Values.Init(client.Values, storage);
            LD_BattleValues.Init(client.BattleValues, storage);
            LD_ImpactValues.Init(client.ImpactValues, storage);
        }


        #region Queries

        public IScorer GetScorer(System.String argKey)
        {
            return _accessor.GetScorer(argKey);
        }
        public IScorerStatic StaticStatic => _accessor.Static;
        public Int32 StaminaIdStatic => _accessor.StaminaId;
        public Int32 ManaIdStatic => _accessor.ManaId;

        #endregion

        #region Common


        #endregion

        #region Interface

        IEmulateClientDictionary<Int32, Int64> IScorersStateEmulate.Values => LD_Values;
        IEmulateClientDictionary<Int32, Int64> IScorersStateEmulate.BattleValues => LD_BattleValues;
        IEmulateClientDictionary<Int32, Int64> IScorersStateEmulate.ImpactValues => LD_ImpactValues;

        #endregion

        #region Internal

        ILogicDictionary<Int32, Int64> IScorersState.Values => LD_Values;
        ILogicDictionary<Int32, Int64> IScorersState.BattleValues => LD_BattleValues;
        ILogicDictionary<Int32, Int64> IScorersState.ImpactValues => LD_ImpactValues;

        #endregion

        #region Source

        public ValueEmulateDictionary<Int32, Int64> LD_Values { get; } = new ValueEmulateDictionary<Int32, Int64>();
        public ValueEmulateDictionary<Int32, Int64> LD_BattleValues { get; } = new ValueEmulateDictionary<Int32, Int64>();
        public ValueEmulateDictionary<Int32, Int64> LD_ImpactValues { get; } = new ValueEmulateDictionary<Int32, Int64>();

        #endregion

    }
}
