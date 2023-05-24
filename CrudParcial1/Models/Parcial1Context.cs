using Microsoft.EntityFrameworkCore;

namespace CrudParcial1.Models
{
    public class Parcial1Context:DbContext
    {
        public Parcial1Context(DbContextOptions<Parcial1Context> options): base(options) { }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
    }
}
