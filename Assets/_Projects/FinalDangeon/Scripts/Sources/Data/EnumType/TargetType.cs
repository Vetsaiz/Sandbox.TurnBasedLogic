namespace MetaLogic.Data
{
    public enum TargetType
    {
        None = 0,
        Owner = 1,
        Target = 2,
    }

    public enum ContextTargetType
    {
        None = 0,
        Target = 1,
        Owner = 2,
        AllAllies = 3,
        AllEnemies = 4,
        AllUnits
    }

    public enum TargetActivationType
    {
        None = 0,
        Owner = 1,
        Ally = 2,
        Enemy = 3,
        AllAllies = 4,
        AllEnemies = 5,
    }

    public enum ConditionTargetType
    {
        None = 0,
        AllTargetsActivateAll = 1,
        FirstTargetsActivateAll = 2,
        AnyTargetActivate = 3,
        FirstRandomTargetsActivate = 4,
    }

    public enum ContextConditionType
    {
        None = 0,
        AllTargets = 1,
        FirstTarget = 2,
        RandomTarget = 3,
    }
}
