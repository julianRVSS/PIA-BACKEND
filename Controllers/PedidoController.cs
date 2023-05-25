using WebApiTienda.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiTienda.Controllers
{
    [ApiController]
    [Route("/Pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Pedido pedido)
        {
            var existeUsuario = await _context.Usuarios.AnyAsync(x => x.Id == pedido.UsuarioId);
            if (!existeUsuario)
            {
                return BadRequest("No existe el usuario");
            }
            _context.Add(pedido);

            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpGet("/ListaPedido")]
        public async Task<ActionResult<List<Pedido>>> GetAll()
        {
            return await _context.Pedidos.ToListAsync();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Pedido pedido, int id)
        {
            if (pedido.Id != id)
            {
                return BadRequest("El Id del pedido no coincide con el dado en la url.");
            }
            _context.Update(pedido);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}/Ticket")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await _context.Pedidos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No hay ningún registro de pedido con ese Id en la base de datos.");
            }
            _context.Remove(new Pedido()
            {
                Id = id
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}