using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MyApplication.Desktop.Data;

namespace MyApplication.Desktop.Services.Impl
{
    /// <summary>
    /// The implementation of IRowService.
    /// </summary>
    /// <seealso cref="MyApplication.Desktop.Services.IRowService" />
    [ExcludeFromCodeCoverage]
    public class RowService : IRowService
    {
        /// <summary>
        /// Loads the rows.
        /// </summary>
        /// <returns>
        /// The rows.
        /// </returns>
        public IEnumerable<RowBase> LoadRows()
        {
            using (var context = new MyApplicationDbContext())
            {
                return context.Rows.ToList();
            }
        }

        /// <summary>
        /// Creates the T3Rb row and saves it to the db.
        /// </summary>
        /// <returns>
        /// The created T3Rb.
        /// </returns>
        public T3RbRow CreateT3Rb()
        {
            using (var context = new MyApplicationDbContext())
            {
                var result = new T3RbRow();
                context.Rows.Add(result);
                context.SaveChanges();
                return result;
            }
        }

        /// <summary>
        /// Creates the TTbC row and saves it to the db.
        /// </summary>
        /// <returns>
        /// The created TTbC.
        /// </returns>
        public TTbCRow CreateTTbC()
        {
            using (var context = new MyApplicationDbContext())
            {
                var result = new TTbCRow();
                context.Rows.Add(result);
                context.SaveChanges();
                return result;
            }
        }

        /// <summary>
        /// Creates the TTC row and saves it to the db.
        /// </summary>
        /// <returns>
        /// The created TTC.
        /// </returns>
        public TTCRow CreateTTC()
        {
            using (var context = new MyApplicationDbContext())
            {
                var result = new TTCRow();
                context.Rows.Add(result);
                context.SaveChanges();
                return result;
            }
        }

        /// <summary>
        /// Updates the specified row.
        /// </summary>
        /// <param name="row">The row.</param>
        public void Update(RowBase row)
        {
            using (var context = new MyApplicationDbContext())
            {
                context.Rows.AddOrUpdate(row);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified row by its identifier.
        /// </summary>
        /// <param name="rowId">The row identifier.</param>
        public void Delete(Guid rowId)
        {
            using (var context = new MyApplicationDbContext())
            {
                context.Rows.Remove(context.Rows.Find(rowId));
                context.SaveChanges();
            }
        }
    }
}