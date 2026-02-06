using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfFunc
{
    // Базовый класс для ViewModel с ручной реализацией INotifyPropertyChanged
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Событие для уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;

        // Вызов события изменения свойства с автоматическим определением имени через CallerMemberName
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Универсальный метод установки значения с проверкой на изменение и уведомлением
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}