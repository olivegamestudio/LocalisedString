using System.Globalization;
using Musts;

namespace LocalisedString.Tests;

public class LocaleStringTests
{
    [Test]
    public void EnglishGB_Returns_EnglishText_FromRealSetup()
    {
        LocaleString s = new();
        s.AddTranslation(new CultureInfo("en"), "EnglishText");
        s.AddTranslation(new CultureInfo("fr"), "FrenchText");
        s.AddTranslation(new CultureInfo("en-GB"), "EnglishGBText");
        s.AddTranslation(new CultureInfo("fr-fr"), "FrenchFRText");
        string result = s.GetLocalisedString(new CultureInfo("en-GB"));

        result.MustBeSame("EnglishGBText");
    }

    [Test]
    public void AddingTranslationTwice_ThrowsException()
    {
        LocaleString s = new();
        s.AddTranslation(new CultureInfo("en"), "EnglishText");
        Assert.Throws<LocaleStringException>(() => s.AddTranslation(new CultureInfo("en"), "EnglishText"));
    }

    [Test]
    public void English_Returns_EmptyString()
    {
        LocaleString s = new();
        string result = s.GetLocalisedString(new CultureInfo("en"));

        result.MustBeNullOrEmpty();
    }

    [Test]
    public void EnglishGB_Returns_EnglishText()
    {
        LocaleString s = new();
        s.AddTranslation(new CultureInfo("en"), "EnglishText");
        string result = s.GetLocalisedString(new CultureInfo("en-GB"));

        result.MustBeSame("EnglishText");
    }

    [Test]
    public void EnglishGB_Returns_EnglishGBText()
    {
        LocaleString s = new();
        s.AddTranslation(new CultureInfo("en-GB"), "EnglishGBText");
        string result = s.GetLocalisedString(new CultureInfo("en-GB"));

        result.MustBeSame("EnglishGBText");
    }

    [Test]
    public void English_Returns_EnglishText()
    {
        LocaleString s = new();
        s.AddTranslation(new CultureInfo("en"), "EnglishText");
        string result = s.GetLocalisedString(new CultureInfo("en"));

        result.MustBeSame("EnglishText");
    }

    [Test]
    public void English_Returns_InvariantText()
    {
        LocaleString s = new();
        s.AddTranslation(CultureInfo.InvariantCulture, "InvariantText");
        string result = s.GetLocalisedString(new CultureInfo("en"));

        result.MustBeSame("InvariantText");
    }
}
