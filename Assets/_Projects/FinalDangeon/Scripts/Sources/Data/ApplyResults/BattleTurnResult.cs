using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MetaLogic.Data
{

    public class BattleTurnResult
    {
        public BattleTurnResultType Type;
        public AbilityResult AbilityResult;
        public OtherTurnResult OtherTurnResult;
    }

    public class OtherTurnResult
    {
        public int Index;

        //public List<Action> Actions = new List<Action>();

        //public void Execute()
        //{
        //    Debug.Log($"Execute frame ability {ToString()}");
        //    foreach (var temp in Actions)
        //    {
        //        temp();
        //    }
        //}

        public FrameOther[] Frames;

        public override string ToString()
        {
            //return $"Index = {Index} Type = OtherTurnResult";

            return $"Index = {Index}" +
                   $"Frames = \n{string.Join("\n", Frames.Select(x => x.ToString()))}";
        }
    }

    public class FrameOther
    {
        public BattleTurnResultType ResultType;
        public int ParentIndex;
        public int Index;
        public float Time;
        public List<Action> Actions = new List<Action>();

        public void Execute()
        {
            Debug.Log($"Execute frame ability {ToString()}");
            foreach (var temp in Actions)
            {
                temp();
            }
        }

        public override string ToString()
        {
            return $"Index = {ParentIndex}.{Index}, Time = {Time}";
        }
    }

    public class AbilityResult
    {
        public int AbilityId;
        public int OwnerId;
        public int? MainTarget;
        public FrameAbility[] Frames;
        public int Index;

        public override string ToString()
        {
            return $"Index = {Index} AbilityId = {AbilityId} OwnerId = {OwnerId} MainTarget = {MainTarget}" +
                   $"Frames = \n{string.Join("\n" , Frames.Select(x=> x.ToString()))}";
        }
    }

    public class FrameAbility
    {
        public int ParentIndex;
        public int Index;

        public BattleTurnResultType ResultType;

        public bool FamiliarAnimStart;
        public float Time;
        public string UnityId;
        public HashSet<int> AdditionalTarget = new HashSet<int>();
        public float? ShellDuration;

        public List<Action> Actions = new List<Action>();

        public void Execute()
        {
            Debug.Log($"Execute frame ability:  {ToString()}");
            foreach (var temp in Actions)
            {
                temp();
            }
        }

        public override string ToString()
        {
            return $"Index = {ParentIndex}.{Index}, Time = {Time}, FamiliarAnimStart = {FamiliarAnimStart}, ShellDuration = {ShellDuration}, UnityId = {UnityId}, AdditionalTargets = {string.Join("\n", AdditionalTarget.Select(x=> x.ToString()))}";
        }
    }

    public enum BattleTurnResultType
    {
        StartTurn,
        ActiveAbility,
        Buff,
        PassiveAbility,
        EndTurn
    }
}
