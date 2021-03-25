using MetaLogic.Logic.Static;

namespace MetaLogic.Generated.Shared
{
    public interface IQueryAPI
    {
        IExplorerQuery ExplorerStatic { get; }
    }

    public interface IExplorerQuery
    {
        IExplorerStatic Static { get; }

        
    }
}
