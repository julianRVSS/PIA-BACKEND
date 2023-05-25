namespace WebApiTienda.Entidades
{
    public class CarritoCompra
    {
        public int Id { get; set; }

        public string estado_pedido { get; set; }

        //Carrito de compras pertenece a un usuario
        public Usuario usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}