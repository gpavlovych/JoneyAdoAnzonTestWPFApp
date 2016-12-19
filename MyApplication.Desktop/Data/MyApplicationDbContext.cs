using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;

namespace MyApplication.Desktop.Data
{
    /// <summary>
    /// The database context.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    [ExcludeFromCodeCoverage]
    public class MyApplicationDbContext: DbContext
    {
        /// <summary>
        /// Gets or sets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public DbSet<RowBase> Rows { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RowBase>()
                .Map<TTCRow>(m => m.Requires("RowType").HasValue("TTC"))
                .Map<TTbCRow>(m => m.Requires("RowType").HasValue("TTbC"))
                .Map<T3RbRow>(m => m.Requires("RowType").HasValue("T3Rb"));

            modelBuilder.Entity<RowBase>()
                .HasKey(m => m.Id)
                .Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        }
    }
}
