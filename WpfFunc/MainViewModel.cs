using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfFunc
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _defaultText = "Панов Артем - ЛР1";

        [ObservableProperty]
        private string _twoWayText = "Двусторонний текст";

        [ObservableProperty]
        private double _sliderValue = 50;

        [ObservableProperty]
        private bool _isActive = true;

        private readonly string _oneTimeText = DateTime.Now.ToString("HH:mm:ss");
        public string OneTimeText => _oneTimeText;

        [ObservableProperty]
        private string _sourceText = "Исходный текст";

        public ObservableCollection<string> Items { get; } = new();

        [RelayCommand]
        private void Update()
        {
            DefaultText = $"Обновлено: {DateTime.Now:HH:mm:ss}";
        }

        [RelayCommand]
        private void Toggle()
        {
            IsActive = !IsActive;
        }

        [RelayCommand]
        private void Clear()
        {
            TwoWayText = "";
            SourceText = "";
        }

        [RelayCommand]
        private void AddItem()
        {
            Items.Add($"Элемент {Items.Count + 1}");
        }

        public MainViewModel()
        {
            Items.Add("Пример 1");
            Items.Add("Пример 2");
        }

        public DateTime CurrentTime => DateTime.Now;
    }
}