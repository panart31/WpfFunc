using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfFunc
{
    // ViewModel с использованием CommunityToolkit.MVVM - наследование от ObservableObject вместо ручной реализации
    public partial class MainViewModel : ObservableObject
    {
        // Атрибут [ObservableProperty] автоматически генерирует свойство с INotifyPropertyChanged
        [ObservableProperty]
        private string _defaultText = "Панов Артем - ЛР1";

        // Автоматическая генерация свойства TwoWayText с уведомлениями через source generator
        [ObservableProperty]
        private string _twoWayText = "Двусторонний текст";

        // Значение слайдера с автоматической реализацией PropertyChanged через атрибут
        [ObservableProperty]
        private double _sliderValue = 50;

        // Флаг активности с автоматической генерацией свойства через CommunityToolkit
        [ObservableProperty]
        private bool _isActive = true;

        // Свойство только для чтения без атрибута - не требует уведомлений
        private readonly string _oneTimeText = DateTime.Now.ToString("HH:mm:ss");
        public string OneTimeText => _oneTimeText;

        // Исходный текст с автоматической реализацией через [ObservableProperty]
        [ObservableProperty]
        private string _sourceText = "Исходный текст";

        // Коллекция элементов для демонстрации привязки коллекций
        public ObservableCollection<string> Items { get; } = new();

        // Команда через атрибут [RelayCommand] - автоматически генерирует команду UpdateCommand
        [RelayCommand]
        private void Update()
        {
            DefaultText = $"Обновлено: {DateTime.Now:HH:mm:ss}";
        }

        // Автоматическая генерация ToggleCommand через source generator
        [RelayCommand]
        private void Toggle()
        {
            IsActive = !IsActive;
        }

        // Команда очистки с автоматической реализацией ICommand через библиотеку
        [RelayCommand]
        private void Clear()
        {
            TwoWayText = "";
            SourceText = "";
        }

        // Команда добавления элемента - генерация через CommunityToolkit.MVVM
        [RelayCommand]
        private void AddItem()
        {
            Items.Add($"Элемент {Items.Count + 1}");
        }

        // Инициализация ViewModel с начальными данными
        public MainViewModel()
        {
            Items.Add("Пример 1");
            Items.Add("Пример 2");
        }

        // Свойство текущего времени для демонстрации динамической привязки
        public DateTime CurrentTime => DateTime.Now;
    }
}