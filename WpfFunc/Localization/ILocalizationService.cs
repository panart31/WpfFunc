using System.Globalization;

namespace WpfFunc.Localization;

/// <summary>
/// Абстракция службы локализации для разных источников переводов.
/// </summary>
public interface ILocalizationService
{
    /// <summary>
    /// Текущая культура интерфейса.
    /// </summary>
    CultureInfo CurrentCulture { get; }

    /// <summary>
    /// Получить перевод по ключу.
    /// </summary>
    string GetString(string key);

    /// <summary>
    /// Установить новую культуру (например, "ru-RU" или "en-US").
    /// </summary>
    void SetCulture(string cultureName);
}

