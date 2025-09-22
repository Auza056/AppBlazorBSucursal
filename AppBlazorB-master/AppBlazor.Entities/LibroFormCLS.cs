using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Entities
{
    public class LibroFormCLS
    {
        [Required(ErrorMessage = "El ID del libro es requerido")]
        [Range(1,int.MaxValue,ErrorMessage ="El id debe ser un numero positivo")]
        public int idLibro { get; set; }
        [Required (ErrorMessage ="El Titulo es requerido")]
        [MaxLength (100,ErrorMessage ="La longitud maxima del Titulo es de 100 caracteres")]

        public string titulo { get; set; } = null;
        [Required (ErrorMessage ="El Resumen es requerido")]
        [MinLength (20,ErrorMessage ="La longitud minima del Resumen es de 20 caracteres")]

        public string resumen { get; set; } = null;

    }
}
