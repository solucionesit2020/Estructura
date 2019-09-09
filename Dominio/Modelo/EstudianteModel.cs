using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class EstudianteModel
    {
        public long Id { get; set; }
        [Display(Name = "Primer nombre")]
        public string PrimerNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; }
        [Display(Name = "Correo")]
        public string Email { get; set; }
        [Display(Name = "Identificacón")]
        public string NoIdentificacion { get; set; }
    }
}
