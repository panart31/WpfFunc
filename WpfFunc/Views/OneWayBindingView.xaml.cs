using System.Windows.Controls;

namespace WpfFunc.Views
{
    /// <summary>
    /// Представление для демонстрации односторонней привязки данных.
    /// Данные передаются только от источника к целевому элементу.
    /// </summary>
    public partial class OneWayBindingView : UserControl
    {
        /// <summary>
        /// Конструктор представления. Инициализирует компоненты XAML.
        /// </summary>
        public OneWayBindingView()
        {
            InitializeComponent();
        }
    }
}
