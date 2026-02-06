using System;
using System.Windows.Input;

namespace WpfFunc
{
    // Реализация ICommand для выполнения команд в MVVM без использования библиотек
    public class RelayCommand : ICommand
    {
        private readonly Action _execute; // Действие для выполнения
        private readonly Func<bool> _canExecute; // Условие возможности выполнения

        // Событие изменения возможности выполнения команды
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        // Конструктор команды с обязательным действием и опциональным условием
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Проверка возможности выполнения команды
        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        // Выполнение команды
        public void Execute(object parameter) => _execute();
    }
}