using System.ComponentModel.DataAnnotations;
using WebApiTienda.Validaciones;

namespace WebApiTienda.DTOs
{
    public class UsuarioLoggeadoDTO
    {
        [Required(ErrorMessage ="Es necesario ingresar un correo")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required(ErrorMessage ="Es necesario ingresar una contraseña")]
        public string Contraseña { get; set; }
    }
}
