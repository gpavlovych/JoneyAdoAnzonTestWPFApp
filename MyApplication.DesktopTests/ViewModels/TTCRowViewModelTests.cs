using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Desktop.ViewModels;
using Ploeh.AutoFixture;

namespace MyApplication.Desktop.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the <see cref="TTCRowViewModel"/> class.
    /// </summary>
    [TestClass]
    public class TTCRowViewModelTests
    {
        #region Test properties

        /// <summary>
        /// Unit test for the <see cref="TTCRowViewModel.Selected"/> property and its PropertyChanged event.
        /// </summary>
        [TestMethod]
        public void SelectedTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var selected = fixture.Create<bool>();
            var target = fixture.Create<TTCRowViewModel>();
            target.MonitorEvents();

            //act
            target.Selected = selected;
            var actualResult = target.Selected;

            //assert
            actualResult.Should().Be(selected);
            target.ShouldRaisePropertyChangeFor(it => it.Selected);
        }

        #endregion Test properties
    }
}