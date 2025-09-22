using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace AppBlazor.Test
{
    // Servicio simulado en memoria
    public class LibroService
    {
        private readonly List<LibroFormCLS> libros = new List<LibroFormCLS>();

        public void guardarLibro(LibroFormCLS libro)
        {
            var existente = libros.FirstOrDefault(l => l.NroEmpleado == libro.NroEmpleado);
            if (existente != null)
            {
                // Actualizar
                existente.Nombre = libro.Nombre;
                existente.Edad = libro.Edad;
            }
            else
            {
                // Agregar nuevo
                libros.Add(libro);
            }
        }

        public List<LibroFormCLS> listarlibros()
        {
            return libros.ToList(); // retornar copia
        }

        public void eliminarLibro(int idLibro)
        {
            var libro = libros.FirstOrDefault(l => l.NroEmpleado == idLibro);
            if (libro != null)
                libros.Remove(libro);
        }
    }

    public class LibroFormCLSTest
    {
        private readonly LibroService servicio;

        public LibroFormCLSTest()
        {
            servicio = new LibroService();
        }

        private List<ValidationResult> ValidarModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }

      

        [Fact]
        public void AgregarLibro_NuevoLibroSeAgrega()
        {
            var libroNuevo = new LibroFormCLS
            {
                NroEmpleado = 99,
                Nombre = "JuanPrueba",
                Edad = 24
            };

            servicio.guardarLibro(libroNuevo);

            var lista = servicio.listarlibros();
            var existe = lista.Any(l => l.NroEmpleado == 99 && l.Nombre == "JuanPrueba");
            Assert.True(existe, "El libro nuevo no fue agregado correctamente");
        }

        [Fact]
        public void EditarLibro_DatosActualizados()
        {
            var libroOriginal = new LibroFormCLS
            {
                NroEmpleado = 50,
                Nombre = "julio",
                Edad = 24
            };
            servicio.guardarLibro(libroOriginal);

            var libroEditado = new LibroFormCLS
            {
                NroEmpleado = 50,
                Nombre = "JulioEditado",
                Edad = 27
            };
            servicio.guardarLibro(libroEditado);

            var resultado = servicio.listarlibros().First(l => l.NroEmpleado == 50);
            Assert.Equal("JulioEditado", resultado.Nombre);
        }

        [Fact]
        public void EliminarLibro_SeEliminaCorrectamente()
        {
            var libro = new LibroFormCLS
            {
                NroEmpleado = 1,
                Nombre = "julio",
                Edad = 24
            };
            servicio.guardarLibro(libro);

            servicio.eliminarLibro(1);

            var lista = servicio.listarlibros();
            Assert.DoesNotContain(lista, l => l.NroEmpleado == 1);
        }
        [Fact]
        public void CambiosSeReflejanInmediatamente()
        {
            // Agregar libro
            var libro = new LibroFormCLS { NroEmpleado = 77, Nombre = "Reflejar", Edad = 29 };
            servicio.guardarLibro(libro);

            // Editar libro
            libro.Nombre = "Reflejado";
            servicio.guardarLibro(libro);

            // Obtener lista inmediatamente
            var lista = servicio.listarlibros();
            var existe = lista.Any(l => l.NroEmpleado == 77 && l.Nombre == "Reflejado");
            Assert.True(existe, "Los cambios no se reflejaron en la lista inmediatamente");
        }

    }
}
