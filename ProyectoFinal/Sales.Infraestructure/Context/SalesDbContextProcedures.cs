using Microsoft.EntityFrameworkCore;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.Context
{
    public partial class SalesContext
    {
        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObtenerNegocios>().HasNoKey().ToView(null);
            modelBuilder.Entity<ObtenerVentas>().HasNoKey().ToView(null);
            modelBuilder.Entity<ObtenerVentaDetalle>().HasNoKey().ToView(null);
        }
    }
}
