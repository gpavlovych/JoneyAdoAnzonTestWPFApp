using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>The main window view model.</summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// The backing field for the <see cref="SelectedRow"/> property.
        /// </summary>
        private RowViewModelBase selectedRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public MainWindowViewModel(IUnityContainer container)
        {
            this.Rows = new ObservableCollection<RowViewModelBase>();

            this.AddNewTTCRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(container.Resolve<TTCRowViewModel>());
                });

            this.AddNewTTbCRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(container.Resolve<TTbCRowViewModel>());
                });

            this.AddNewT3RbRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(container.Resolve<T3RbRowViewModel>());
                });

            this.DeleteRowCommand = new DelegateCommand<RowViewModelBase>(
                row =>
                {
                    this.Rows.Remove(row);
                });
        }

        /// <summary>
        /// Gets or sets the selected row.
        /// </summary>
        /// <value>
        /// The selected row.
        /// </value>
        public RowViewModelBase SelectedRow
        {
            get { return this.selectedRow; }
            set
            {
                this.selectedRow = value;
                OnPropertyChanged(() => this.SelectedRow);
            }
        }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public ObservableCollection<RowViewModelBase> Rows { get; }

        /// <summary>
        /// Gets the 'add new TTC row' command.
        /// </summary>
        public ICommand AddNewTTCRowCommand { get; }

        /// <summary>
        /// Gets the 'add new TTbC row' command.
        /// </summary>
        public ICommand AddNewTTbCRowCommand { get; }

        /// <summary>
        /// Gets the 'add new T3Rb row' command.
        /// </summary>
        public ICommand AddNewT3RbRowCommand { get; }

        /// <summary>
        /// Gets the 'delete row' command.
        /// </summary>
        public ICommand DeleteRowCommand { get; }
    }
}