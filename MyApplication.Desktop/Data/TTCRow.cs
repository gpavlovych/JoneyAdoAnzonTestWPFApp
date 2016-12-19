namespace MyApplication.Desktop.Data
{
    /// <summary>
    /// The TTC row entity.
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.Data.RowBase" />
    public class TTCRow : RowBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TTCRow"/> is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if selected; otherwise, <c>false</c>.
        /// </value>
        public bool Selected { get; set; }
    }
}