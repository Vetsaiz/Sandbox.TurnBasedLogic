using UnityEditor;
using VetsEngine.MetaLogic.Builder;

namespace SamplesLogic.Editor
{
    public static class MetaLogicBuild
    {
        const string BaseMenuName = "MetaLogic/Sample/";
        const string ConfigPath = "Samples\\SamplesLogic.Editor\\Sources\\";

        [MenuItem(BaseMenuName + "Generate Client and Server")]
        public static void TestGenerateLogic()
        {
            //BuildUtility.UnityProcess(typeof(ITestExternalAPI), $"{Application.dataPath}\\{ConfigPath}\\configSample.json");
        }

        [MenuItem(BaseMenuName + "Generate Client and Server bat")]
        public static void GenerateDebugClient()
        {
            BuildUtility.CommandLineProcess("build_sample.bat");
        }
    
        [MenuItem(BaseMenuName + "Increase Migrations")]
        public static void GenerateMirationData()
        {
            //BuildUtility.UnityMigrationProcess(typeof(ITestExternalAPI), $"{Application.dataPath}\\{ConfigPath}\\configSample.json", 11, MigrationType.Increase);
        }

        [MenuItem(BaseMenuName + "Refresh Migrations")]
        public static void GenerateMirationRefresh()
        {
            //BuildUtility.UnityMigrationProcess(typeof(ITestExternalAPI), $"{Application.dataPath}\\{ConfigPath}\\configSample.json", 11, MigrationType.Refresh);
        }
    }
}