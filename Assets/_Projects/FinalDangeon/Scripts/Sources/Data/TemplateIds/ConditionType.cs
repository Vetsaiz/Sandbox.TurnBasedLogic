namespace MetaLogic.Data
{
    public enum ConditionType
    {
        None = 0,
        Conditions = 30,
        CondConjunction = 27,
        CondDisjunction = 28,
        CondNegation = 192,
        CondItemAvailability = 31,
        CondPlayerLevel = 64,
        CondScorer = 29,
        CondRarityUnit = 63,
        CondCheck = 129,
        CondFamiliar = 213,

        ConditionsUnit = 126,
        CondUnitConjunction = 127,
        CondUnitDisjunction = 128,
        CondUnitNegation = 193,
        CondUnitRarity = 137,
        CondUnitHp = 131,
        CondUnitClass  = 139,
        CondUnitMob = 138,
        CondUnitMostHp = 133,
        CondUnitSlot = 152,
        CondUnitFamiliar = 130,

        ConditionUnitCheck = 194,
        CondUnitWorld = 140,
        CondUnitBuff = 134,
        CondUnitBuffType = 135,
        CondRand = 132,
        CondUnitMove = 136,
        CondAvailability = 217,
        CondStage = 233,
        CondZone = 232,
        CondUnitTarget = 247,

        CondPlatform = 248,
        CondFormula = 253,
        CondAchievement = 267
    }
}
