using System;
using System.Collections.Generic;
using UnityEngine;

namespace MetaLogic.Data
{

    public class CutSceneResult
    {
        public List<Action> Actions = new List<Action>();
        public int Index;
        public float Time;


        public void Execute()
        {
            Debug.Log($"Execute common:  {ToString()}");
            foreach (var temp in Actions)
            {
                temp();
            }
        }

        public override string ToString()
        {
            return $"Index = {Index}, Time = {Time}";
        }

    }
}
