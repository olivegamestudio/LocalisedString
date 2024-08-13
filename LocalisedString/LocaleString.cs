using System.Globalization;

namespace LocalisedString;

public class LocaleString
{
    public Dictionary<CultureInfo, string> Strings { get; set; } = new();

    public Task AddTranslation(CultureInfo culture, string value)
    {
        if (Strings.ContainsKey(culture))
        {
            throw new LocaleStringException();
        }

        Strings.Add(culture, value);
        return Task.CompletedTask;
    }

    public string GetLocalisedString(CultureInfo culture)
    {
        if (Strings.ContainsKey(culture))
        {
            // an exact match to the culture e.g. en-GB
            return Strings[culture];
        }

        if (Strings.ContainsKey(culture.Parent))
        {
            // an exact match to the parent culture e.g. en
            return Strings[culture.Parent];
        }

        if (Strings.ContainsKey(CultureInfo.InvariantCulture))
        {
            // catch-all string.
            return Strings[CultureInfo.InvariantCulture];
        }

        // no translation.
        return string.Empty;
    }
}
