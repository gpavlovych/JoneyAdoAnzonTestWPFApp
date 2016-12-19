using System;

namespace MyApplication.Desktop.Data
{
    /// <summary>
    /// The base entity for all rows.
    /// </summary>
    public class RowBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}
