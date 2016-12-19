using System;
using System.Collections.Generic;
using MyApplication.Desktop.Data;

namespace MyApplication.Desktop.Services
{
    /// <summary>
    /// Row service.
    /// </summary>
    public interface IRowService
    {
        /// <summary>
        /// Loads the rows.
        /// </summary>
        /// <returns>The rows.</returns>
        IEnumerable<RowBase> LoadRows();

        /// <summary>
        /// Creates the T3Rb row and saves it to the db.
        /// </summary>
        /// <returns>The created T3Rb.</returns>
        T3RbRow CreateT3Rb();

        /// <summary>
        /// Creates the TTbC row and saves it to the db.
        /// </summary>
        /// <returns>The created TTbC.</returns>
        TTbCRow CreateTTbC();

        /// <summary>
        /// Creates the TTC row and saves it to the db.
        /// </summary>
        /// <returns>The created TTC.</returns>
        TTCRow CreateTTC();

        /// <summary>
        /// Updates the specified row.
        /// </summary>
        /// <param name="row">The row.</param>
        void Update(RowBase row);

        /// <summary>
        /// Deletes the specified row by its identifier.
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        void Delete(Guid rowId);
    }
}
