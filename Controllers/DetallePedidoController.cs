using WebApiTienda.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiTienda.Controllers
{
    [ApiController]
    [Route("/Detalles")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DetallePedidoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(DetallePedido detalle)
        {
            var existePedido = await _context.Pedidos.AnyAsync(x => x.Id == detalle.PedidoId);
            if (!existePedido)
            {
                return BadRequest("No existe el pedido");
            }
            
            _context.Add(detalle);

            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("/ListaDetalle")]
        public async Task<ActionResult<List<DetallePedido>>> GetAll()
        {
            return await _context.DetallePedidos.Include(x => x.Producto).ToListAsync();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(DetallePedido detalle, int id)
        {
            if (detalle.Id != id)
            {
                return BadRequest("El Id del pedido no coincide con el dado en la url.");
            }
            _context.Update(detalle);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}/DetallePedido")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Pedidos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No hay ningún registro del pedido con ese Id en la base de datos.");
            }
            _context.Remove(new DetallePedido()
            {
                Id = id
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
