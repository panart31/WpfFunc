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

            // В ЭТОМ ВАРИАНТЕ (ветке) используется подход через внешнюю библиотеку классов.
            // Локализация работает через RESX-ресурсы из отдельного проекта ExternalLocalization.
            LocalizationManager.Instance.SetMode(LocalizationMode.ExternalLibrary);
            LocalizationManager.Instance.SetCulture("ru-RU");
        }
    }
}