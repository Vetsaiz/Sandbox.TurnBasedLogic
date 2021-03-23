namespace MetaTests.Client
{
    public interface ITestServerLogic
    {
        (string client, string server) CreateDefaultStates();
        (string client, string server) Execute(string clientState, string serverState, string commands);
    }

    public interface ITestClientLogic
    {
        object SetStateData(string clientState, string serverState);
        string GetCommands();
        void ClearCommands();
    }
}
