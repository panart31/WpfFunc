using System.Globalization;

namespace WpfFunc.Localization;

// Интерфейс для локализации
public interface ILocalizationService
{
    CultureInfo CurrentCulture { get; }
    string GetString(string key);
    void SetCulture(string cultureName);
}

