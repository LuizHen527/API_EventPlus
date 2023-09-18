using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.eventplus.Domains
{
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR (100)")]
        [Required(ErrorMessage = "Titulo do tipo de usuario obrigatorio")]
        public string? Titulo { get; set; }
    }
}
