namespace MetaLogic.Data
{
    public class ExplorerPositionData
    {
        public float Position;
        public string Room;

        public override string ToString()
        {
            return $"position:{Position}|room:{Room}";
        }
    }

    public class PerkExecuteData
    {
        public int UnitId;
        public int PerkId;

        public override string ToString()
        {
            return $"UnitId:{UnitId}|PerkId:{PerkId}";
        }
    }
}
