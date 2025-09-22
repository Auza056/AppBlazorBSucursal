using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace AppBlazor.Test
{
    public class LibroFormCLSTest
    {
      private List<ValidationResult > ValidarModelo(object modelo)
        {
            var resultados=new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto,resultados,true);

            return resultados;
        }
        [Fact]
        public void ValidacionDebeFallarCuandoCamposEstanVacios()
        {
            var libro=new LibroFormCLS();
            var errores= ValidarModelo(libro);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El ID del libro es requerido") || e.ErrorMessage!.Contains("El id debe ser un numero positivo"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El Titulo es requerido"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El Resumen es requerido"));

        }
        [Fact]
        public void ValidaicionDebePasarConDatosCorrectos()
        {
            var libro = new LibroFormCLS
            {
                idLibro = 1,
                titulo = "lIBRO DE PRUEBA",
                resumen= "este es el resumen del libro de pruebas"
            };
            var errores = ValidarModelo(libro);
            Assert.Empty(errores);
        }
    }
}