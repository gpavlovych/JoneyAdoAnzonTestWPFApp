using System;
using System.Linq;
using System.Threading.Tasks;
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
    /// Unit tests for the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    [TestClass]
    public class MainWindowViewModelTests
    {
        #region Test commands

        #region LoadCommand

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.LoadCommand"/> Execute and CanExecute.
        /// </summary>
        [TestMethod]
        public void LoadCommandTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var serviceMock = fixture.Freeze<Mock<IRowService>>();
            var rows = fixture.CreateMany<TTCRow>().ToList();
            var expectedVms = rows.Select(row => new TTCRowViewModel(serviceMock.Object, row)).ToList();
            var loading = true;
            var running = true;
            fixture.Inject<Func<Action,Task>>(action=>Task.Run(() =>
            {
                while (running)
                {
                    
                }
                action();
                loading = false;
            }));
            fixture.Inject<Func<TTCRow, TTCRowViewModel>>(row=>new TTCRowViewModel(serviceMock.Object, row));
            var context = fixture.Freeze<Mock<IContext>>();
            context.Setup(it => it.Invoke(It.IsAny<Action>())).Callback<Action>(action => action());
            serviceMock.Setup(it => it.LoadRows()).Returns(rows);
            var target = fixture.Create<MainWindowViewModel>();

            //act
            var actualCanExecuteResult = target.LoadCommand.CanExecute(null);
            target.LoadCommand.Execute(null);

            //assert
            target.IsLoading.Should().BeTrue();
            target.Rows.Should().BeEmpty();
            running = false;
            while (loading)
            {
            }
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.ShouldBeEquivalentTo(expectedVms);
            target.IsLoading.Should().BeFalse();
        }

        #endregion LoadCommand

        #region AddNewTTCRowCommand

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.AddNewTTCRowCommand"/> Execute and CanExecute.
        /// </summary>
        [TestMethod]
        public void AddNewTTCRowCommandTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var serviceMock = fixture.Freeze<Mock<IRowService>>();
            fixture.Inject<Func<TTCRow, TTCRowViewModel>>(ttcrow => new TTCRowViewModel(serviceMock.Object, ttcrow));
            var row = fixture.Create<TTCRow>();
            serviceMock.Setup(it => it.CreateTTC()).Returns(row);
            var target = fixture.Create<MainWindowViewModel>();

            //act
            var actualCanExecuteResult = target.AddNewTTCRowCommand.CanExecute(null);
            target.AddNewTTCRowCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Id.Should().Be(row.Id);
        }

        #endregion AddNewTTCRowCommand

        #region AddNewTTbCRowCommand

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.AddNewTTbCRowCommand"/> Execute and CanExecute.
        /// </summary>
        [TestMethod]
        public void AddNewTTbCRowCommandTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var serviceMock = fixture.Freeze<Mock<IRowService>>();
            fixture.Inject<Func<TTbCRow, TTbCRowViewModel>>(ttbcrow => new TTbCRowViewModel(serviceMock.Object, ttbcrow));
            var row = fixture.Create<TTbCRow>();
            serviceMock.Setup(it => it.CreateTTbC()).Returns(row);
            var target = fixture.Create<MainWindowViewModel>();

            //act
            var actualCanExecuteResult = target.AddNewTTbCRowCommand.CanExecute(null);
            target.AddNewTTbCRowCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Id.Should().Be(row.Id);
        }

        #endregion AddNewTTbCRowCommand

        #region AddNewT3RbRowCommand

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.AddNewT3RbRowCommand"/> Execute and CanExecute.
        /// </summary>
        [TestMethod]
        public void AddNewT3RbRowCommandTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var serviceMock= fixture.Freeze<Mock<IRowService>>();
            fixture.Inject<Func<T3RbRow, T3RbRowViewModel>>(t3rbrow => new T3RbRowViewModel(serviceMock.Object, t3rbrow));
            var row = fixture.Create<T3RbRow>();
            serviceMock.Setup(it => it.CreateT3Rb()).Returns(row);
            var target = fixture.Create<MainWindowViewModel>();

            //act
            var actualCanExecuteResult = target.AddNewT3RbRowCommand.CanExecute(null);
            target.AddNewT3RbRowCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Id.Should().Be(row.Id);
        }

        #endregion AddNewT3RbRowCommand

        #region DeleteRowCommand

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.DeleteRowCommand"/> Execute and CanExecute with <see cref="RowViewModelBase"/> instance which exists in rows.
        /// </summary>
        [TestMethod]
        public void DeleteRowCommandExistingTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var rowService = fixture.Freeze<Mock<IRowService>>();
            var deletedModel = fixture.Create<T3RbRowViewModel>();
            var target = fixture.Create<MainWindowViewModel>();
            target.Rows.Add(deletedModel);

            //act
            var actualCanExecuteResult = target.DeleteRowCommand.CanExecute(deletedModel);
            target.DeleteRowCommand.Execute(deletedModel);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(0);
            rowService.Verify(it=>it.Delete(deletedModel.Id));
        }

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.DeleteRowCommand"/> Execute and CanExecute with null instance.
        /// </summary>
        [TestMethod]
        public void DeleteRowCommandNullTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var rowService = fixture.Freeze<Mock<IRowService>>();
            var returnedModel = fixture.Create<T3RbRowViewModel>();
            var target = fixture.Create<MainWindowViewModel>();
            target.Rows.Add(returnedModel);

            //act
            var actualCanExecuteResult = target.DeleteRowCommand.CanExecute(null);
            target.DeleteRowCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Should().BeSameAs(returnedModel);
            rowService.Verify(it => it.Delete(It.IsAny<Guid>()), Times.Never);
        }

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.DeleteRowCommand"/> Execute and CanExecute with <see cref="RowViewModelBase"/> instance which doesn't exist in rows.
        /// </summary>
        [TestMethod]
        public void DeleteRowCommandNonExistingTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var rowService = fixture.Freeze<Mock<IRowService>>();
            var returnedModel = fixture.Create<T3RbRowViewModel>();
            var deletedModel = fixture.Create<T3RbRowViewModel>();
            var target = fixture.Create<MainWindowViewModel>();
            target.Rows.Add(returnedModel);

            //act
            var actualCanExecuteResult = target.DeleteRowCommand.CanExecute(deletedModel);
            target.DeleteRowCommand.Execute(deletedModel);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Should().BeSameAs(returnedModel);
            rowService.Verify(it => it.Delete(It.IsAny<Guid>()), Times.Never);
        }

        #endregion DeleteRowCommand

        #endregion Test commands

        #region Test properties

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.SelectedRow"/> property and its PropertyChanged event.
        /// </summary>
        [TestMethod]
        public void SelectedRowTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var model = fixture.Create<T3RbRowViewModel>();
            var target = fixture.Create<MainWindowViewModel>();
            target.MonitorEvents();

            //act
            target.SelectedRow = model;
            var actualResult = target.SelectedRow;

            //assert
            actualResult.Should().BeSameAs(model);
            target.ShouldRaisePropertyChangeFor(it => it.SelectedRow);
        }

        #endregion Test properties
    }
}