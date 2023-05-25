namespace WebApiTienda.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contraseña {get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        //Usuario tiene una lista de pedidos
        public List<Pedido> Pedidos { get; set; }

        //Usuario tiene un carrito de compras
        public CarritoCompra Carrito { get; set; }

    }
}