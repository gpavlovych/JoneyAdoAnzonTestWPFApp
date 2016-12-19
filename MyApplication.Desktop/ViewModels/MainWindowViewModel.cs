using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Unity;
using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>The main window view model.</summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// The service
        /// </summary>
        private readonly IRowService service;

        /// <summary>
        /// The backing field for the <see cref="SelectedRow"/> property.
        /// </summary>
        private RowViewModelBase selectedRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public MainWindowViewModel(IRowService service, IUnityContainer container)
        {
            this.service = service;
            this.Rows = new ObservableCollection<RowViewModelBase>();

            this.LoadCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Clear();
                    foreach (var row in this.service.LoadRows())
                    {
                        var ttcRow = row as TTCRow;
                        if (ttcRow != null)
                        {
                            this.Rows.Add(new TTCRowViewModel(this.service, ttcRow));
                        }

                        var ttbcRow = row as TTbCRow;
                        if (ttbcRow != null)
                        {
                            this.Rows.Add(new TTbCRowViewModel(this.service, ttbcRow));
                        }

                        var t3RbRow = row as T3RbRow;
                        if (t3RbRow != null)
                        {
                            this.Rows.Add(new T3RbRowViewModel(this.service, t3RbRow));
                        }
                    }
                });

            this.AddNewTTCRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(new TTCRowViewModel(this.service, this.service.CreateTTC()));
                });

            this.AddNewTTbCRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(new TTbCRowViewModel(this.service, this.service.CreateTTbC()));
                });

            this.AddNewT3RbRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(new T3RbRowViewModel(this.service, this.service.CreateT3Rb()));
                });

            this.DeleteRowCommand = new DelegateCommand<RowViewModelBase>(
                row =>
                {
                    this.service.Delete(row.Id);
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
        /// Gets the 'load' command.
        /// </summary>
        public ICommand LoadCommand { get; }

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