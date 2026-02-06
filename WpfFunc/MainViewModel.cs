using System;
using System.Collections.ObjectModel;

namespace WpfFunc
{
    /// <summary>
    /// Основная ViewModel с данными и командами для демонстрации различных типов привязок.
    /// Содержит примеры свойств для OneWay, TwoWay, OneTime привязок и коллекций.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Свойство для демонстрации привязки по умолчанию (TwoWay для TextBox).
        /// Изменения в UI автоматически синхронизируются с ViewModel.
        /// </summary>
        private string _defaultText = "Панов Артем - ЛР1";
        public string DefaultText
        {
            get => _defaultText;
            set => SetField(ref _defaultText, value);
        }

        /// <summary>
        /// Свойство для демонстрации двухсторонней привязки между элементами.
        /// Изменения в любом связанном элементе обновляют все остальные.
        /// </summary>
        private string _twoWayText = "Двусторонний текст";
        public string TwoWayText
        {
            get => _twoWayText;
            set => SetField(ref _twoWayText, value);
        }

        /// <summary>
        /// Значение слайдера для синхронизации с другими элементами.
        /// Используется для демонстрации привязки числовых значений.
        /// </summary>
        private double _sliderValue = 50;
        public double SliderValue
        {
            get => _sliderValue;
            set => SetField(ref _sliderValue, value);
        }

        /// <summary>
        /// Флаг активности для демонстрации двухсторонней привязки с CheckBox.
        /// Определяет состояние активности приложения.
        /// </summary>
        private bool _isActive = true;
        public bool IsActive
        {
            get => _isActive;
            set => SetField(ref _isActive, value);
        }

        /// <summary>
        /// Свойство только для чтения для демонстрации OneTime привязки.
        /// Значение устанавливается один раз при создании объекта и не изменяется.
        /// </summary>
        private readonly string _oneTimeText = DateTime.Now.ToString("HH:mm:ss");
        public string OneTimeText => _oneTimeText;

        /// <summary>
        /// Исходный текст для демонстрации односторонней привязки.
        /// Изменения передаются только от источника к целевому элементу.
        /// </summary>
        private string _sourceText = "Исходный текст";
        public string SourceText
        {
            get => _sourceText;
            set => SetField(ref _sourceText, value);
        }

        /// <summary>
        /// Коллекция элементов для демонстрации привязки коллекций.
        /// Используется ObservableCollection для автоматического обновления UI при изменениях.
        /// </summary>
        public ObservableCollection<string> Items { get; } = new();

        /// <summary>
        /// Команда обновления текста с текущим временем.
        /// Демонстрирует обновление свойства через команду.
        /// </summary>
        private RelayCommand _updateCommand;
        public RelayCommand UpdateCommand =>
            _updateCommand ??= new RelayCommand(() =>
            {
                DefaultText = $"Обновлено: {DateTime.Now:HH:mm:ss}";
            });

        /// <summary>
        /// Команда переключения состояния активности.
        /// Инвертирует значение свойства IsActive.
        /// </summary>
        private RelayCommand _toggleCommand;
        public RelayCommand ToggleCommand =>
            _toggleCommand ??= new RelayCommand(() =>
            {
                IsActive = !IsActive;
            });

        /// <summary>
        /// Команда очистки текстовых полей.
        /// Очищает значения свойств TwoWayText и SourceText.
        /// </summary>
        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand =>
            _clearCommand ??= new RelayCommand(() =>
            {
                TwoWayText = "";
                SourceText = "";
            });

        /// <summary>
        /// Команда добавления элемента в коллекцию.
        /// Демонстрирует динамическое изменение коллекции с автоматическим обновлением UI.
        /// </summary>
        private RelayCommand _addItemCommand;
        public RelayCommand AddItemCommand =>
            _addItemCommand ??= new RelayCommand(() =>
            {
                Items.Add($"Элемент {Items.Count + 1}");
            });

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