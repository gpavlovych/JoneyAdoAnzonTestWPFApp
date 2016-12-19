using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// View model for T3Rb Row.
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.ViewModels.RowViewModelBase" />
    public class T3RbRowViewModel : RowViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T3RbRowViewModel" /> class.
        /// </summary>
        /// <param name="rowService">The row service.</param>
        /// <param name="row">The row.</param>
        public T3RbRowViewModel(IRowService rowService, T3RbRow row) : base(rowService, row)
        {
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public T3RbRowState State
        {
            get { return ((T3RbRow)this.Row).State; }
            set
            {
                ((T3RbRow)this.Row).State = value;
                this.OnPropertyChanged(() => this.State);
            }
        }
    }
}