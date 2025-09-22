using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public  class SucursalFormCLS
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayor a 1")]
        public int CodigoSucursal { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Ciudad { get; set; } = null!;

            [Required(ErrorMessage = "Este campo es obligatorio")]
            public string Region { get; set; } = null!;

            [Required(ErrorMessage = "Este campo es obligatorio")]
            public int idDirector { get; set; } 

            [Required(ErrorMessage = "Este campo es obligatorio")]
            [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser numérico")]
            public double? ObjetivoVenta { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio")]
            [Range(0, double.MaxValue, ErrorMessage = "El valor debe ser numérico")]
            public double? VentasReales { get; set; }
        }
}
