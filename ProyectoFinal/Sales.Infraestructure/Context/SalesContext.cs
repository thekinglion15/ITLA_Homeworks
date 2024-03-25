using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Context
{
    public partial class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) :base(options) { }

        #region "DbSet"
        public DbSet<Business>? Businesses { get; set; }
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<SaleDetail>? SaleDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingGeneratedProcedures(modelBuilder);
        }
    }
}
