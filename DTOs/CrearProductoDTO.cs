using System.ComponentModel.DataAnnotations;
using WebApiTienda.Validaciones;

namespace WebApiTienda.DTOs
{
    public class CrearProductoDTO
    {
        [Required(ErrorMessage = "Es necesario ingresar el nombre del Producto")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} solo puede tener hasta 100 caracteres")]
        [PrimeraLetraMayuscula]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar una descripcion del Producto")]
        [StringLength(maximumLength: 500, ErrorMessage = "La descripcion solo puede tener hasta 500 caracteres")]
        [PrimeraLetraMayuscula]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un precio al Producto")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar el stock del Producto")]
        public int stock { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar la categoría del Producto")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo solo puede tener hasta 100 caracteres")]
        [PrimeraLetraMayuscula]
        public string categoria { get; set; }

    }
}
