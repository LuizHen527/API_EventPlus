using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.eventplus.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Descricao obrigatoria")]
        [Column(TypeName = "TEXT")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Campo exibe obrigatorio")]
        [Column(TypeName = "BIT")]
        public bool Exibe { get; set; }

        //Foreign keys

        [Required(ErrorMessage = "IdUsuario obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "IdEvento obrigatorio")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }

    }
}
