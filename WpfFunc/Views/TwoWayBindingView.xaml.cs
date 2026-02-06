using System.Windows.Controls;

namespace WpfFunc.Views
{
    /// <summary>
    /// Представление для демонстрации двухсторонней привязки данных.
    /// Показывает синхронизацию данных между элементами UI без использования пакетов.
    /// </summary>
    public partial class TwoWayBindingView : UserControl
    {
        /// <summary>
        /// Конструктор представления. Инициализирует компоненты XAML.
        /// </summary>
        public TwoWayBindingView()
        {
            InitializeComponent();
        }
    }
}
