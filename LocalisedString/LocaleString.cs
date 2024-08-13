using System.Globalization;

namespace LocalisedString;

public class LocaleString
{
    readonly Dictionary<CultureInfo, string> _localeStrings = new();

    public Task AddTranslation(CultureInfo culture, string value)
    {
        _localeStrings.Add(culture, value);
        return Task.CompletedTask;
    }

    public string GetLocalisedString(CultureInfo culture)
    {
        if (_localeStrings.ContainsKey(culture))
        {
            // an exact match to the culture e.g. en-GB
            return _localeStrings[culture];
        }

        if (_localeStrings.ContainsKey(culture.Parent))
        {
            // an exact match to the parent culture e.g. en
            return _localeStrings[culture.Parent];
        }

        if (_localeStrings.ContainsKey(CultureInfo.InvariantCulture))
        {
            // catch-all string.
            return _localeStrings[CultureInfo.InvariantCulture];
        }

        // no translation.
        return string.Empty;
    }
}
