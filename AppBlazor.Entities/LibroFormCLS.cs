using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Entities
{
    public class LibroFormCLS
    {



        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 1")]
        public int NroEmpleado { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; } = null;

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(18, int.MaxValue, ErrorMessage = "La edad mínima es 18 años")]
        public int? Edad { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = null!;


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Date, ErrorMessage = "La fecha no es válida")]
        public DateTime? FechaContrato { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una Sucursal")]

        public int idSucursal { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Jefe")]

        public int idJefe {  get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser numérico")]
        public double? Ventas { get; set; }

    }
}
