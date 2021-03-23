using Pathfinding.Serialization.JsonFx;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Server.Static
{
    internal class Internal_ITestStatic : ITestStatic 
    {
        public void PostSerialize()
        {
            _Element?.PostSerialize();
        }

        #region Interface

        public ITestSubStatic Element => _Element;


        #endregion

        #region Internal

        [JsonName("element")]
        public Internal_ITestSubStatic _Element;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
