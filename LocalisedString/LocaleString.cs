using System.Globalization;
using Utility;

namespace LocalisedString;

public class LocaleString
{
    public List<LocaleStringItem> Strings { get; set; } = new();

    public Task<Result> AddTranslation(CultureInfo culture, string value)
    {
        if (Strings.Any(it => Equals(it.Culture, culture)))
        {
            return Task.FromResult(Result.Fail($"The culture {culture} already exists."));
        }

        Strings.Add(new LocaleStringItem { Culture = culture, Text = value });
        return Task.FromResult(Result.Ok());
    }

    public string GetLocalisedString(CultureInfo culture)
    {
        if (Strings.Any(it => Equals(it.Culture, culture)))
        {
            // an exact match to the culture e.g. en-GB
            return Strings.First(it => Equals(it.Culture, culture)).Text;
        }

        if (Strings.Any(it => Equals(it.Culture, culture.Parent)))
        {
            // an exact match to the parent culture e.g. en
            return Strings.First(it => Equals(it.Culture, culture.Parent)).Text;
        }

        if (Strings.Any(it => Equals(it.Culture, CultureInfo.InvariantCulture)))
        {
            // catch-all string.
            return Strings.First(it => it.Culture == CultureInfo.InvariantCulture).Text;
        }

        // no translation.
        return string.Empty;
    }
}
