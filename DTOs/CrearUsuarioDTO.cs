using System.ComponentModel.DataAnnotations;
using WebApiTienda.Validaciones;

namespace WebApiTienda.DTOs
{
    public class CrearUsuarioDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")] 
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="Es necesario ingresar un correo")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required(ErrorMessage ="Es necesario ingresar una contraseña")]
        [StringLength(maximumLength: 12, ErrorMessage = "La contraseña solo puede tener hasta 12 caracteres")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una dirección")]
        [StringLength(maximumLength: 30, ErrorMessage = "La dirección solo puede tener hasta 30 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage ="Es necesario ingresar un numero")]
        [StringLength(maximumLength: 10, ErrorMessage = "El telefono se compone de 10 numeros")]
        [MinLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El Telefono debe contener solo números.")]
        public string Telefono { get; set; }
    }
}
