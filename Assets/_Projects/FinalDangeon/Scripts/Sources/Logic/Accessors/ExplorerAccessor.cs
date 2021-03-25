using System;
using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using MetaLogic.Logic.AdditionalLogic;
using MetaLogic.Logic.Controllers;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;
using UnityEngine;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class ExplorerAccessor 
    {
        public IExplorerState State { get; set; }
        [Query]
        public IExplorerStatic Static { get; set; }
        public IStateFactory Factory { get; set; }

        [Query]
        public IReadOnlyDictionary<int, IInteractiveObject> Objects => Static.Objects;

        [Query]
        public IReadOnlyDictionary<int, IRoom> Rooms => Static.Rooms;

        [Query]
        public IReadOnlyDictionary<int, IStage> Stages => Static.Stages;

        [Query]
        public IReadOnlyDictionary<int, IZone> Zones => Static.Zones;

        public IExplorerActivation GetActivation(int id, int indexActivation)
        {
            return Static.Objects[id].Activations[indexActivation];
        }

        public IImpact GetRoomImpact(int id)
        {
            return Static.Rooms[id].Impact;
        }

        public IImpact GetStageImpact(int id, bool b)
        {
            if (b) {
                return Static.Stages[id].ImpactInit;
            }
            else {
                return Static.Stages[id].ImpactFinish;
            }
        }
        
        public IStageData GetStage(int dataStageId)
        {
            if (!Static.Stages.ContainsKey(dataStageId))
            {
                throw new Exception($"Не существует этапа с id = {dataStageId}");
            }

            if (!State.Stages.ContainsKey(dataStageId))
            {
                State.Stages[dataStageId] = Factory.CreateStage(dataStageId);
            }
            return State.Stages[dataStageId];
        }

        public int CurrentStage => State.StageId;

        public void SetCurrentStage(int stage)
        {
            if (State.IsRun)
            {
                throw new Exception("Attempt to start the explore stage 2 times");
            }
            State.StageId = stage;
            State.Position = null;
            State.IsRun = true;
        }

        public void ClearCurrentStage()
        {
            if (!State.IsRun)
            {
                throw new Exception("Attempt to complete the explore stage 2 times");
            }
            State.Inventory.Clear();
            State.StageId = -1;
            State.IsRun = false;
            State.Position = null;
        }

        public void SetInteractiveObject(int interactive, IImpactInteractiveObject impact)
        {
            var data = InteractiveObjectData.Create(impact);

            GetStage(CurrentStage).ObjectAvailibility[interactive] = data;
        }


        public InteractiveObjectData GetInteractiveData(int interactiveId)
        {
            var stageId = GetStageForInteractive(interactiveId);
            if (GetStage(stageId).ObjectAvailibility.TryGetValue(interactiveId, out var test))
            {
                return test;
            }
            return InteractiveObjectData.Create(Static.Objects[interactiveId]);
        }

        public int GetStageForInteractive(int interactiveId)
        {
            var staticObject = Static.Objects[interactiveId];
            var staticRoom = Static.Rooms[staticObject.RoomId];
            return staticRoom.StageId;
        }

        [Query]
        public int GetCountInteractive(int stageId)
        {
            var rooms = Static.Rooms.Values.Where(x => x.StageId == stageId).Select(x=> x.Id);
            var count = Static.Objects.Count(x => rooms.Contains(x.Value.RoomId));
            return count;
        }
        
        public BattleParamData CalculateMaxHp(int mobId, FormulaController formulaLogic)
        {
            var mob = GetMob(mobId);
            return new BattleParamData() {Value = (float)formulaLogic.Calculate(mob.HpMax)};
        }

        public BattleParamData CalculateStreath(int mobId, FormulaController formulaLogic)
        {
            var mob = GetMob(mobId);
            return new BattleParamData() { Value = (float)formulaLogic.Calculate(mob.Strength) };
        }

        public BattleParamData CalculateInitiative(int mobId, FormulaController formulaLogic)
        {
            var mob = GetMob(mobId);
            return new BattleParamData() { Value = (float)formulaLogic.Calculate(mob.Initiative) };
        }

        public IMob GetMob(int mobId)
        {
            //var data = State.Data.Enemies[mobId];
            var staticData = Static.Mobs[mobId];
            return staticData;
        }

        public void SpendScorer(int scorerId, int value)
        {
            var stage = GetStage(CurrentStage);
            stage.Values.TryGetValue(scorerId, out var scorer);
            stage.Values[scorerId] = Mathf.Max((int)scorer - value, 0);
        }
    }
}
