using System.Collections.Generic;
using VetsEngine.MetaLogic.Core;

namespace MetaLogic.Logic.Static
{
    [StaticData(IsRoot = true)]
    public interface IScorerStatic
    {
        [SerializableId("scorers")]
        IReadOnlyDictionary<int, IScorer> Scorers { get; }

        [SerializableId("money_types")]
        IReadOnlyDictionary<int, IMoneyType> MoneyTypes { get; }
        
        [SerializableId("consts")]
        IReadOnlyDictionary<int, IConstant> Consts { get; }
    }
}
