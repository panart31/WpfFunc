using System;
using System.Windows.Input;

namespace WpfFunc
{
    /// <summary>
    /// Реализация ICommand для выполнения команд в MVVM без использования библиотек.
    /// Позволяет привязывать действия к элементам UI через механизм команд WPF.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Действие для выполнения при вызове команды.
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// Условие возможности выполнения команды. Если null, команда всегда доступна.
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Событие изменения возможности выполнения команды.
        /// Автоматически подписывается на CommandManager.RequerySuggested для обновления состояния.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Конструктор команды с обязательным действием и опциональным условием выполнения.
        /// </summary>
        /// <param name="execute">Действие для выполнения (обязательно)</param>
        /// <param name="canExecute">Условие возможности выполнения (опционально)</param>
        /// <exception cref="ArgumentNullException">Если execute равен null</exception>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Проверка возможности выполнения команды.
        /// </summary>
        /// <param name="parameter">Параметр команды (не используется в данной реализации)</param>
        /// <returns>true, если команда может быть выполнена, иначе false</returns>
        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        /// <summary>
        /// Выполнение команды.
        /// </summary>
        /// <param name="parameter">Параметр команды (не используется в данной реализации)</param>
        public void Execute(object parameter) => _execute();
    }
}