using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static webapi.event_.manha.Domains.TiposEventoDomain;
using static webapi.event_.manha.Domains.UsuarioDomain;

namespace webapi.event_.manha.Domains
{

        [Table(nameof(EventoDomain))]
        public class EventoDomain
        {
            [Key]
            public Guid IdEvento { get; set; } = Guid.NewGuid();

            [Column(TypeName = "VARCHAR(100)")]
            [Required(ErrorMessage = "O Nome do evento é obrigatório!")]
            public string? NomeEvento { get; set; }

            [Column(TypeName = "DATE")]
            [Required(ErrorMessage = "A Data do evento é obrigatória!")]
            public DateTime DataEvento { get; set; }

            [Column(TypeName = "TEXT")]
            [Required(ErrorMessage = "A Descricao do evento é obrigatória!")]
            public string? Descricao { get; set; }


            //Ref. da tabela TiposEvento = FK
            [Required(ErrorMessage = "O Tipo do evento é obrigatório!")]
            public Guid IdTipoEvento { get; set; }

            [ForeignKey(nameof(IdTipoEvento))]
            public TiposEventoDomain? TiposEvento { get; set; }


            //Ref. da tabela Instituicao = FK
            [Required(ErrorMessage = "A Instituição do evento é obrigatória!")]
            public Guid IdInstituicao { get; set; }

            [ForeignKey(nameof(IdInstituicao))]
            public InstituicaoDomain? Instituicao { get; set; }

        }
    }

