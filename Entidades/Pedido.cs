namespace WebApiTienda.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }

        public string fecha_hora { get; set; }

        public string estado { get; set; }

        //public string metodo_pago { get; set; }

       
        //Un pedido pertenece a un usuario
        public Usuario Usuario { get; set;}
        public int UsuarioId { get; set; }

        //Pedido debe tener lista de detalles pedido
        public List<DetallePedido> DetallePedidos { get; set; }
        //Metodo de pago
    }
}