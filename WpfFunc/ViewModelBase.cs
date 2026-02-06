using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfFunc
{
    /// <summary>
    /// Базовый класс для ViewModel с ручной реализацией INotifyPropertyChanged.
    /// Предоставляет механизм уведомления об изменении свойств для привязки данных в WPF.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие для уведомления об изменении свойств.
        /// Используется механизмом привязки данных WPF для автоматического обновления UI.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие изменения свойства с автоматическим определением имени через CallerMemberName.
        /// </summary>
        /// <param name="propertyName">Имя изменённого свойства (определяется автоматически)</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Универсальный метод установки значения с проверкой на изменение и уведомлением.
        /// Предотвращает лишние обновления UI при установке того же значения.
        /// </summary>
        /// <typeparam name="T">Тип значения свойства</typeparam>
        /// <param name="field">Поле для хранения значения</param>
        /// <param name="value">Новое значение</param>
        /// <param name="propertyName">Имя свойства (определяется автоматически)</param>
        /// <returns>true, если значение было изменено, иначе false</returns>
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