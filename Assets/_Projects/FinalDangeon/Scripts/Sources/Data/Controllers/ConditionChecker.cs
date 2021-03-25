using VetsEngine.MetaLogic.Core.Condition;
using MetaLogic.Logic.Static;

namespace MetaLogic.Data
{
    public interface IConditionChecker<in T> where T : ICondition
    {
        bool Check(T data);
        ConditionType Id { get; }
    }


    public abstract class ConditionChecker<T> : IBaseConditionChecker<T> where T : ICondition
    {
        public int TemplateId => (int)Id;
        public abstract bool Check(T data);
        public abstract ConditionType Id { get; }
    }

    public class ClientConditionChecker<T> : IBaseConditionChecker<T> where T: ICondition
    {
        private readonly IConditionChecker<T> _checker;

        public ClientConditionChecker(IConditionChecker<T> checker)
        {
            _checker = checker;
        }

        public int TemplateId => (int)_checker.Id;

        public bool Check(T data)
        {
            return _checker.Check(data);
        }
    }




}
