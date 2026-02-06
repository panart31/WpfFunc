using System.Windows;

namespace WpfFunc
{
    /// <summary>
    /// Главное окно с установкой DataContext для привязки данных через CommunityToolkit.MVVM.
    /// ViewModel использует ObservableObject из библиотеки вместо ручной реализации.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор главного окна. Инициализирует компоненты и устанавливает ViewModel.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // Установка ViewModel как DataContext - ViewModel использует ObservableObject из библиотеки
            DataContext = new MainViewModel();
        }
    }
}