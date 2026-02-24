using System.Globalization;

// Для варианта с внешней библиотекой предполагается библиотека ExternalLocalization
// со сгенерированным классом ресурсов Strings (resx).

namespace WpfFunc.Localization;

public class ExternalLibLocalizationService : ILocalizationService
{
    public CultureInfo CurrentCulture { get; private set; }

    public ExternalLibLocalizationService()
    {
        CurrentCulture = new CultureInfo("ru-RU");
    }

    public string GetString(string key)
    {
        // Здесь ожидается обращение к ExternalLocalization.Strings.ResourceManager.
        // Чтобы проект компилировался до подключения библиотеки,
        // возвращаем плейсхолдер.
        return $"[ext:{CurrentCulture.Name}:{key}]";
    }

    public void SetCulture(string cultureName)
    {
        CurrentCulture = new CultureInfo(cultureName);
        // При наличии внешней библиотеки нужно будет также установить Culture у её ресурсов.
    }
}

