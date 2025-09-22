using AppBlazor.Entities;
using System.IO;

namespace AppBlazor.Client.Services
{
    public class SucursalService
    {
        public event Func<string,string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarBusqueda(string ciudad,string director)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(ciudad, director);
            }

        }
        private List<SucursalListCLS> lista3;
        private LibroService libroService;

        public SucursalService(LibroService _representanteservice)
        {
            libroService = _representanteservice;
            lista3 = new List<SucursalListCLS>();
            lista3.Add(new SucursalListCLS
            {
                CodigoSucursal = 1,
                Ciudad = "Cochabamba",
                Region = "Oeste",
                nombreDirector = "Juan Pérez",
                ObjetivoVenta = 25000.00,
                VentasReales = 23000.50
            });

            lista3.Add(new SucursalListCLS
            {
                CodigoSucursal = 2,
                Ciudad = "La Paz",
                Region = "Oeste",
                nombreDirector = "Ana Gómez",
                ObjetivoVenta = 25000.00,
                VentasReales = 23000.50
            });
            lista3.Add(new SucursalListCLS
            {
                CodigoSucursal = 3,
                Ciudad = "Santa Cruz",
                Region = "Este",
                nombreDirector = "Julian Mendoza",
                ObjetivoVenta = 35000.00,
                VentasReales = 34000.00
            });
        }
        public List<SucursalListCLS> listarsucursales()
        {
            return lista3;
        }
        public void eliminarSucursal(int idScursal)
        {
            var listaQueda = lista3.Where(p => p.CodigoSucursal != idScursal).ToList();
            lista3 = listaQueda;
        }
        public SucursalFormCLS recuperarSucursalPorId(int idScursal)
        {
            var obj = lista3.Where(p => p.CodigoSucursal == idScursal).FirstOrDefault();
            if (obj != null)
            {
                return new SucursalFormCLS
                {
                    CodigoSucursal = obj.CodigoSucursal,
                    Ciudad = obj.Ciudad,
                    Region = obj.Region,
                    idDirector = libroService.obtenerIdRepresentante(obj.nombreDirector),
                    ObjetivoVenta = obj.ObjetivoVenta,
                    VentasReales= obj.VentasReales
                };
            }
            else
            {
                return new SucursalFormCLS();
            }
        }
        public void guardarSucursal(SucursalFormCLS osucursalFormCLS)
        {
            var existente = lista3.FirstOrDefault(p => p.CodigoSucursal == osucursalFormCLS.CodigoSucursal);
            if (existente != null)
            {
                // Actualiza los datos
                existente.Ciudad = osucursalFormCLS.Ciudad;
                existente.Region = osucursalFormCLS.Region;
                existente.nombreDirector = libroService.obtenerNombreRepresentante(osucursalFormCLS.idDirector);
                existente.ObjetivoVenta = osucursalFormCLS.ObjetivoVenta;
                existente.VentasReales = osucursalFormCLS.VentasReales;

            }
            else
            {
                // Agrega nuevo sucursal
                int NroSucursal = lista3.Select(p => p.CodigoSucursal).Max() + 1;
                lista3.Add(new SucursalListCLS
                {
                    CodigoSucursal = NroSucursal,
                    Ciudad = osucursalFormCLS.Ciudad,
                    Region = osucursalFormCLS.Region,
                    nombreDirector = libroService.obtenerNombreRepresentante(osucursalFormCLS.idDirector),
                    ObjetivoVenta = osucursalFormCLS.ObjetivoVenta,
                    VentasReales= osucursalFormCLS.VentasReales
                });
            }
        }
        public List<SucursalListCLS> filtrarSucursales(string ciudad, string director)
        {
            List<SucursalListCLS> l = listarsucursales();

            if (string.IsNullOrWhiteSpace(ciudad) && string.IsNullOrWhiteSpace(director))
            {
                return l;
            }

            if (!string.IsNullOrWhiteSpace(ciudad) && !string.IsNullOrWhiteSpace(director))
            {
                return l.Where(p =>
                    p.Ciudad.ToUpper().Contains(ciudad.ToUpper()) &&
                    p.nombreDirector.ToUpper().Contains(director.ToUpper())
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                return l.Where(p => p.Ciudad.ToUpper().Contains(ciudad.ToUpper())).ToList();
            }

            if (!string.IsNullOrWhiteSpace(director))
            {
                return l.Where(p => p.nombreDirector.ToUpper().Contains(director.ToUpper())).ToList();
            }

            return l;
        }
    }
}
