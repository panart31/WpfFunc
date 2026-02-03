using System;
using System.Linq;
using Xunit;
using WpfFunc;

namespace WpfFunc.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void DefaultText_InitialValue_IsSet()
        {
            var viewModel = new MainViewModel();
            Assert.Equal("Панов Артем - ЛР1", viewModel.DefaultText);
        }

        [Fact]
        public void DefaultText_SetValue_RaisesPropertyChanged()
        {
            var viewModel = new MainViewModel();
            bool propertyChanged = false;
            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(MainViewModel.DefaultText))
                    propertyChanged = true;
            };

            viewModel.DefaultText = "Новое значение";
            Assert.True(propertyChanged);
            Assert.Equal("Новое значение", viewModel.DefaultText);
        }

        [Fact]
        public void TwoWayText_InitialValue_IsSet()
        {
            var viewModel = new MainViewModel();
            Assert.Equal("Двусторонний текст", viewModel.TwoWayText);
        }

        [Fact]
        public void TwoWayText_SetValue_UpdatesProperty()
        {
            var viewModel = new MainViewModel();
            viewModel.TwoWayText = "Тест";
            Assert.Equal("Тест", viewModel.TwoWayText);
        }

        [Fact]
        public void SliderValue_InitialValue_IsSet()
        {
            var viewModel = new MainViewModel();
            Assert.Equal(50.0, viewModel.SliderValue);
        }

        [Fact]
        public void SliderValue_SetValue_UpdatesProperty()
        {
            var viewModel = new MainViewModel();
            viewModel.SliderValue = 75.0;
            Assert.Equal(75.0, viewModel.SliderValue);
        }

        [Fact]
        public void IsActive_InitialValue_IsTrue()
        {
            var viewModel = new MainViewModel();
            Assert.True(viewModel.IsActive);
        }

        [Fact]
        public void IsActive_Toggle_ChangesValue()
        {
            var viewModel = new MainViewModel();
            bool initialValue = viewModel.IsActive;
            viewModel.ToggleCommand.Execute(null);
            Assert.NotEqual(initialValue, viewModel.IsActive);
        }

        [Fact]
        public void OneTimeText_IsReadOnly()
        {
            var viewModel = new MainViewModel();
            string initialValue = viewModel.OneTimeText;
            Assert.NotNull(initialValue);
        }

        [Fact]
        public void SourceText_InitialValue_IsSet()
        {
            var viewModel = new MainViewModel();
            Assert.Equal("Исходный текст", viewModel.SourceText);
        }

        [Fact]
        public void UpdateCommand_Execute_UpdatesDefaultText()
        {
            var viewModel = new MainViewModel();
            string initialText = viewModel.DefaultText;
            viewModel.UpdateCommand.Execute(null);
            Assert.NotEqual(initialText, viewModel.DefaultText);
            Assert.Contains("Обновлено:", viewModel.DefaultText);
        }

        [Fact]
        public void ClearCommand_Execute_ClearsTexts()
        {
            var viewModel = new MainViewModel();
            viewModel.TwoWayText = "Тест";
            viewModel.SourceText = "Тест";
            viewModel.ClearCommand.Execute(null);
            Assert.Equal("", viewModel.TwoWayText);
            Assert.Equal("", viewModel.SourceText);
        }

        [Fact]
        public void Items_InitialCount_IsTwo()
        {
            var viewModel = new MainViewModel();
            Assert.Equal(2, viewModel.Items.Count);
        }

        [Fact]
        public void AddItemCommand_Execute_AddsItem()
        {
            var viewModel = new MainViewModel();
            int initialCount = viewModel.Items.Count;
            viewModel.AddItemCommand.Execute(null);
            Assert.Equal(initialCount + 1, viewModel.Items.Count);
        }
    }
}
