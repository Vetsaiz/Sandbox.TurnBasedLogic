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
namespace MetaLogic.Client.Internal.State
{
    internal class Emulate_IBattleState : IBattleStateEmulate, IBattleState 
    {
        private List<IDisposable> _disposables = new List<IDisposable>();
        private ChangeStorage _storage;
        private BattleAccessor _accessor;
        public void InitData(IBattleStateClient client, BattleAccessor accessor, ChangeStorage storage)
        {
            _storage = storage;
            _accessor = accessor;
            client.Data.Subscribe(x =>
            {
                _Data = new Emulate_IBattleStateData();
                if (x != null)
                {
                    _Data.InitData(x, storage);
                }
            }
            ).AddTo(_disposables);
        }


        #region Queries

        public IBattleStatic StaticStatic => _accessor.Static;

        #endregion

        #region Common


        #endregion

        #region Interface

        IBattleStateDataEmulate IBattleStateEmulate.Data => _Data;

        #endregion

        #region Internal

        IBattleStateData IBattleState.Data
        {
            get => _Data;
            set => _Data = value as Emulate_IBattleStateData;
        }

        #endregion

        #region Source

        Emulate_IBattleStateData _Data;

        #endregion

    }
}
