using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public  class SucursalListCLS
    {

        public int CodigoSucursal { get; set; }

      
        public string Ciudad { get; set; } = null!;

        public string Region { get; set; } = null!;

        public string nombreDirector { get; set; } = null!;

        public double? ObjetivoVenta { get; set; }

    
        public double? VentasReales { get; set; }
    }
}
