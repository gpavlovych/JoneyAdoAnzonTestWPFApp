namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// View model for TTC Row 
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.ViewModels.RowViewModelBase" />
    public class TTCRowViewModel : RowViewModelBase
    {
        /// <summary>
        /// Backing field for <see cref="Selected"/> property.
        /// </summary>
        private bool selected;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TTCRowViewModel"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool Selected
        {
            get { return this.selected; }
            set
            {
                this.selected = value;
                this.OnPropertyChanged(() => this.Selected);
            }
        }
    }
}