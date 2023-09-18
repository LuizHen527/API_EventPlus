using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.eventplus.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data obrigatoria")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR (150)")]
        [Required(ErrorMessage = "Nomde do evento obrigatorio")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao obrigatoria")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Id Tipo evento obrigatorio")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set; }

        [Required(ErrorMessage = "Id Instituicao obrigatoria")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
