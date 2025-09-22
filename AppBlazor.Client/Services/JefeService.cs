using AppBlazor.Client.Pages;
using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class JefeService
    {
        private List<JefeCLS> lista;
        public JefeService()
        {
            lista = new List<JefeCLS>();

            lista.Add(new JefeCLS() { idJefe = 1, nombreJefe = "Antonio Cardenas" });
            lista.Add(new JefeCLS() { idJefe = 2, nombreJefe = "Samanta Rivera" });
            lista.Add(new JefeCLS() { idJefe = 3, nombreJefe = "Luis Almiron" });
        }
        public List<JefeCLS> listarTipoLibros()
        {
            return lista;
        }

        public int obtenerIdJefe(string nombreJefe)
        {
            var obj = lista.Where(p => p.nombreJefe == nombreJefe).FirstOrDefault();
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return obj.idJefe;
            }

        }

        public string obtenernombreJefe(int idJefe)
        {
            var obj = lista.Where(p => p.idJefe == idJefe).FirstOrDefault();
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.nombreJefe;  
            }

        }
    }
}
