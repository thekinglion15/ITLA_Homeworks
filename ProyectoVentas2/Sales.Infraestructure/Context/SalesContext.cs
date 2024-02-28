using Microsoft.EntityFrameworkCore;
using Sales.Domain.Entities;

namespace Sales.Infraestructure.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) :base(options) { }

        #region "DbSet"
        public DbSet<Business>? Businesses { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Configuration>? Configurations { get; set; }
        public DbSet<CorrelativeNumber>? CorrelativeNumbers { get; set; }
        public DbSet<Menu>? Menus { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<RoleMenu>? RoleMenus { get; set; }
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<SaleDetail>? SaleDetails { get; set; }
        public DbSet<TypeDocSale>? TypeDocSales { get; set; }
        public DbSet<User>? Users { get; set; }
        #endregion
    }
}
