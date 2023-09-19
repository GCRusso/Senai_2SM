using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static webapi.event_.manha.Domains.UsuarioDomain;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(ComentariosEventoDomain))]
    public class ComentariosEventoDomain
    {
        [Key]

        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="TEXT")]
        [Required(ErrorMessage ="A Descrição é obrigatória!")]
        public string? Descricao { get; set; }

        [Column(TypeName ="BIT")]
        [Required(ErrorMessage ="A informação de exibição é obrigatória!")]
        public bool Exibe { get; set; }



        //ref.tabela Usuario = FK
        [Required(ErrorMessage = "Usuário Obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public UsuarioDomain? Usuario { get; set; }



        //ref.tabela Evento = FK
        [Required(ErrorMessage = "Evento Obrigatório!")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public EventoDomain? Evento { get; set; }

    }
}
