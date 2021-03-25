using VetsEngine.MetaLogic.Core.Impacts;
using MetaLogic.Logic.Static;

namespace MetaLogic.Data
{
    public interface IImpactExecutor<in T> where T : IImpact
    {
        void Execute(T data);
        ImpactType Id { get; }
    }

    public abstract class ImpactExecutor<T> : IBaseImpactExecutor<T> where T : class,IImpact
    {

        public abstract void Execute(T data);
        public int TemplateId => (int) Id;
        public abstract ImpactType Id { get; }
    }

    public class ClientImpactExecutor<T> : IBaseImpactExecutor<T> where T : IImpact
    {
        private readonly IImpactExecutor<T> _checker;

        public ClientImpactExecutor(IImpactExecutor<T> checker)
        {
            _checker = checker;
        }

        public void Execute(T data)
        {
            _checker.Execute(data);
        }

        public int TemplateId => (int)_checker.Id;
    }
}
