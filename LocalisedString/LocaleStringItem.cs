using System.Globalization;

namespace LocalisedString;

public class LocaleStringItem
{
    public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

    public string Text { get; set; } = string.Empty;
}
