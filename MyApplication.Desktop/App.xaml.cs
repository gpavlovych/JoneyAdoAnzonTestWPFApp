using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;
using MyApplication.Desktop.Services.Impl;
using MyApplication.Desktop.ViewModels;

namespace MyApplication.Desktop
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class App
    {
        /// <summary>The logics to be performed during application startup</summary>
        /// <param name="e">An instance of <see cref="StartupEventArgs"/> to be used.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IRowService, RowService>();
            container.RegisterInstance(Dispatcher.CurrentDispatcher);
            container.RegisterType<IContext, WpfContext>();
            container.RegisterType<TTCRowViewModel>();
            container.RegisterType<TTbCRowViewModel>();
            container.RegisterType<T3RbRowViewModel>();
            container.RegisterInstance<Func<Action, Task>>(action => Task.Factory.StartNew(action));
            container.RegisterInstance<Func<TTCRow, TTCRowViewModel>>(row => container.Resolve<TTCRowViewModel>(new ParameterOverride("row", row)));
            container.RegisterInstance<Func<TTbCRow, TTbCRowViewModel>>(row => container.Resolve<TTbCRowViewModel>(new ParameterOverride("row", row)));
            container.RegisterInstance<Func<T3RbRow, T3RbRowViewModel>>(row => container.Resolve<T3RbRowViewModel>(new ParameterOverride("row", row)));
            ViewModelLocationProvider.SetDefaultViewModelFactory(viewModelType => container.Resolve(viewModelType));
        }
    }
}