using System;
using System.Collections.ObjectModel;

namespace WpfFunc
{
    public class MainViewModel : ViewModelBase
    {
        private string _defaultText = "Панов Артем - ЛР1";
        public string DefaultText
        {
            get => _defaultText;
            set => SetField(ref _defaultText, value);
        }

        private string _twoWayText = "Двусторонний текст";
        public string TwoWayText
        {
            get => _twoWayText;
            set => SetField(ref _twoWayText, value);
        }

        private double _sliderValue = 50;
        public double SliderValue
        {
            get => _sliderValue;
            set => SetField(ref _sliderValue, value);
        }

        private bool _isActive = true;
        public bool IsActive
        {
            get => _isActive;
            set => SetField(ref _isActive, value);
        }

        private readonly string _oneTimeText = DateTime.Now.ToString("HH:mm:ss");
        public string OneTimeText => _oneTimeText;

        private string _sourceText = "Исходный текст";
        public string SourceText
        {
            get => _sourceText;
            set => SetField(ref _sourceText, value);
        }

        public ObservableCollection<string> Items { get; } = new();

        private RelayCommand _updateCommand;
        public RelayCommand UpdateCommand =>
            _updateCommand ??= new RelayCommand(() =>
            {
                DefaultText = $"Обновлено: {DateTime.Now:HH:mm:ss}";
            });

        private RelayCommand _toggleCommand;
        public RelayCommand ToggleCommand =>
            _toggleCommand ??= new RelayCommand(() =>
            {
                IsActive = !IsActive;
            });

        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand =>
            _clearCommand ??= new RelayCommand(() =>
            {
                TwoWayText = "";
                SourceText = "";
            });

        private RelayCommand _addItemCommand;
        public RelayCommand AddItemCommand =>
            _addItemCommand ??= new RelayCommand(() =>
            {
                Items.Add($"Элемент {Items.Count + 1}");
            });

        public MainViewModel()
        {
            Items.Add("Пример 1");
            Items.Add("Пример 2");
        }

        public DateTime CurrentTime => DateTime.Now;
    }
}