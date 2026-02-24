using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace WpfFunc.Localization;

// Менеджер локализации
public class LocalizationManager : INotifyPropertyChanged
{
    private static readonly LocalizationManager _instance = new();

    private ILocalizationService _service;

    public LocalizationMode Mode { get; private set; }

    public static LocalizationManager Instance => _instance;

    public event PropertyChangedEventHandler? PropertyChanged;

    private LocalizationManager()
    {
        Mode = LocalizationMode.Resx;
        _service = new ResxLocalizationService();
    }

    public string this[string key] => _service.GetString(key);

    public CultureInfo CurrentCulture => _service.CurrentCulture;

    public void SetCulture(string cultureName)
    {
        _service.SetCulture(cultureName);
        OnCultureChanged();
    }

    public void SetMode(LocalizationMode mode)
    {
        if (Mode == mode)
            return;

        Mode = mode;
        _service = mode switch
        {
            LocalizationMode.Resx => new ResxLocalizationService(),
            LocalizationMode.XamlDictionary => new XamlDictionaryLocalizationService(),
            LocalizationMode.ExternalLibrary => new ExternalLibLocalizationService(),
            _ => _service
        };

        OnCultureChanged();
    }

    private void OnCultureChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentCulture)));
    }

    public IReadOnlyList<CultureInfo> AvailableCultures { get; } =
        new[]
        {
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US")
        };
}

// Режимы локализации
public enum LocalizationMode
{
    Resx,
    XamlDictionary,
    ExternalLibrary
}

