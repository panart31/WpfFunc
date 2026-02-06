using System.Windows;

namespace WpfFunc
{
    /// <summary>
    /// Главное окно приложения с установкой DataContext для привязки данных.
    /// Инициализирует ViewModel и устанавливает её как контекст данных для всех элементов UI.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор главного окна. Инициализирует компоненты и устанавливает ViewModel.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // Установка ViewModel как DataContext для привязки данных в XAML
            DataContext = new MainViewModel();
        }
    }
}