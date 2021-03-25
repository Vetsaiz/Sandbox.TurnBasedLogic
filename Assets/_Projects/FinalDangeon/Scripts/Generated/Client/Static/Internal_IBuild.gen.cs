using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IBuild : IBuild 
    {
        public void PostSerialize()
        {
            _Impact?.PostSerialize();
        }

        #region Interface

        public Int32 Id => _Id;

        public String Version => _Version;

        public IImpact Impact => _Impact;

        public Int32 Size => _Size;

        public Boolean InStore => _InStore;

        public Boolean Confirm => _Confirm;

        public Boolean Strict => _Strict;

        public String Description => _Description;


        #endregion

        #region Internal

        [JsonName("id")]
        public Int32 _Id;
        [JsonName("version")]
        public String _Version;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("size")]
        public Int32 _Size;
        [JsonName("in_store")]
        public Boolean _InStore;
        [JsonName("confirm")]
        public Boolean _Confirm;
        [JsonName("strict")]
        public Boolean _Strict;
        [JsonName("description")]
        public String _Description;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
