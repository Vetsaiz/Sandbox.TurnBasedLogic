using System.Collections.Generic;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.State;
using MetaLogic.Logic.Static;
using UnityEngine;
using Random = System.Random;

//using UnityEngine;

namespace MetaLogic.Logic.Accessors
{
    [LogicElement(ElementType.Accessor)]
    internal partial class SettingsAccessor
    {
        public ISettingsState State { get; set; }

        [Query]
        public ISettingsStatic Settings { get; set; }

        public bool UpdateBuilds(out List<IBuild> result)
        {
            var currentVersion = GetIntVersion(Settings.GameSettings.AndroidClientVersionCurrent);
            var state = GetIntVersion(State.CurrentVersion);
            result = new List<IBuild>();
            if (currentVersion == state)
            {
                return false;
            }
            var versions = Settings.Builds.Select(x => (x.Key, GetIntVersion(x.Value.Version))).OrderBy(x => x.Item2).ToList();
            foreach (var version in versions)
            {
                var build = Settings.Builds[version.Item1];
                if (state < version.Item2 && version.Item2 <= currentVersion)
                {
                    result.Add(build);
                    State.Build = version.Item1;
                }
            }
            State.CurrentVersion = Settings.GameSettings.AndroidClientVersionCurrent;
            return true;
        }

        public void SetVersion()
        {
            
        }

        [Query]
        public int GetSettingsMoneyIcon(int delta)
        {
            foreach (var temp in Settings.PlayerSettings.MoneySegments.OrderByDescending(x=> x.Key).Select(x=> x.Value))
            {
                if (temp.MinValue < delta)
                {
                    return temp.Icon;
                }
            }
            return 0;
        }

        [Query]
        public IPrice GetPriceRefresh(int number)
        {
            if (!Settings.PlayerSettings.StageRefreshCost.TryGetValue(number, out var price))
            {
                price = Settings.PlayerSettings.StageRefreshCost.OrderBy(x => x.Key).Last().Value;
            }
            return price.Price;
        }

        [Query]
        public IPrice GetPriceStamina(int number)
        {
            if (!Settings.PlayerSettings.ExploreRefreshCost.TryGetValue(number, out var price))
            {
                price = Settings.PlayerSettings.ExploreRefreshCost.OrderBy(x => x.Key).Last().Value;
            }
            return price.Price;
        }


        [Query]
        public int GetIntVersion(string version)
        {
            if (version == null)
            {
                return 0;
            }
            var value = version.Split('.').Select(int.Parse).ToList();

            var sum = 0.0f;
            for (var i = value.Count - 1; i >= 0; i--)
            {
                sum += value[i] * Mathf.Pow(100, value.Count - 1 - i);
            }
            return (int)sum;
        }

        public (int, T) GetWeightRandom<T>(List<(int, T)> dataWeight)
        {
            //var dataWeight = new List<(int, T)>();
            //foreach (var temp in data.Weights.Values)
            //{
            //    if (!_condition.Check(temp.Impact.Condition))
            //    {
            //        continue;
            //    }
            //    dataWeight.Add(((int)_formulaLogic.Calculate(temp.Formula), temp.Impact));
            //}
            //if (dataWeight.Count == 0)
            //{
            //    return;
            //}
            //if (dataWeight.Count == 1)
            //{
            //    _impactLogic.ExecuteImpact(dataWeight.FirstOrDefault().Item2);
            //    return;
            //}
            var weightSum = 0;
            var weights = new List<int>();
            foreach (var temp in dataWeight)
            {
                weights.Add(temp.Item1);
                weightSum += temp.Item1;
            }
            var val = GetNext(weightSum);
            var i = 0;
            var weight = weights[0];
            while (val >= weights[i] && i < dataWeight.Count)
            {
                val -= weights[i];
                i++;
                weight = weights[i];
            }
            return dataWeight[i];
        }

        int GetNext(int count)
        {
            var random = new Random(State.RandomState);
            var val = random.Next(count);
            State.RandomState = random.Next(0, 100000);
            return val;
        }
    }
}
