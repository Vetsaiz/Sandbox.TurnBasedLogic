using System;
using Pathfinding.Serialization.JsonFx;
using SampesLogic.Logic.StaticData;

namespace SampesLogic.Client.Static
{
    internal class Internal_ITestSubStatic : ITestSubStatic 
    {
        public void PostSerialize()
        {
        }

        #region Interface

        public String TestString => _TestString;

        public Int32 TestInt => _TestInt;


        #endregion

        #region Internal

        [JsonName("testString")]
        public String _TestString;
        [JsonName("testInt")]
        public Int32 _TestInt;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
