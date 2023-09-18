using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.eventplus.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage = "Nome obrigatorio")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR (300)")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR (200)")]
        [Required(ErrorMessage = "Senha obrigatoria")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha entre 6 a 200 caracteres")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "IdTipoUsuario obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TiposUsuario? TiposUsuario { get; set; }
    }
}
