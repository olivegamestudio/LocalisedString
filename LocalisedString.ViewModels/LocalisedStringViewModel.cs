using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Utility.Toolkit;

namespace LocalisedString;

public partial class LocalisedStringViewModel : ObservableObject<LocaleString>
{
    public LocalisedStringViewModel(LocaleString s) : base(s)
    {
        foreach (LocaleStringItem item in s.Strings)
        {
            Items.Add(new LocaleStringViewModel(item));
        }
    }

    [ObservableProperty]
    ObservableCollection<LocaleStringViewModel> _items = new();
}
