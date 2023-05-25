using WebApiTienda.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApiTienda.Controllers
{
    [ApiController]
    [Route("/CarritoCompra")]

    public class CarritoCompraController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CarritoCompraController(ApplicationDbContext context) 
        { 
            this.dbContext = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(CarritoCompra carrito)
        {
            var existeUsuario = await dbContext.Usuarios.AnyAsync(x => x.Id == carrito.UsuarioId);
            if (!existeUsuario)
            {
                return BadRequest("No existe el usuario");
            }
            dbContext.Add(carrito);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        //Los usuarios podrán agregar productos al carrito de compras, el cual debe estar
        //disponible para su visualización en todo momento y permitir la eliminación de productos. 
        /*
        [HttpGet("/ListaCarrito")]
        public async Task<ActionResult<List<CarritoCompra>>> GetAll()
        {
            return await dbContext.CarritoCompras.Include(x => x.Productos).ToListAsync();
        }
        */


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(CarritoCompra carrito, int id)
        {
            if(carrito.Id != id)
            {
                return BadRequest("El Id del carrito no coincide con el dado en la url.");
            }
            dbContext.Update(carrito);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.CarritoCompras.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound("No hay ningún carrito de compra con ese Id en la base de datos.");
            }
            dbContext.Remove(new CarritoCompra()
                {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }    
}