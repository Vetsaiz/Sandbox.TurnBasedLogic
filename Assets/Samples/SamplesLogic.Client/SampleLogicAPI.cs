using Sandbox.Logic;

namespace SamplesLogic.Client
{
    public class SampleLogicAPI : BaseLogicAPI
    {
        public override string ConfigPath => "SampleLogic/";
        public override string NamespaceCreator => "MetaLogic.Test";
        public override object ClientExternalApi => new SampleExternalAPI();
        public override object ServerExternalApi => new SampleExternalAPI();
    }
}