namespace MetaLogic.Data
{
    public class BattleParamData
    {
        public double Base;
        public double Equip;
        public double Value;

        public override string ToString()
        {
            return $"base:{Base}|equip:{Equip}|value:{Value}";
        }
    }
}
