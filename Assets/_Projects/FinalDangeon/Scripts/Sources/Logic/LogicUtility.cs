using System;
using MetaLogic.Data;

namespace MetaLogic.Logic
{
    public static class LogicUtility
    {
        public static bool Check(this OperatorType type, double current, double value)
        {
            switch (type)
            {
                case OperatorType.Less:
                {
                    return current < value;
                }
                case OperatorType.More:
                {
                    return current > value;
                }
                case OperatorType.Equal:
                {
                    return current == value;
                }
                case OperatorType.LessEqual:
                {
                    return current <= value;
                }
                case OperatorType.MoreEqual:
                {
                    return current >= value;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
