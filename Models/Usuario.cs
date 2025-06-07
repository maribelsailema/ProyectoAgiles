using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Proyecto.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public string Ced { get; set; }

        [Required]
        public string Nom1 { get; set; }

        public string? Nom2 { get; set; }

        [Required]
        public string Ape1 { get; set; }

        public string? Ape2 { get; set; }

        [Required]
        public string Usuari { get; set; }

        [Required]
        public string Pass { get; set; }

        [Required]
        [RegularExpression("admin|docente")]
        public string TipoUsuario { get; set; }
    }
}
