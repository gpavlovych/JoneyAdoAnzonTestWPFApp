using System;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;
using Prism.Mvvm;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// Base class for rows.
    /// </summary>
    /// <seealso cref="Prism.Mvvm.BindableBase" />
    public abstract class RowViewModelBase: BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RowViewModelBase"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        protected RowViewModelBase(IRowService service, RowBase row)
        {
            this.Row = row;

            this.SaveCommand = new DelegateCommand(() =>
            {
                service.Update(this.Row);
            });
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id
        {
            get { return this.Row.Id; }
            set
            {
                this.Row.Id = value;
                this.OnPropertyChanged(()=>this.Id);
            }
        }

        /// <summary>
        /// Gets the row.
        /// </summary>
        protected RowBase Row { get; }

        /// <summary>
        /// Gets the 'save' command.
        /// </summary>
        public ICommand SaveCommand { get; }
    }
}