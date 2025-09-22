using AppBlazor.Client.Pages;
using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class TipoLibroService
    {
        private List <TipoLibroCLS> lista;   
        public TipoLibroService() { 
         lista= new List<TipoLibroCLS>();
        
            lista.Add(new TipoLibroCLS() { idSucursal=1, nombreSucursal="La Paz"}  );
            lista.Add(new TipoLibroCLS() { idSucursal = 2, nombreSucursal = "Cochabamba" });
            lista.Add(new TipoLibroCLS() { idSucursal = 3, nombreSucursal = "Santa Cruz" });
            lista.Add(new TipoLibroCLS() { idSucursal = 4, nombreSucursal = "Tarija" });
        }
        public List<TipoLibroCLS> listarTipoLibros() { 
        return lista;
        }

        public int obtenerIdTipoLibro(string nombretipoLibro) { 
            var obj = lista.Where(p => p.nombreSucursal == nombretipoLibro).FirstOrDefault();
            if (obj == null) {
                return 0;
            }
            else { 
                return obj.idSucursal;
            }
        
        }

        public string obtenernombretipolibro(int idtipolibro)
        {
            var obj = lista.Where(p => p.idSucursal == idtipolibro).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.nombreSucursal;
            }

        }
    }
}
