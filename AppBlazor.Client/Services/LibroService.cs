

using AppBlazor.Client.Pages.Representante;
using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class LibroService
    {
        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarBusqueda(string nombreRepresentante)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(nombreRepresentante);
            }

        }

        private List<LibroListCLS> lista;
        private TipoLibroService tipolibroservice;
        private JefeService jefeService;
        public LibroService(TipoLibroService _tipolibroservice, JefeService _jefeservice) {
            tipolibroservice = _tipolibroservice;
            jefeService = _jefeservice;
        lista= new List<LibroListCLS>();
            lista.Add(new LibroListCLS
            {
                NroEmpleado = 1,
                Nombre = "Juan Pérez",
                Edad = 30,
                Cargo = "Director",
                FechaContrato = new DateTime(2021, 5, 12),
                nombreSucursal = "Cochabamba",
                nombreJefe= "Samanta Rivera",
                Ventas = 15000.50
            });

            lista.Add(new LibroListCLS
            {
                NroEmpleado = 2,
                Nombre = "Ana Gómez",
                Edad = 25,
                Cargo = "Director",
                FechaContrato = new DateTime(2022, 3, 8),
                nombreSucursal = "La Paz",
                nombreJefe = "Luis Almiron",
                Ventas = 8500.00
            });
            lista.Add(new LibroListCLS
            {
                NroEmpleado = 3,
                Nombre = "Julian Mendoza",
                Edad = 30,
                Cargo = "Director",
                FechaContrato = new DateTime(2023, 5, 8),
                nombreSucursal = "Santa Cruz",
                nombreJefe = "Luis Almiron",
                Ventas = 2500.00
            });
            lista.Add(new LibroListCLS
            {
                NroEmpleado = 4,
                Nombre = "Gabriel Jesus",
                Edad = 21,
                Cargo = "Director",
                FechaContrato = new DateTime(2024, 3, 9),
                nombreSucursal = "Tarija",
                nombreJefe = "Antonio Cardenas",
                Ventas = 10500.00
            });
            lista.Add(new LibroListCLS
            {
                NroEmpleado = 5,
                Nombre = "Juan Hernandez",
                Edad = 18,
                Cargo = "Junior",
                FechaContrato = new DateTime(2025, 3, 9),
                nombreSucursal = "Tarija",
                nombreJefe = "Antonio Cardenas",
                Ventas = 3800.00
            });
        }
        public List<LibroListCLS> listarlibros() {
            return lista;
        }
        public void eliminarLibro(int idLibro)
        {
            var listaQueda = lista.Where( p => p.NroEmpleado != idLibro).ToList();
            lista = listaQueda;
        }
        public LibroFormCLS recuperarLibroPorId(int idLibro) {
            var obj = lista.Where( p => p.NroEmpleado == idLibro).FirstOrDefault();
            if (obj != null) {
                return new LibroFormCLS { NroEmpleado = obj.NroEmpleado, Nombre = obj.Nombre, Edad= obj.Edad, Cargo=obj.Cargo, FechaContrato= obj.FechaContrato, 
                    idJefe=jefeService.obtenerIdJefe(obj.nombreJefe), idSucursal= tipolibroservice.obtenerIdTipoLibro(obj.nombreSucursal), Ventas=obj.Ventas};
            }
            else
            {
                return new LibroFormCLS();
            }
        }
        public void guardarLibro(LibroFormCLS oLibroFormCLS)
        {
            var existente = lista.FirstOrDefault(p => p.NroEmpleado == oLibroFormCLS.NroEmpleado);
            if (existente != null)
            {
                // Actualiza los datos
                existente.Nombre = oLibroFormCLS.Nombre;
                existente.nombreJefe = jefeService.obtenernombreJefe(oLibroFormCLS.idJefe);
                existente.nombreSucursal = tipolibroservice.obtenernombretipolibro(oLibroFormCLS.idSucursal);
                // si querés también resumen: existente.resumen = oLibroFormCLS.resumen;
            }
            else
            {
                // Agrega nuevo libro
                int Nroempleado = lista.Select(p => p.NroEmpleado).Max() + 1;
                lista.Add(new LibroListCLS
                {
                    NroEmpleado = Nroempleado,
                    Nombre = oLibroFormCLS.Nombre,
                    nombreJefe = jefeService.obtenernombreJefe(oLibroFormCLS.idJefe),
                    nombreSucursal= tipolibroservice.obtenernombretipolibro(oLibroFormCLS.idSucursal)
                });
            }
        }
        public List<LibroListCLS> filtrarRepresentantes(string nombreRepresentante)
        {
            List<LibroListCLS> l = listarlibros();
            if (nombreRepresentante == "") { return l; }
            else {
            List<LibroListCLS> listafiltrada = l.Where(p=> p.Nombre.ToUpper().Contains(nombreRepresentante.ToUpper())).ToList();
                return listafiltrada;
            }
        }


        public int obtenerIdRepresentante(string nombreRepresentante)
        {
            var obj = lista
                .FirstOrDefault(p => p.Nombre.Equals(nombreRepresentante, StringComparison.OrdinalIgnoreCase));

            return obj == null ? 0 : obj.NroEmpleado;
        }
        public string obtenerNombreRepresentante(int idRepresentante)
        {
            var obj = lista.FirstOrDefault(p => p.NroEmpleado == idRepresentante);
            return obj == null ? "" : obj.Nombre;
        }


    }
}
