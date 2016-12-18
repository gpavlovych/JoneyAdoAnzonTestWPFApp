using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyApplication.Desktop.ViewModels;
using Ploeh.AutoFixture;

namespace MyApplication.Desktop.Tests.ViewModels
{
    /// <summary>
    /// Unit tests for the <see cref="TTbCRowViewModel"/> class.
    /// </summary>
    [TestClass]
    public class TTbCRowViewModelTests
    {
        #region Test properties

        /// <summary>
        /// Unit test for the <see cref="TTbCRowViewModel.Selected"/> property and its PropertyChanged event.
        /// </summary>
        [TestMethod]
        public void SelectedTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var selected = fixture.Create<bool>();
            var target = fixture.Create<TTbCRowViewModel>();
            target.MonitorEvents();

            //act
            target.Selected = selected;
            var actualResult = target.Selected;

            //assert
            actualResult.Should().Be(selected);
            target.ShouldRaisePropertyChangeFor(it => it.Selected);
        }

        /// <summary>
        /// Unit test for the <see cref="TTbCRowViewModel.Text"/> property and its PropertyChanged event.
        /// </summary>
        [TestMethod]
        public void TextTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var text = fixture.Create<string>();
            var target = fixture.Create<TTbCRowViewModel>();
            target.MonitorEvents();

            //act
            target.Text = text;
            var actualResult = target.Text;

            //assert
            actualResult.Should().Be(text);
            target.ShouldRaisePropertyChangeFor(it => it.Text);
        }

        #endregion Test properties
    }
}