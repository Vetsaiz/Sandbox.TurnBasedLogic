using System;
using System.Linq;
using VetsEngine.MetaLogic.Core;
using System.Collections.Generic;
using Pathfinding.Serialization.JsonFx;
using MetaLogic.Data;
using MetaLogic.Logic.Static;
using System.Collections.Generic;
namespace MetaLogic.Client.Internal.Static
{
    internal class Internal_ISettingsStatic : ISettingsStatic 
    {
        public void PostSerialize()
        {
            ROD_Pushes = _Pushes != null ? _Pushes.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IPush;
            }
            ) : null;
            ROD_UiElements = _UiElements != null ? _UiElements.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUI;
            }
            ) : null;
            ROD_Emojies = _Emojies != null ? _Emojies.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IEmoji;
            }
            ) : null;
            ROD_Buildings = _Buildings != null ? _Buildings.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IBuilding;
            }
            ) : null;
            ROD_Texts = _Texts != null ? _Texts.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUIText;
            }
            ) : null;
            ROD_Locales = _Locales != null ? _Locales.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as ILocale;
            }
            ) : null;
            ROD_Windows = _Windows != null ? _Windows.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IUIWindow;
            }
            ) : null;
            ROD_AbilityActionInfo = _AbilityActionInfo != null ? _AbilityActionInfo.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IAbilityActionInfo;
            }
            ) : null;
            _GameSettings?.PostSerialize();
            _PlayerSettings?.PostSerialize();
            ROD_Impacts = _Impacts != null ? _Impacts.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IImpact;
            }
            ) : null;
            ROD_Builds = _Builds != null ? _Builds.ToDictionary(
            x =>Int32.Parse(x.Key),
            y => 
            {
                y.Value.PostSerialize();
                 return y.Value as IBuild;
            }
            ) : null;
        }

        #region Interface

        public  IReadOnlyDictionary<Int32, IPush> Pushes => ROD_Pushes;

        public  IReadOnlyDictionary<Int32, IUI> UiElements => ROD_UiElements;

        public  IReadOnlyDictionary<Int32, IEmoji> Emojies => ROD_Emojies;

        public  IReadOnlyDictionary<Int32, IBuilding> Buildings => ROD_Buildings;

        public  IReadOnlyDictionary<Int32, IUIText> Texts => ROD_Texts;

        public  IReadOnlyDictionary<Int32, ILocale> Locales => ROD_Locales;

        public  IReadOnlyDictionary<Int32, IUIWindow> Windows => ROD_Windows;

        public  IReadOnlyDictionary<Int32, IAbilityActionInfo> AbilityActionInfo => ROD_AbilityActionInfo;

        public IGameSettings GameSettings => _GameSettings;

        public IPlayerSettings PlayerSettings => _PlayerSettings;

        public  IReadOnlyDictionary<Int32, IImpact> Impacts => ROD_Impacts;

        public  IReadOnlyDictionary<Int32, IBuild> Builds => ROD_Builds;


        #endregion

        #region Internal

        [JsonName("pushes")]
        public Dictionary<String, Internal_IPush> _Pushes;
        private Dictionary<Int32, IPush> ROD_Pushes;
        [JsonName("ui")]
        public Dictionary<String, Internal_IUI> _UiElements;
        private Dictionary<Int32, IUI> ROD_UiElements;
        [JsonName("emoji")]
        public Dictionary<String, Internal_IEmoji> _Emojies;
        private Dictionary<Int32, IEmoji> ROD_Emojies;
        [JsonName("buildings")]
        public Dictionary<String, Internal_IBuilding> _Buildings;
        private Dictionary<Int32, IBuilding> ROD_Buildings;
        [JsonName("ui_text")]
        public Dictionary<String, Internal_IUIText> _Texts;
        private Dictionary<Int32, IUIText> ROD_Texts;
        [JsonName("ui_locale")]
        public Dictionary<String, Internal_ILocale> _Locales;
        private Dictionary<Int32, ILocale> ROD_Locales;
        [JsonName("ui_windows")]
        public Dictionary<String, Internal_IUIWindow> _Windows;
        private Dictionary<Int32, IUIWindow> ROD_Windows;
        [JsonName("abl_action_info_types")]
        public Dictionary<String, Internal_IAbilityActionInfo> _AbilityActionInfo;
        private Dictionary<Int32, IAbilityActionInfo> ROD_AbilityActionInfo;
        [JsonName("settings")]
        public Internal_IGameSettings _GameSettings;
        [JsonName("player_settings")]
        public Internal_IPlayerSettings _PlayerSettings;
        [JsonName("embed_impacts")]
        public Dictionary<String, Internal_IImpact> _Impacts;
        private Dictionary<Int32, IImpact> ROD_Impacts;
        [JsonName("builds")]
        public Dictionary<String, Internal_IBuild> _Builds;
        private Dictionary<Int32, IBuild> ROD_Builds;

        #endregion
        #region AdittionalClasses


        #endregion

    }
}
