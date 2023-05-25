using System.ComponentModel.DataAnnotations;

namespace WebApiTienda.DTOs
{
    public class ModificarUsuarioDTO
    {

        [Required(ErrorMessage = "Es necesario ingresar una dirección")]
        [StringLength(maximumLength: 30, ErrorMessage = "La dirección solo puede tener hasta 30 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un numero")]
        [StringLength(maximumLength: 10, ErrorMessage = "El telefono se compone de 10 numeros")]
        [MinLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "El Telefono debe contener solo números.")]
        public string Telefono { get; set; }
    }
}
