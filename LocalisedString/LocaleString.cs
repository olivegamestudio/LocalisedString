using System.Globalization;
using Utility;

namespace LocalisedString;

/// <summary>
/// Represents a collection of localized strings for different cultures.
/// </summary>
public class LocaleString
{
    /// <summary>
    /// Gets or sets the list of localized string items.
    /// </summary>
    public List<LocaleStringItem> Strings { get; set; } = new();

    /// <summary>
    /// Adds a translation for a specific culture.
    /// </summary>
    /// <param name="culture">The culture for which the translation is added.</param>
    /// <param name="value">The localized string value.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Result"/> indicating success or failure.</returns>
    public Task<Result> AddTranslation(CultureInfo culture, string value)
    {
        if (Strings.Any(it => Equals(it.Culture, culture.ToString())))
        {
            return Task.FromResult(Result.Fail($"The culture {culture} already exists."));
        }

        Strings.Add(new LocaleStringItem { Culture = culture.ToString(), Text = value });
        return Task.FromResult(Result.Ok());
    }

    /// <summary>
    /// Gets the localized string for a specific culture.
    /// </summary>
    /// <param name="culture">The culture for which the localized string is requested.</param>
    /// <returns>The localized string if found; otherwise, an empty string.</returns>
    public string GetLocalisedString(CultureInfo culture)
    {
        if (Strings.Any(it => Equals(it.Culture, culture.ToString())))
        {
            // an exact match to the culture e.g. en-GB
            return Strings.First(it => Equals(it.Culture, culture.ToString())).Text;
        }

        if (Strings.Any(it => Equals(it.Culture, culture.Parent.ToString())))
        {
            // an exact match to the parent culture e.g. en
            return Strings.First(it => Equals(it.Culture, culture.Parent.ToString())).Text;
        }

        if (Strings.Any(it => Equals(it.Culture, CultureInfo.InvariantCulture.ToString())))
        {
            // catch-all string.
            return Strings.First(it => it.Culture == CultureInfo.InvariantCulture.ToString()).Text;
        }

        // no translation.
        return string.Empty;
    }
}
