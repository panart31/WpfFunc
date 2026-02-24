using System.Windows;
using WpfFunc.Localization;

namespace WpfFunc
{
    /// <summary>
    /// Точка входа приложения WPF.
    /// Управляет жизненным циклом приложения и ресурсами.
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // В ЭТОМ ВАРИАНТЕ (ветке) используется подход через XAML ResourceDictionary.
            // Локализация работает через XAML-словари Resources/Strings.ru-RU.xaml и Resources/Strings.en-US.xaml
            LocalizationManager.Instance.SetMode(LocalizationMode.XamlDictionary);
            LocalizationManager.Instance.SetCulture("ru-RU");
        }
    }
}