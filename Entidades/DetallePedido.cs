namespace WebApiTienda.Entidades
{
    public class DetallePedido
    {
        public int Id { get ; set; }   

        public int cantidad { get; set; }

        //Un detalle pedido pertenece a un pedido
        public Pedido Pedido { get; set;}
        public int PedidoId { get; set; }

        //Un detalle pedido pertenece a un producto
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }
    }
}