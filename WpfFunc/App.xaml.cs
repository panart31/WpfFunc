using System.Windows;
using WpfFunc.Localization;

namespace WpfFunc
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LocalizationManager.Instance.SetMode(LocalizationMode.XamlDictionary);
            LocalizationManager.Instance.SetCulture("ru-RU");
        }
    }
}