namespace MyApplication.Desktop.ViewModels
{
    /// <summary>
    /// View model for TTbC Row
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.ViewModels.RowViewModelBase" />
    public class TTbCRowViewModel : RowViewModelBase
    {
        /// <summary>
        /// Backing field for <see cref="Selected"/> property.
        /// </summary>
        private bool selected;

        /// <summary>
        /// Backing field for <see cref="Text"/> property.
        /// </summary>
        private string text;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TTbCRowViewModel"/> is selected.
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

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get { return this.text; }
            set
            {
                this.text = value;
                this.OnPropertyChanged(() => this.Text);
            }
        }
    }
}