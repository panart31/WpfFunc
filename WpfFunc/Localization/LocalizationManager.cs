using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace WpfFunc.Localization;

/// <summary>
/// Глобальный менеджер локализации, к которому привязывается UI.
/// Позволяет подменять реализацию ILocalizationService (RESX, XAML-словари, внешняя библиотека).
/// </summary>
public class LocalizationManager : INotifyPropertyChanged
{
    private static readonly LocalizationManager _instance = new();

    private ILocalizationService _service;

    /// <summary>
    /// Текущий режим/подход к локализации.
    /// </summary>
    public LocalizationMode Mode { get; private set; }

    public static LocalizationManager Instance => _instance;

    public event PropertyChangedEventHandler? PropertyChanged;

    private LocalizationManager()
    {
        // По умолчанию используем RESX-подход.
        Mode = LocalizationMode.Resx;
        _service = new ResxLocalizationService();
    }

    /// <summary>
    /// Индексатор для привязки из XAML: {Binding [App.Title], Source={x:Static loc:LocalizationManager.Instance}}
    /// </summary>
    public string this[string key] => _service.GetString(key);

    public CultureInfo CurrentCulture => _service.CurrentCulture;

    public void SetCulture(string cultureName)
    {
        _service.SetCulture(cultureName);
        OnCultureChanged();
    }

    /// <summary>
    /// Сменить реализацию локализации (для разных веток: RESX, XAML словари, внешняя библиотека).
    /// </summary>
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
        // Уведомляем все привязки индексатора.
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentCulture)));
    }

    /// <summary>
    /// Доступные культуры интерфейса.
    /// </summary>
    public IReadOnlyList<CultureInfo> AvailableCultures { get; } =
        new[]
        {
            new CultureInfo("ru-RU"),
            new CultureInfo("en-US")
        };
}

/// <summary>
/// Режим / подход к локализации.
/// </summary>
public enum LocalizationMode
{
    /// <summary>
    /// Локализация через .resx файлы в самом WPF-проекте.
    /// </summary>
    Resx,

    /// <summary>
    /// Локализация через XAML ResourceDictionary с ключами строк.
    /// </summary>
    XamlDictionary,

    /// <summary>
    /// Локализация через внешнюю библиотеку классов.
    /// </summary>
    ExternalLibrary
}

