using System.Linq;
using FluentAssertions;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Desktop.ViewModels;
using Ploeh.AutoFixture;

namespace MyApplication.Desktop.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the <see cref="T3RbRowViewModel"/> class.
    /// </summary>
    [TestClass]
    public class T3RbRowViewModelTests
    {
        #region Test properties

        /// <summary>
        /// Unit test for the <see cref="T3RbRowViewModel.State"/> property and its PropertyChanged event.
        /// </summary>
        [TestMethod]
        public void StateTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var state = fixture.Create<T3RbRowState>();
            var target = fixture.Create<T3RbRowViewModel>();
            target.MonitorEvents();

            //act
            target.State = state;
            var actualResult = target.State;

            //assert
            actualResult.Should().Be(state);
            target.ShouldRaisePropertyChangeFor(it => it.State);
        }

        #endregion Test properties
    }
}