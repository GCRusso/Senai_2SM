using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(PresencasEventoDomain))]
    public class PresencasEventoDomain
    {
        [Key]
        public Guid IdPresencasEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "Situação Obrigatória!")]
        public bool Situacao { get; set; }

        //ref.tabela Usuario = FK
        [Required(ErrorMessage = "Usuário Obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public UsuarioDomain? usuario { get; set; }


        //ref.tabela Evento = FK
        [Required(ErrorMessage ="Evento Obrigatório!")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public EventoDomain? Evento { get; set; }

    }
}
