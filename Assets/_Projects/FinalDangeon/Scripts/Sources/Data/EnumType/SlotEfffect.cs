namespace MetaLogic.Data
{
    public enum DisableSlotEffect
    {
        None = 0,
        DisableIdle = 1,
        DisableMoveRight = 2,
        DisableMoveLeft = 3
    }

    public enum EnableSlotEffect
    {
        None = 0,
        EnableIdle = 1,
        EnableMoveRight = 2,
        EnableMoveLeft = 3,
        EnableAction3 = 4, 
    }

    public enum SlotDirection
    {
        None = 0,
        Right = 1,
        Left = 2,
    }
}
