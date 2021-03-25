using UnityEditor;
using VetsEngine.MetaLogic.Builder;

namespace MigrationLogic.Editor
{
    public static class MetaLogicBuild
    {
        const string BaseMenuName = "MetaLogic/Migrations/";
        const string ConfigPath = "_MetaLogic\\Scripts\\Migrations\\Editor\\Sources";

        [MenuItem(BaseMenuName + "Generate Client and Server")]
        public static void TestGenerateLogic()
        {
            //BuildUtility.UnityProcess(typeof(IMigrationsExternalAPI), $"{Application.dataPath}\\{ConfigPath}\\config.json");
        }

        [MenuItem(BaseMenuName + "Generate Client and Server bat")]
        public static void GenerateDebugClient()
        {
            BuildUtility.CommandLineProcess("build_sample.bat");
        }

        [MenuItem(BaseMenuName + "Generate Migrations Clear")]
        public static void GenerateMirationData()
        {
            //BuildUtility.UnityMigrationProcess(typeof(IMigrationsExternalAPI), $"{Application.dataPath}\\{ConfigPath}\\config.json", 10, MigrationType.None);
        }


        [MenuItem(BaseMenuName + "Generate Migrations Refresh")]
        public static void GenerateMirationDataRefresh()
        {
            //BuildUtility.UnityMigrationProcess(typeof(IMigrationsExternalAPI), $"{Application.dataPath}\\{ConfigPath}\\config.json", 10, MigrationType.Refresh);
        }

        [MenuItem(BaseMenuName + "Generate Migrations Increase")]
        public static void GenerateMirationDataIncrease()
        {
            //BuildUtility.UnityMigrationProcess(typeof(IMigrationsExternalAPI), $"{Application.dataPath}\\{ConfigPath}\\config.json", 10, MigrationType.Increase);
        }
    }
}