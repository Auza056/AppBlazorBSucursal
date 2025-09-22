using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public  class LibroListCLS
    {
        public int NroEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public int? Edad { get; set; }
        public string Cargo { get; set; } = null!;
        public DateTime? FechaContrato { get; set; }

        public string nombreSucursal { get; set; } = string.Empty;
        public string nombreJefe { get; set; } = string.Empty;
        public double? Ventas { get; set; }
    }
}
