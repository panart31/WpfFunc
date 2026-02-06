using System.Windows;

namespace WpfFunc
{
    // Главное окно приложения с установкой DataContext для привязки данных
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Установка ViewModel как DataContext для привязки данных в XAML
            DataContext = new MainViewModel();
        }
    }
}