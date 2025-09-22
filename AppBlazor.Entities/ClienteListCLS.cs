using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlazor.Entities
{
    public class ClienteListCLS
    {
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
      
        public string nombreRepresentante { get; set; } = string.Empty;
        public double? LimiteCredito { get; set; }
    }
}
