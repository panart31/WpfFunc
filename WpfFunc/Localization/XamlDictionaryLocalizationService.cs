using System.Globalization;
using System.Linq;
using System.Windows;

namespace WpfFunc.Localization;

/// <summary>
/// Локализация через XAML ResourceDictionary.
/// Ожидает наличие словарей Resources\Strings.ru-RU.xaml, Resources\Strings.en-US.xaml с x:String по ключам.
/// </summary>
public class XamlDictionaryLocalizationService : ILocalizationService
{
    public CultureInfo CurrentCulture { get; private set; }

    public XamlDictionaryLocalizationService()
    {
        CurrentCulture = new CultureInfo("ru-RU");
        EnsureDictionariesLoaded();
    }

    public string GetString(string key)
    {
        EnsureDictionariesLoaded();

        var dictKey = $"pack://application:,,,/WpfFunc;component/Resources/Strings.{CurrentCulture.Name}.xaml";
        var targetDict = Application.Current.Resources.MergedDictionaries
            .FirstOrDefault(d => d.Source != null && d.Source.ToString() == dictKey);

        if (targetDict != null && targetDict.Contains(key))
        {
            return targetDict[key]?.ToString() ?? $"!{key}!";
        }

        return $"!{key}!";
    }

    public void SetCulture(string cultureName)
    {
        CurrentCulture = new CultureInfo(cultureName);
        EnsureDictionariesLoaded();
    }

    private void EnsureDictionariesLoaded()
    {
        if (Application.Current == null)
            return;

        var baseUri = "pack://application:,,,/WpfFunc;component/Resources/";
        var ruUri = new System.Uri(baseUri + "Strings.ru-RU.xaml");
        var enUri = new System.Uri(baseUri + "Strings.en-US.xaml");

        void Ensure(Uri uri)
        {
            if (!Application.Current.Resources.MergedDictionaries.Any(d => d.Source == uri))
            {
                Application.Current.Resources.MergedDictionaries.Add(
                    new ResourceDictionary { Source = uri });
            }
        }

        Ensure(ruUri);
        Ensure(enUri);
    }
}

