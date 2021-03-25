namespace MetaLogic.Data
{
    public enum TriggerType
    {
        None = 0,
        TriggerManual = 110,
        TriggerStartBattle = 111,
        TriggerEvent = 112,
        TriggerInfluence = 114,
        TriggerHp = 115,
        TriggerFamiliarSummon = 116,
        TriggerBuff = 118,
        TriggerBuffType = 119
    }

    public enum ActivationType
    {
        None = 0,
        StartBattle,
        Manual,
        Events,
    }
}
