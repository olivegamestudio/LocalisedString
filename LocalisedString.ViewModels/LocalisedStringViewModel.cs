using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Utility.Toolkit;

namespace LocalisedString;

/// <summary>
/// ViewModel for <see cref="LocaleString"/> that supports data binding and change notification.
/// </summary>
public partial class LocalisedStringViewModel : ObservableObject<LocaleString>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocalisedStringViewModel"/> class.
    /// </summary>
    /// <param name="s">The localized string collection.</param>
    public LocalisedStringViewModel(LocaleString s) : base(s)
    {
        foreach (LocaleStringItem item in s.Strings)
        {
            Items.Add(new LocaleStringViewModel(item));
        }
    }

    /// <summary>
    /// Gets or sets the collection of localized string view models.
    /// </summary>
    [ObservableProperty]
    ObservableCollection<LocaleStringViewModel> _items = new();
}