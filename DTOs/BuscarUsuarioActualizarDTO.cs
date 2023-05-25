using System.ComponentModel.DataAnnotations;

namespace WebApiTienda.DTOs
{
    public class BuscarUsuarioActualizarDTO
    {
        [Required(ErrorMessage = "Es necesario ingresar un correo")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una contraseña")]
        [StringLength(maximumLength: 12, ErrorMessage = "La contraseña solo puede tener hasta 12 caracteres")]
        public string Contraseña { get; set; }
    }
}
