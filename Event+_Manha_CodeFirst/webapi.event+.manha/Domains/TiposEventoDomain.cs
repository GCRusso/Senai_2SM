using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static webapi.event_.manha.Domains.UsuarioDomain;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(TiposEvento))]
    public class TiposEventoDomain
    {
        public class TiposEvento
        {
            
            [Key]
            public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

            [Column(TypeName = "VARCHAR(100)")]
            [Required(ErrorMessage = "Título do Evento é obrigatório!")]
            public string? Titulo { get; set; }
        }
    }
}
