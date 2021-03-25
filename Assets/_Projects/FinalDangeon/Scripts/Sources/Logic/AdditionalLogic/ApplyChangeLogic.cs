using System;
using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Data;
using VetsEngine.MetaLogic.Contracts;


namespace MetaLogic.Logic.AdditionalLogic
{
    [LogicElement(ElementType.Logic)]
    internal partial class ApplyChangeLogic
    {
        public IApplyManager _manager;
        public ContextLogic _context;

        private readonly List<BattleTurnResult> _battleBatches = new List<BattleTurnResult>();
        private readonly List<CutSceneResult> _commonBatches = new List<CutSceneResult>();
        private readonly List<FrameAbility> _frames = new List<FrameAbility>();
        private readonly List<FrameOther> _framesOther = new List<FrameOther>();

        public FrameOther Other { get; set; } = new FrameOther();
        public FrameAbility Data { get; set; } = new FrameAbility { Time = 0, FamiliarAnimStart = false };
        public CutSceneResult Common { get; set; } = new CutSceneResult();

        public int? _mainTarget { get; set; }

        public void BatchAbilityInFrame()
        {
            var type = _context.TurnType;
            Data.ParentIndex = _battleBatches.Count;
            Data.Index = _frames.Count;
            Data.Actions.Add(_manager.Batch(()=> $"Type = {type} {Data}"));
            _frames.Add(Data);
            Data = new FrameAbility {FamiliarAnimStart = false, Time = Data.Time, ShellDuration = null};
        }

        public void SetAbilityTarget(int target)
        {
            if (!_mainTarget.HasValue)
            {
                _mainTarget = target;
            }
            else
            {
                Data.AdditionalTarget.Add(target);
            }
        }
        
        public void BatchBattleAbility(int ownerId, int abilityId)
        {
            if (_context.TurnType != BattleTurnResultType.ActiveAbility && _context.TurnType != BattleTurnResultType.PassiveAbility)
            {
                throw new Exception($"Invalid write type AbilityResult. TurnType = {_context.TurnType}");
            }

            BatchAbilityInFrame();

            //Logger.Log($"{Logger.GetTabString()}Write apply result ability. type = {_context.TurnType} ownerId = {ownerId} mainTarget = {_mainTarget} abilityId = {abilityId}");
            _battleBatches.Add(new BattleTurnResult
            {
                Type = _context.TurnType,
                AbilityResult = new AbilityResult
                {
                    Index = _battleBatches.Count,
                    OwnerId = ownerId,
                    MainTarget = _mainTarget,
                    AbilityId = abilityId,
                    Frames = _frames.ToArray()
                },
            });
            _mainTarget = null;
            Data = new FrameAbility {FamiliarAnimStart = false, Time = 0, ShellDuration = null};
            _frames.Clear();
        }

        [ClientAPI]
        public void BatchAction(Action callback)
        {
            if (_manager.IsManual)
            {
                if (_context.BattleMode)
                {
                    if (_context.TurnType == BattleTurnResultType.ActiveAbility || _context.TurnType == BattleTurnResultType.PassiveAbility)
                    {
                        Data.Actions.Add(callback);
                    }
                    else
                    {
                        Other.Actions.Add(callback);
                    }
                }
                else
                {
                    Common.Actions.Add(callback);
                }
            }
            else
            {
                callback();
            }
        }

        public void BatchOtherInFrame()
        {
            var type = _context.TurnType;
            Other.ParentIndex = _battleBatches.Count;
            Other.Index = _framesOther.Count;
            Other.Actions.Add(_manager.Batch(() => $"Type = {type} {Other}"));
            _framesOther.Add(Other);
            Other = new FrameOther();
        }


        public void BatchBattle()
        {
            if (_context.TurnType == BattleTurnResultType.ActiveAbility || _context.TurnType == BattleTurnResultType.PassiveAbility)
            {
                throw new Exception($"Invalid write type OtherTurnResult. TurnType = {_context.TurnType}");
            }
            BatchOtherInFrame();
            
            _battleBatches.Add(new BattleTurnResult
            {
                OtherTurnResult = new OtherTurnResult
                {
                    Index = _battleBatches.Count,
                    Frames = _framesOther.ToArray(),
                },
                Type = _context.TurnType
            });
            Other = new FrameOther();
            _framesOther.Clear();
        }

        public void BatchCutScene(float time)
        {
            Common.Index = _commonBatches.Count;
            Common.Actions.Add(_manager.Batch(() => Common.ToString()));
            _commonBatches.Add(Common);

            Common = new CutSceneResult
            {
                Time = time
            };
        }

        [ClientAPI]
        public CutSceneResult[] GetCutSceneResults()
        {
            var array = _commonBatches.ToArray();
            _commonBatches.Clear();
            return array;
        }

        [ClientAPI]
        public BattleTurnResult[] GetCallbacks()
        {
            var array = _battleBatches.ToArray();
            _battleBatches.Clear();
            return array;
        }

        public void SetMode(ApplyMode mode)
        {
            _manager.SetMode(mode);
        }
    }
}
