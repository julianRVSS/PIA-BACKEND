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
            UsuarioACrear.Contraseña = CreateUsuario.Contraseña;
            UsuarioACrear.Direccion = CreateUsuario.Direccion;
            UsuarioACrear.Telefono = CreateUsuario.Telefono;
            

            dbContext.Add(UsuarioACrear);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        /*
        [HttpPost("/IniciarSesión")]
        public async Task<ActionResult> Post(UsuarioLoggeadoDTO LoginUsuario)
        {
            var UsuarioALoggear = new UsuarioLoggeado();
            UsuarioALoggear.email = LoginUsuario.Correo;
            UsuarioALoggear.contraseña = LoginUsuario.Contraseña;

            var existecorreo = await dbContext.Usuarios.AnyAsync(x => x.Correo == UsuarioALoggear.email);
            if(!existecorreo)
            {
                return NotFound("No hay ningún registro con ese correo en la base de datos.");
            }
            else
            {
                var usuario = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Correo == UsuarioALoggear.email);
                int IDdeUsuario = usuario.Id;

                var verificarcontraseña = await dbContext.Usuarios.FindAsync(IDdeUsuario);

                bool esContraseñaCorrecta = (verificarcontraseña.Contraseña == UsuarioALoggear.contraseña);

                if(esContraseñaCorrecta)
                {
                    IDUSUARIO = IDdeUsuario;
                }
                else
                {
                    return BadRequest("La contraseña es incorrecta");
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
        
   
        [HttpPut("{id}/{contraseña}")]
        public async Task<ActionResult> Put(int id, string contraseña, [FromBody] ModificarUsuarioDTO usuarioActualizado)

        {
            var usuarioexiste = await dbContext.Usuarios.FirstOrDefaultAsync(u => u.Id == id && u.Contraseña == contraseña);

            if (usuarioexiste == null)
            {
                return NotFound(); // El usuario no fue encontrado o la autenticación falló
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
                return NotFound("No hay ningún registro con ese Id de usuario en la base de datos.");
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