using System.Globalization;
using System.Resources;

namespace WpfFunc.Localization;

/// <summary>
/// Реализация локализации через .resx файлы в WPF-проекте.
/// Ожидает наличие ресурсов с базовым именем "Resources.Strings".
/// </summary>
public class ResxLocalizationService : ILocalizationService
{
    private readonly ResourceManager _resourceManager;

    public CultureInfo CurrentCulture { get; private set; }

    public ResxLocalizationService()
    {
        _resourceManager = new ResourceManager("WpfFunc.Resources.Strings", typeof(ResxLocalizationService).Assembly);
        CurrentCulture = new CultureInfo("ru-RU");
    }

    public string GetString(string key)
    {
        var value = _resourceManager.GetString(key, CurrentCulture);
        return string.IsNullOrEmpty(value) ? $"!{key}!" : value;
    }

    public void SetCulture(string cultureName)
    {
        CurrentCulture = new CultureInfo(cultureName);
    }
}

