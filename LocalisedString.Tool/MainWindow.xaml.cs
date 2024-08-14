using System.Globalization;
using System.Windows;

namespace LocalisedString.Tool;

public partial class MainWindow : Window
{
    readonly LocaleString _localeString = new();

    public MainWindow()
    {
        InitializeComponent();

        _localeString.AddTranslation(new CultureInfo("en-gb"), "EnglishGB");
        DataContext = new LocalisedStringViewModel(_localeString);
    }
}
