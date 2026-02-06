using System.Windows;

namespace WpfFunc
{
    // Главное окно с установкой DataContext для привязки данных через CommunityToolkit.MVVM
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Установка ViewModel как DataContext - ViewModel использует ObservableObject из библиотеки
            DataContext = new MainViewModel();
        }
    }
}