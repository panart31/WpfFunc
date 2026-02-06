using System.Windows.Controls;

namespace WpfFunc.Views
{
    /// <summary>
    /// Представление для демонстрации одноразовой привязки данных.
    /// Значение устанавливается один раз при загрузке и не обновляется.
    /// </summary>
    public partial class OneTimeBindingView : UserControl
    {
        /// <summary>
        /// Конструктор представления. Инициализирует компоненты XAML.
        /// </summary>
        public OneTimeBindingView()
        {
            InitializeComponent();
        }
    }
}
