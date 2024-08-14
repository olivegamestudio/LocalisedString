using System.Globalization;
using Musts;
using Utility;

namespace LocalisedString.Tests;

public class LocaleStringTests
{
    [Test]
    public async Task EnglishGB_Returns_EnglishText_FromRealSetup()
    {
        LocaleString s = new();
        await s.AddTranslation(new CultureInfo("en"), "EnglishText");
        await s.AddTranslation(new CultureInfo("fr"), "FrenchText");
        await s.AddTranslation(new CultureInfo("en-GB"), "EnglishGBText");
        await s.AddTranslation(new CultureInfo("fr-fr"), "FrenchFRText");
        
        string text = s.GetLocalisedString(new CultureInfo("en-GB"));

        text.MustBeSame("EnglishGBText");
    }

    [Test]
    public async Task AddingTranslationTwice_ReturnsFailue()
    {
        LocaleString s = new();
        Result result = await s.AddTranslation(new CultureInfo("en"), "EnglishText");
        result.MustBeSuccess();

        result = await s.AddTranslation(new CultureInfo("en"), "EnglishText");
        result.MustBeFailure();
    }

    [Test]
    public void English_Returns_EmptyString()
    {
        LocaleString s = new();
        string text = s.GetLocalisedString(new CultureInfo("en"));
        text.MustBeNullOrEmpty();
    }

    [Test]
    public async Task EnglishGB_Returns_EnglishText()
    {
        LocaleString s = new();
        Result result = await s.AddTranslation(new CultureInfo("en"), "EnglishText");
        string text = s.GetLocalisedString(new CultureInfo("en-GB"));

        result.MustBeSuccess();
        text.MustBeSame("EnglishText");
    }

    [Test]
    public async Task EnglishGB_Returns_EnglishGBText()
    {
        LocaleString s = new();
        Result result = await s.AddTranslation(new CultureInfo("en-GB"), "EnglishGBText");
        string text = s.GetLocalisedString(new CultureInfo("en-GB"));

        result.MustBeSuccess();
        text.MustBeSame("EnglishGBText");
    }

    [Test]
    public async Task English_Returns_EnglishText()
    {
        LocaleString s = new();
        Result result = await s.AddTranslation(new CultureInfo("en"), "EnglishText");
        
        string text = s.GetLocalisedString(new CultureInfo("en"));

        result.MustBeSuccess();
        text.MustBeSame("EnglishText");
    }

    [Test]
    public async Task English_Returns_InvariantText()
    {
        LocaleString s = new();
        Result result = await s.AddTranslation(CultureInfo.InvariantCulture, "InvariantText");
        string text = s.GetLocalisedString(new CultureInfo("en"));

        result.MustBeSuccess();
        text.MustBeSame("InvariantText");
    }
}
