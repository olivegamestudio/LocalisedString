using System.Globalization;
using Musts;

namespace LocalisedString;

public class LocaleStringTests
{
    [Test]
    public void EnglishGB_Returns_EnglishText()
    {
        LocaleString s = new();
        s.AddTranslation(new CultureInfo("en"), "EnglishText");
        string result = s.GetLocalisedString(new CultureInfo("en-GB"));

        result.MustBeSame("EnglishText");
    }

    [Test]
    public void English_Returns_EnglishText()
    {
        LocaleString s = new();
        s.AddTranslation(new CultureInfo("en"), "EnglishText");
        string result = s.GetLocalisedString(new CultureInfo("en"));

        result.MustBeSame("EnglishText");
    }
}
