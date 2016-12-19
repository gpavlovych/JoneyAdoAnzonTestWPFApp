using MyApplication.Desktop.ViewModels;

namespace MyApplication.Desktop.Data
{
    /// <summary>
    /// The T3Rb row entity.
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.Data.RowBase" />
    public class T3RbRow : RowBase
    {
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public T3RbRowState State { get; set; }
    }
}