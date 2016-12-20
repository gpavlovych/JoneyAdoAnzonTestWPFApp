using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;
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
        #region Test commands

        #region SaveCommand

        /// <summary>
        /// Unit test for the <see cref="TTbCRowViewModel.SaveCommand"/> Execute and CanExecute.
        /// </summary>
        [TestMethod]
        public void SaveCommandTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var serviceMock = fixture.Freeze<Mock<IRowService>>();
            var row = fixture.Freeze<TTbCRow>();
            var context = fixture.Freeze<Mock<IContext>>();
            context.Setup(it => it.Invoke(It.IsAny<Action>())).Callback<Action>(action => action());
            var target = fixture.Create<TTbCRowViewModel>();

            //act
            var actualCanExecuteResult = target.SaveCommand.CanExecute(null);
            target.SaveCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            serviceMock.Verify(it => it.Update(row));
        }

        #endregion SaveCommand

        #endregion Test commands

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