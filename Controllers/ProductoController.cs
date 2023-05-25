using WebApiTienda.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTienda.DTOs;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Cors;
namespace WebApiTienda.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/Producto")]

    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ProductoController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        
        [HttpPost("/CrearProducto")]
        public async Task<ActionResult> Post(CrearProductoDTO CreateProducto)
        {
            var ProductoACrear = new Producto();
            ProductoACrear.nombre = CreateProducto.nombre;
            ProductoACrear.descripcion = CreateProducto.descripcion;
            ProductoACrear.precio = CreateProducto.precio;
            ProductoACrear.stock = CreateProducto.stock;
            ProductoACrear.categoria = CreateProducto.categoria;


            dbContext.Add(ProductoACrear);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        

        /*
        [HttpGet("/ListaUsuario")]
        public async Task<ActionResult<List<Usuario>>> GetAll()
        {
            return await dbContext.Usuarios.Include(x => x.Pedidos).ToListAsync();
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Usuario usuario, int id)
        {
            if (usuario.Id != id)
            {
                return BadRequest("El Id del usuario no coincide con el dado en la url.");
            }
            dbContext.Update(usuario);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Usuarios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No hay ningún registro con ese Id de usuario en la base de datos.");
            }
            dbContext.Remove(new Usuario()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        */
    }
}