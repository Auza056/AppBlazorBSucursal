using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AppBlazor.Entities
{
    public class ClienteFormCLS
    {


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 1")]
        public int CodigoCliente { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string NombreCliente { get; set; } = null!;


        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Representante de Ventas")]
        public int idRepresentante { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser numérico")]
        public double? LimiteCredito { get; set; }
    }
}
