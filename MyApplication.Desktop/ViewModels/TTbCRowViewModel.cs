using MyApplication.Desktop.Data;
using MyApplication.Desktop.Services;

namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// View model for TTbC Row
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.ViewModels.RowViewModelBase" />
    public class TTbCRowViewModel : RowViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TTbCRowViewModel"/> class.
        /// </summary>
        /// <param name="rowService">The row service.</param>
        public TTbCRowViewModel(IRowService rowService, TTbCRow row) : base(rowService, row)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TTbCRowViewModel"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool Selected
        {
            get { return ((TTbCRow)this.Row).Selected; }
            set
            {
                ((TTbCRow)this.Row).Selected = value;
                this.OnPropertyChanged(() => this.Selected);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return ((TTbCRow)this.Row).Text; }
            set
            {
                ((TTbCRow)this.Row).Text = value;
                this.OnPropertyChanged(() => this.Text);
            }
        }

    }
}