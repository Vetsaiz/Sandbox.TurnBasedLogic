using System.Linq;
using VetsEngine.MetaLogic.Core;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Controllers;

namespace MetaLogic.Logic.Modules
{
    [LogicElement(ElementType.Module)]
    internal partial class SettingsModule
    {
        public SettingsAccessor _settings;
        public ScorersAccessor _scorers;

        public ImpactController _impactLogic;

        [Command]
        public void ActivationWindow(string windowId)
        {
            var activation = _settings.Settings.Windows.Values.FirstOrDefault(x => x.UnityId == windowId);
            if (activation != null)
            {
                _impactLogic.ExecuteImpact(activation.Impact);
            }
            else
            {
                Logger.Error($"no window for id = {windowId}", this);
            }
        }

        [Command]
        public void ActivationTicker(int ticker)
        {
            _impactLogic.ExecuteImpact(_settings.Settings.GameSettings.Ticker);
            Logger.SkipWriteChanges();
            Logger.Clear();
        }

        [Command]
        public void SetSettingsMusicOff(bool value)
        {
            _settings.State.MusicOff = value;
        }
        [Command]
        public void SetSettingsSoundOff(bool value)
        {
            _settings.State.SoundOff = value;
        }

        [Command]
        public void SetLocale(string locale)
        {
            _settings.State.Locale = locale;
        }

        [Command]
        public void SetNotificationStatus(bool status)
        {
            _settings.State.PushStatus = status;
        }
    }
}
