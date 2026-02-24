using System.Globalization;
using System.Reflection;
using System.Resources;

namespace WpfFunc.Localization;

// Локализация через внешнюю библиотеку
public class ExternalLibLocalizationService : ILocalizationService
{
    private readonly ResourceManager _resourceManager;
    public CultureInfo CurrentCulture { get; private set; }

    public ExternalLibLocalizationService()
    {
        CurrentCulture = new CultureInfo("ru-RU");
        var assembly = Assembly.Load("ExternalLocalization");
        _resourceManager = new ResourceManager(
            "ExternalLocalization.Resources.Strings",
            assembly
        );
    }

    public string GetString(string key)
    {
        var value = _resourceManager.GetString(key, CurrentCulture);
        return value ?? $"[{key}]";
    }

    public void SetCulture(string cultureName)
    {
        CurrentCulture = new CultureInfo(cultureName);
    }
}

