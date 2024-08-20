using System.Globalization;

namespace LocalisedString;

public class LocaleStringItem
{
    public string Culture { get; set; }

    public string Text { get; set; } = string.Empty;
}
