

using AppBlazor.Client.Pages.Representante;
using AppBlazor.Client.Pages.Cliente;
using AppBlazor.Entities;

namespace AppBlazor.Client.Services
{
    public class ClienteService
    {
        public event Func<string, Task> OnSearch = delegate { return Task.CompletedTask; };

        public async Task notificarBusqueda(string nombreRepresentante)
        {
            if (OnSearch != null)
            {
                await OnSearch.Invoke(nombreRepresentante);
            }

        }
        private List<ClienteListCLS> lista2;
        private LibroService libroService;
       
        public ClienteService(LibroService _representanteservice)
        {
            libroService = _representanteservice;
            lista2 = new List<ClienteListCLS>();
            lista2.Add(new ClienteListCLS
            {
                CodigoCliente = 1,
                NombreCliente = "Samuel Vicente",
                nombreRepresentante = "Juan Pérez",
                LimiteCredito = 1500.50
            });

            lista2.Add(new ClienteListCLS
            {
                CodigoCliente = 2,
                NombreCliente = "Bruno Campos",
                nombreRepresentante = "Julian Mendoza",
                LimiteCredito = 3000
            });
            lista2.Add(new ClienteListCLS
            {
                CodigoCliente = 3,
                NombreCliente = "Eduardo Sanjines",
                nombreRepresentante = "Julian Mendoza",
                LimiteCredito = 2500
            });
        }
        public List<ClienteListCLS> listarclientes()
        {
            return lista2;
        }
        public void eliminarCliente(int idCliente)
        {
            var listaQueda = lista2.Where(p => p.CodigoCliente != idCliente).ToList();
            lista2 = listaQueda;
        }
        public ClienteFormCLS recuperarClientePorId(int idCliente)
        {
            var obj = lista2.Where(p => p.CodigoCliente == idCliente).FirstOrDefault();
            if (obj != null)
            {
                return new ClienteFormCLS
                {
                    CodigoCliente = obj.CodigoCliente,
                    NombreCliente = obj.NombreCliente,
                    idRepresentante = libroService.obtenerIdRepresentante(obj.nombreRepresentante),
                    LimiteCredito = obj.LimiteCredito
                };
            }
            else
            {
                return new ClienteFormCLS();
            }
        }
        public void guardarCliente(ClienteFormCLS oclienteFormCLS)
        {
            var existente = lista2.FirstOrDefault(p => p.CodigoCliente == oclienteFormCLS.CodigoCliente);
            if (existente != null)
            {
                // Actualiza los datos
                existente.NombreCliente = oclienteFormCLS.NombreCliente;
                existente.nombreRepresentante = libroService.obtenerNombreRepresentante(oclienteFormCLS.idRepresentante);
                existente.LimiteCredito = oclienteFormCLS.LimiteCredito;
               
            }
            else
            {
                // Agrega nuevo cliente
                int Nrocliente = lista2.Select(p => p.CodigoCliente).Max() + 1;
                lista2.Add(new ClienteListCLS
                {
                    CodigoCliente = Nrocliente,
                    NombreCliente = oclienteFormCLS.NombreCliente,
                    nombreRepresentante = libroService.obtenerNombreRepresentante(oclienteFormCLS.idRepresentante),
                    LimiteCredito = oclienteFormCLS.LimiteCredito
                });
            }
        }
        public List<ClienteListCLS> filtrarClientes(string nombreCliente)
        {
            List<ClienteListCLS> l = listarclientes();
            if (nombreCliente == "") { return l; }
            else
            {
                List<ClienteListCLS> listafiltrada = l.Where(p => p.NombreCliente.ToUpper().Contains(nombreCliente.ToUpper())).ToList();
                return listafiltrada;
            }
        }

    }
}
