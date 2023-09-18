using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.eventplus.Domains
{
    [Table("TiposEvento")]
    public class TiposEvento
    {
        [Key]
        public Guid IdTiposEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage ="Titulo obrigatorio")]
        public string? Titulo { get; set; }
    }
}
