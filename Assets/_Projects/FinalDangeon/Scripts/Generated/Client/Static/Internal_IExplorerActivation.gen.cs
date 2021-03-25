using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_IExplorerActivation : IExplorerActivation 
    {
        public void PostSerialize()
        {
            _Cost?.PostSerialize();
            _Settings?.PostSerialize();
            _Source?.PostSerialize();
            _Description?.PostSerialize();
            _Impact?.PostSerialize();
            _Actable?.PostSerialize();
        }

        #region Interface

        public IActivationCost Cost => _Cost;

        public Int32 Id => _Id;

        public IActivationSettings Settings => _Settings;

        public IActivationSource Source => _Source;

        public IActivationDescription Description => _Description;

        public IImpact Impact => _Impact;

        public ICondition Actable => _Actable;


        #endregion

        #region Internal

        [JsonName("cost")]
        public Internal_IActivationCost _Cost;
        [JsonName("id")]
        public Int32 _Id;
        [JsonName("settings")]
        public Internal_IActivationSettings _Settings;
        [JsonName("source")]
        public Internal_IActivationSource _Source;
        [JsonName("desc")]
        public Internal_IActivationDescription _Description;
        [JsonName("impact")]
        public Internal_IImpact _Impact;
        [JsonName("visibility")]
        public Internal_ICondition _Actable;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
