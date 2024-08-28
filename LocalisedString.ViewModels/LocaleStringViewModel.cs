using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using Utility.Toolkit;

namespace LocalisedString;

/// <summary>
/// ViewModel for <see cref="LocaleStringItem"/> that supports data binding and change notification.
/// </summary>
public partial class LocaleStringViewModel : ObservableObject<LocaleStringItem>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LocaleStringViewModel"/> class.
    /// </summary>
    /// <param name="item">The localized string item.</param>
    public LocaleStringViewModel(LocaleStringItem item) : base(item)
    {
        Culture = new CultureInfo(item.Culture);
        Text = item.Text;
    }

    /// <summary>
    /// Gets or sets the culture information.
    /// </summary>
    [ObservableProperty]
    CultureInfo _culture;

    /// <summary>
    /// Called when the <see cref="Culture"/> property changes.
    /// </summary>
    /// <param name="value">The new culture value.</param>
    partial void OnCultureChanged(CultureInfo value)
    {
        Model.Culture = value.ToString();
    }

    /// <summary>
    /// Gets or sets the localized text.
    /// </summary>
    [ObservableProperty]
    string _text;

    /// <summary>
    /// Called when the <see cref="Text"/> property changes.
    /// </summary>
    /// <param name="value">The new text value.</param>
    partial void OnTextChanged(string value)
    {
        Model.Text = value;
    }
}