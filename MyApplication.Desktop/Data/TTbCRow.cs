namespace MyApplication.Desktop.Data
{
    /// <summary>
    /// The TTbC row entity.
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.Data.RowBase" />
    public class TTbCRow: RowBase
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TTbCRow"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool Selected { get; set; }
    }
}