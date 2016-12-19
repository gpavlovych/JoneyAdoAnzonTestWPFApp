using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// View model for TTC Row 
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.ViewModels.RowViewModelBase" />
    public class TTCRowViewModel : RowViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TTCRowViewModel" /> class.
        /// </summary>
        /// <param name="rowService">The row service.</param>
        /// <param name="row">The row.</param>
        public TTCRowViewModel(IRowService rowService, TTCRow row): base(rowService, row)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TTCRowViewModel"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool Selected
        {
            get { return ((TTCRow)this.Row).Selected; }
            set
            {
                ((TTCRow)this.Row).Selected = value;
                this.OnPropertyChanged(() => this.Selected);
            }
        }
    }
}