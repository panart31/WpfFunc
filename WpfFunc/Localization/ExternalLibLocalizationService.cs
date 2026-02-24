using System.Globalization;
using System.Reflection;
using System.Resources;

namespace WpfFunc.Localization;

/// <summary>
/// Реализация локализации через внешнюю библиотеку классов ExternalLocalization.
/// Использует RESX-ресурсы из отдельного проекта библиотеки через ResourceManager.
/// </summary>
public class ExternalLibLocalizationService : ILocalizationService
{
    private readonly ResourceManager _resourceManager;
    public CultureInfo CurrentCulture { get; private set; }

    public ExternalLibLocalizationService()
    {
        CurrentCulture = new CultureInfo("ru-RU");
        
        // Загружаем сборку внешней библиотеки по имени
        var assembly = Assembly.Load("ExternalLocalization");
        
        // Имя ресурса: ExternalLocalization.Resources.Strings
        _resourceManager = new ResourceManager(
            "ExternalLocalization.Resources.Strings",
            assembly
        );
    }

    public string GetString(string key)
    {
        // Используем ResourceManager из внешней библиотеки
        var value = _resourceManager.GetString(key, CurrentCulture);
        return value ?? $"[{key}]";
    }

    public void SetCulture(string cultureName)
    {
        CurrentCulture = new CultureInfo(cultureName);
    }
}

