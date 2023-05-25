namespace WebApiTienda.Entidades
{
    public class Producto
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }
 int vendidos { get; set; }

        public string categoria { get; set; }
        //Producto debe tener lista de detalles pedido
        public List<DetallePedido> DetallePedidos { get; set; }
    }
}
    