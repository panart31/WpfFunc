using System;
using Xunit;
using WpfFunc;

namespace WpfFunc.Tests
{
    public class RelayCommandTests
    {
        [Fact]
        public void Execute_ActionIsCalled()
        {
            bool executed = false;
            var command = new RelayCommand(() => executed = true);
            command.Execute(null);
            Assert.True(executed);
        }

        [Fact]
        public void CanExecute_WithoutPredicate_ReturnsTrue()
        {
            var command = new RelayCommand(() => { });
            Assert.True(command.CanExecute(null));
        }

        [Fact]
        public void CanExecute_WithPredicate_ReturnsPredicateResult()
        {
            bool canExecute = false;
            var command = new RelayCommand(() => { }, () => canExecute);
            Assert.False(command.CanExecute(null));
            canExecute = true;
            Assert.True(command.CanExecute(null));
        }

        [Fact]
        public void Constructor_NullAction_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new RelayCommand(null));
        }
    }
}
