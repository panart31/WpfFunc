using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfFunc
{
    /// <summary>
    /// ViewModel с использованием CommunityToolkit.MVVM - наследование от ObservableObject вместо ручной реализации.
    /// Использует source generators для автоматической генерации свойств и команд.
    /// </summary>
    public partial class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Атрибут [ObservableProperty] автоматически генерирует свойство DefaultText с INotifyPropertyChanged.
        /// Source generator создаёт публичное свойство из приватного поля _defaultText.
        /// </summary>
        [ObservableProperty]
        private string _defaultText = "Панов Артем - ЛР1";

        /// <summary>
        /// Автоматическая генерация свойства TwoWayText с уведомлениями через source generator.
        /// Изменения автоматически уведомляют UI благодаря CommunityToolkit.Mvvm.
        /// </summary>
        [ObservableProperty]
        private string _twoWayText = "Двусторонний текст";

        /// <summary>
        /// Значение слайдера с автоматической реализацией PropertyChanged через атрибут.
        /// Генерируется свойство SliderValue с поддержкой привязки данных.
        /// </summary>
        [ObservableProperty]
        private double _sliderValue = 50;

        /// <summary>
        /// Флаг активности с автоматической генерацией свойства через CommunityToolkit.
        /// Используется для демонстрации двухсторонней привязки с CheckBox.
        /// </summary>
        [ObservableProperty]
        private bool _isActive = true;

        /// <summary>
        /// Свойство только для чтения без атрибута - не требует уведомлений.
        /// Используется для демонстрации OneTime привязки.
        /// </summary>
        private readonly string _oneTimeText = DateTime.Now.ToString("HH:mm:ss");
        public string OneTimeText => _oneTimeText;

        /// <summary>
        /// Исходный текст с автоматической реализацией через [ObservableProperty].
        /// Демонстрирует одностороннюю привязку данных.
        /// </summary>
        [ObservableProperty]
        private string _sourceText = "Исходный текст";

        // Коллекция элементов для демонстрации привязки коллекций
        public ObservableCollection<string> Items { get; } = new();

        /// <summary>
        /// Команда через атрибут [RelayCommand] - автоматически генерирует команду UpdateCommand.
        /// Source generator создаёт публичное свойство UpdateCommand типа IRelayCommand.
        /// </summary>
        [RelayCommand]
        private void Update()
        {
            DefaultText = $"Обновлено: {DateTime.Now:HH:mm:ss}";
        }

        /// <summary>
        /// Автоматическая генерация ToggleCommand через source generator.
        /// Метод Toggle преобразуется в команду ToggleCommand с реализацией ICommand.
        /// </summary>
        [RelayCommand]
        private void Toggle()
        {
            IsActive = !IsActive;
        }

        /// <summary>
        /// Команда очистки с автоматической реализацией ICommand через библиотеку.
        /// Демонстрирует использование атрибутов для упрощения MVVM паттерна.
        /// </summary>
        [RelayCommand]
        private void Clear()
        {
            TwoWayText = "";
            SourceText = "";
        }

        /// <summary>
        /// Команда добавления элемента - генерация через CommunityToolkit.MVVM.
        /// Показывает автоматическое создание команд без ручной реализации ICommand.
        /// </summary>
        [RelayCommand]
        private void AddItem()
        {
            Items.Add($"Элемент {Items.Count + 1}");
        }

        /// <summary>
        /// Инициализация ViewModel с начальными данными.
        /// Заполняет коллекцию примерами для демонстрации привязки коллекций.
        /// </summary>
        public MainViewModel()
        {
            Items.Add("Пример 1");
            Items.Add("Пример 2");
        }

        /// <summary>
        /// Свойство текущего времени для демонстрации динамической привязки.
        /// Возвращает текущее время при каждом обращении.
        /// </summary>
        public DateTime CurrentTime => DateTime.Now;
    }
}