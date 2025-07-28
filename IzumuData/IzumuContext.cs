//-----------------------------------------------------------------------
// <copyright file="IzumuContext" company="Izumu">
//     All rights reserved.
// </copyright>
// <author>aifred</author>
// <date>18/07/2025 18:01:51</date>
// <summary>Código fuente interfaz IzumuContext.</summary>
//-----------------------------------------------------------------------
namespace IzumuData
{
    using IzumuData.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// IzumuContext.
    /// </summary>
	public class IzumuContext : DbContext
    {
        #region Attributes

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IzumuContext"/> class.
        /// </summary>
        /// <param name="options"></param>
        public IzumuContext(DbContextOptions<IzumuContext> options) : base(options)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Customer Entity.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Transaction Entity.
        /// </summary>
        public DbSet<DocumentType> DocumentsTypes { get; set; }

        /// <summary>
        /// Transaction Entity.
        /// </summary>
        public DbSet<Plan> Plans { get; set; }

        #endregion

        #region Methods And Functions

        /// <summary>
        /// Method used to configure connection string.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
        }

        /// <summary>
        /// Method used to configure entities of database model.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customers", "dbo")
                .HasKey(h => h.Id);

            modelBuilder.Entity<Customer>()
                .HasOne(h => h.DocumentType)
                .WithMany(w => w.Customers)
                .HasForeignKey(h => h.DocumentTypeId);

            modelBuilder.Entity<Customer>()
                .HasOne(h => h.Plan)
                .WithMany(w => w.Customers)
                .HasForeignKey(h => h.PlanId);

            modelBuilder.Entity<Plan>()
                .ToTable("Plans", "dbo")
                .HasKey(h => h.Id);

            modelBuilder.Entity<DocumentType>()
                .ToTable("DocumentsTypes", "dbo")
                .HasKey(h => h.Id);

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
