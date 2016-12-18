using System.Diagnostics.CodeAnalysis;
using System.Windows;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;
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
            container.RegisterType<TTCRowViewModel>();
            container.RegisterType<TTbCRowViewModel>();
            container.RegisterType<T3RbRowViewModel>();
            ViewModelLocationProvider.SetDefaultViewModelFactory(viewModelType => container.Resolve(viewModelType));
        }
    }
}