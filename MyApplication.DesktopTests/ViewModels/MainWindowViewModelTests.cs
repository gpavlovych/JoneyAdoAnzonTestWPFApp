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
    /// Unit tests for the <see cref="MainWindowViewModel"/> class.
    /// </summary>
    [TestClass]
    public class MainWindowViewModelTests
    {
        #region Test commands

        #region AddNewTTCRowCommand

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.AddNewTTCRowCommand"/> Execute and CanExecute.
        /// </summary>
        [TestMethod]
        public void AddNewTTCRowCommandTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
            var unityContainerMock = fixture.Freeze<Mock<IUnityContainer>>();
            var returnedModel = fixture.Create<TTCRowViewModel>();
            unityContainerMock.Setup(
                    it => it.Resolve(typeof(TTCRowViewModel), It.IsAny<string>(), It.IsAny<ResolverOverride[]>()))
                .Returns(returnedModel);
            var target = fixture.Create<MainWindowViewModel>();

            //act
            var actualCanExecuteResult = target.AddNewTTCRowCommand.CanExecute(null);
            target.AddNewTTCRowCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Should().BeSameAs(returnedModel);
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
            var unityContainerMock = fixture.Freeze<Mock<IUnityContainer>>();
            var returnedModel = fixture.Create<TTbCRowViewModel>();
            unityContainerMock.Setup(
                    it => it.Resolve(typeof(TTbCRowViewModel), It.IsAny<string>(), It.IsAny<ResolverOverride[]>()))
                .Returns(returnedModel);
            var target = fixture.Create<MainWindowViewModel>();

            //act
            var actualCanExecuteResult = target.AddNewTTbCRowCommand.CanExecute(null);
            target.AddNewTTbCRowCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Should().BeSameAs(returnedModel);
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
            var unityContainerMock = fixture.Freeze<Mock<IUnityContainer>>();
            var returnedModel = fixture.Create<T3RbRowViewModel>();
            unityContainerMock.Setup(
                    it => it.Resolve(typeof(T3RbRowViewModel), It.IsAny<string>(), It.IsAny<ResolverOverride[]>()))
                .Returns(returnedModel);
            var target = fixture.Create<MainWindowViewModel>();

            //act
            var actualCanExecuteResult = target.AddNewT3RbRowCommand.CanExecute(null);
            target.AddNewT3RbRowCommand.Execute(null);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(1);
            target.Rows.Single().Should().BeSameAs(returnedModel);
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
            var deletedModel = fixture.Create<T3RbRowViewModel>();
            var target = fixture.Create<MainWindowViewModel>();
            target.Rows.Add(deletedModel);

            //act
            var actualCanExecuteResult = target.DeleteRowCommand.CanExecute(deletedModel);
            target.DeleteRowCommand.Execute(deletedModel);

            //assert
            actualCanExecuteResult.Should().BeTrue();
            target.Rows.Count.Should().Be(0);
        }

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.DeleteRowCommand"/> Execute and CanExecute with null instance.
        /// </summary>
        [TestMethod]
        public void DeleteRowCommandNullTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
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
        }

        /// <summary>
        /// Unit test for the <see cref="MainWindowViewModel.DeleteRowCommand"/> Execute and CanExecute with <see cref="RowViewModelBase"/> instance which doesn't exist in rows.
        /// </summary>
        [TestMethod]
        public void DeleteRowCommandNonExistingTest()
        {
            //arrange
            var fixture = new TestAutoFixture();
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