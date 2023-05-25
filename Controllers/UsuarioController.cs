using WebApiTienda.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTienda.DTOs;
using AutoMapper;

namespace WebApiTienda.Controllers
{
    [ApiController]
    [Route("/Usuario")]

    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UsuarioController(ApplicationDbContext context, IMapper mapper)
        {
            this.dbContext = context;
            this.mapper = mapper;
        }

        [HttpPost("/CrearUsuario")]
        public async Task<ActionResult> Post(CrearUsuarioDTO CreateUsuario)
        {
            var UsuarioACrear = new Usuario();
            
            
            UsuarioACrear.Nombre = CreateUsuario.Nombre;
            UsuarioACrear.Correo = CreateUsuario.Correo;
            UsuarioACrear.Contrase�a = CreateUsuario.Contrase�a;
            UsuarioACrear.Direccion = CreateUsuario.Direccion;
            UsuarioACrear.Telefono = CreateUsuario.Telefono;
            

            dbContext.Add(UsuarioACrear);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        /*
        [HttpPost("/IniciarSesi�n")]
        public async Task<ActionResult> Post(UsuarioLoggeadoDTO LoginUsuario)
        {
            var UsuarioALoggear = new UsuarioLoggeado();
            UsuarioALoggear.email = LoginUsuario.Correo;
            UsuarioALoggear.contrase�a = LoginUsuario.Contrase�a;

            var existecorreo = await dbContext.Usuarios.AnyAsync(x => x.Correo == UsuarioALoggear.email);
            if(!existecorreo)
            {
                return NotFound("No hay ning�n registro con ese correo en la base de datos.");
            }
            else
            {
                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Correo == UsuarioALoggear.email);
                int IDdeUsuario = usuario.Id;

                var verificarcontrase�a = await dbContext.Usuarios.FindAsync(IDdeUsuario);

                bool esContrase�aCorrecta = (verificarcontrase�a.Contrase�a == UsuarioALoggear.contrase�a);

                if(esContrase�aCorrecta)
                {
                    IDUSUARIO = IDdeUsuario;
                }
                else
                {
                    return BadRequest("La contrase�a es incorrecta");
                }
            }


            await dbContext.SaveChangesAsync();

            return Ok();
        }
        */

        [HttpGet("/ListaDeUsuarios")]
        public async Task<ActionResult<List<ListaUsuariosDTO>>> Get()
        {
            var usuarios = await dbContext.Usuarios.ToListAsync();
            return mapper.Map<List<ListaUsuariosDTO>>(usuarios);
        }
        
   
        [HttpPut("{id}/{contrase�a}")]
        public async Task<ActionResult> Put(int id, string contrase�a, [FromBody] ModificarUsuarioDTO usuarioActualizado)

        {
            var usuarioexiste = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id && u.Contrase�a == contrase�a);

            if (usuarioexiste == null)
            {
                return NotFound(); // El usuario no fue encontrado o la autenticaci�n fall�
            }

            var actualizacion = mapper.Map<Usuario>(usuarioActualizado);

            actualizacion.Id = id;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Usuarios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No hay ning�n registro con ese Id de usuario en la base de datos.");
            }
            dbContext.Remove(new Usuario()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}