using System.ComponentModel;
using Xunit;
using WpfFunc;

namespace WpfFunc.Tests
{
    public class ViewModelBaseTests
    {
        private class TestViewModel : ViewModelBase
        {
            private string _testProperty;
            public string TestProperty
            {
                get => _testProperty;
                set => SetField(ref _testProperty, value);
            }
        }

        [Fact]
        public void SetField_NewValue_RaisesPropertyChanged()
        {
            var viewModel = new TestViewModel();
            bool propertyChanged = false;
            viewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(TestViewModel.TestProperty))
                    propertyChanged = true;
            };

            viewModel.TestProperty = "Новое значение";
            Assert.True(propertyChanged);
        }

        [Fact]
        public void SetField_SameValue_DoesNotRaisePropertyChanged()
        {
            var viewModel = new TestViewModel();
            viewModel.TestProperty = "Значение";
            bool propertyChanged = false;
            viewModel.PropertyChanged += (s, e) => propertyChanged = true;

            viewModel.TestProperty = "Значение";
            Assert.False(propertyChanged);
        }

        [Fact]
        public void SetField_UpdatesValue()
        {
            var viewModel = new TestViewModel();
            viewModel.TestProperty = "Тест";
            Assert.Equal("Тест", viewModel.TestProperty);
        }
    }
}
