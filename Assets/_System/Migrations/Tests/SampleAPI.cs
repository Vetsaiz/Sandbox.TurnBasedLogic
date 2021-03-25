using Common.SampleUI;
using MetaTests.Client.Core;
using MigrationLogic.Server;

namespace MigrationLogic.Client
{
    public class SampleAPI : ILogic
    {
        IServerLogicContext _context;

        public bool Progress { get; set; }
        public object[] Context => new object[] { this };
        
        public SampleAPI()
        {
            _context = ServerLogicCreator.Create(new TestSerializator(), null);
            
        }


        
        public void MigrationState0_1()
        {

        }

        public void MigrationState1_2()
        {

        }

        public void MigrationState0_4()
        {

        }

        public void Dispose()
        {
        }
    }
}