namespace MetaLogic.Data
{
    public enum InfluenceType
    {
        None = 0,
        Attack  = 1,
        AttackDistance = 2,
        Heal = 3,
        PositiveBuff = 4,
        NegativeBuff = 5,
        SummonAlly = 6,
        Transform = 7,
        Defence = 8,
    }

    public enum InfluenceTargetType
    {
        Attack = 1,
        AttackDistance = 2,
        Heal = 3,
    }

    public enum InfluenceBuffType
    {
        None = 0,
        Positive = 1,
        Negative = 2,
        Neitral = 3,
    }
}
