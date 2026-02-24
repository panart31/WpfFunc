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

            // В ЭТОМ ВАРИАНТЕ (ветке) по умолчанию используется подход через RESX.
            // Для других вариантов лабораторной работы достаточно поменять режим:
            // LocalizationManager.Instance.SetMode(LocalizationMode.XamlDictionary);
            // или
            // LocalizationManager.Instance.SetMode(LocalizationMode.ExternalLibrary);
            LocalizationManager.Instance.SetMode(LocalizationMode.Resx);
            LocalizationManager.Instance.SetCulture("ru-RU");
        }
    }
}