using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;
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
        #region Test commands

        #region SaveCommand

        /// <summary>
        /// Unit test for the <see cref="T3RbRowViewModel.SaveCommand"/> Execute and CanExecute.
        /// </summary>
        [TestMethod]
        public void SaveCommandTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var serviceMock = fixture.Freeze<Mock<IRowService>>();
            var row = fixture.Freeze<T3RbRow>();
            var context = fixture.Freeze<Mock<IContext>>();
            context.Setup(it => it.Invoke(It.IsAny<Action>())).Callback<Action>(action => action());
            var target = fixture.Create<T3RbRowViewModel>();

            //act
            var actualCanExecuteResult = target.SaveCommand.CanExecute(null);
            target.SaveCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            serviceMock.Verify(it=>it.Update(row));
        }

        #endregion SaveCommand
        
        #endregion Test commands

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