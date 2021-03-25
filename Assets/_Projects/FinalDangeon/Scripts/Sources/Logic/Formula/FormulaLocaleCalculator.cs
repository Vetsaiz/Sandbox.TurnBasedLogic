using System.Linq;
using MetaLogic.Data;
using MetaLogic.Logic.Accessors;
using MetaLogic.Logic.Static;

namespace MetaLogic.Logic.Formula
{
    class FormulaLocaleCalculator : FormulaCalculator<IFormulaLocale>
    {
        private SettingsAccessor _settings;

        public FormulaLocaleCalculator(SettingsAccessor settings)
        {
            _settings = settings;
        }

        public override double Calculate(IFormulaLocale formulaData)
        {
            return _settings.Settings.Locales.FirstOrDefault(x => x.Value.Locale == _settings.State.Locale).Key;
        }

        public override FormulaType Id => FormulaType.FormulaLocale;
    }
}
