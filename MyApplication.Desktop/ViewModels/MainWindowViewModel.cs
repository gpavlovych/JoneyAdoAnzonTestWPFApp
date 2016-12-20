using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
        /// The backing field for the <see cref="SelectedRow"/> property.
        /// </summary>
        private RowViewModelBase selectedRow;

        /// <summary>
        /// The backing field for the <see cref="IsLoading"/> property.
        /// </summary>
        private bool isLoading;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public MainWindowViewModel(IRowService service, IContext context, Func<Action, Task> taskFactory, Func<TTCRow, TTCRowViewModel> ttcRowViewModelFactory, Func<TTbCRow, TTbCRowViewModel> ttbcRowViewModelFactory, Func<T3RbRow, T3RbRowViewModel> t3rbRowViewModelFactory)
        {
            this.IsLoading = false;
            this.Rows = new ObservableCollection<RowViewModelBase>();

            this.LoadCommand = new DelegateCommand(
                async () =>
                {
                    this.Rows.Clear();
                    this.IsLoading = true;
                    await taskFactory(() =>
                    {
                        foreach (var row in service.LoadRows())
                        {
                            var ttcRow = row as TTCRow;
                            if (ttcRow != null)
                            {
                                context.Invoke(()=>this.Rows.Add(ttcRowViewModelFactory(ttcRow)));
                            }

                            var ttbcRow = row as TTbCRow;
                            if (ttbcRow != null)
                            {
                                context.Invoke(() => this.Rows.Add(ttbcRowViewModelFactory(ttbcRow)));
                            }

                            var t3RbRow = row as T3RbRow;
                            if (t3RbRow != null)
                            {
                                context.Invoke(() => this.Rows.Add(t3rbRowViewModelFactory(t3RbRow)));
                            }
                        }
                        this.IsLoading = false;
                    });
                });

            this.AddNewTTCRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(ttcRowViewModelFactory(service.CreateTTC()));
                });

            this.AddNewTTbCRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(ttbcRowViewModelFactory(service.CreateTTbC()));
                });

            this.AddNewT3RbRowCommand = new DelegateCommand(
                () =>
                {
                    this.Rows.Add(t3rbRowViewModelFactory(service.CreateT3Rb()));
                });

            this.DeleteRowCommand = new DelegateCommand<RowViewModelBase>(
                row =>
                {
                    if (this.Rows.Remove(row))
                    {
                        service.Delete(row.Id);
                    }
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
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoading
        {
            get { return this.isLoading; }
            set
            {
                this.isLoading = value;
                OnPropertyChanged(() => this.IsLoading);
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