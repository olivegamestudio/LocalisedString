using System.Globalization;

namespace LocalisedString;

/// <summary>
/// Represents a localized string item with a specific culture.
/// </summary>
public class LocaleStringItem
{
    /// <summary>
    /// Gets or sets the culture of the localized string.
    /// </summary>
    public string Culture { get; set; }

    /// <summary>
    /// Gets or sets the localized text.
    /// </summary>
    public string Text { get; set; } = string.Empty;
}
