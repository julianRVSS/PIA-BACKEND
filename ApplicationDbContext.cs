using Microsoft.EntityFrameworkCore;
using WebApiTienda.Entidades;

namespace WebApiTienda
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<CarritoCompra> CarritoCompras { get; set; }

        public DbSet<DetallePedido> DetallePedidos { get; set; }
    }
}
