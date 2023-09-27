using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_API.Domains
{
    [Table(nameof(ComentariosConsulta))]
    public class ComentariosConsulta
    {
        [Key]
        public Guid IdComentarioConsulta { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Adicione seu comentário! ele não pode ser nulo.")]
        public string? Comentario { get; set; }

        [Column(TypeName ="BIT")]
        //[DefaultValue(0)]
        [DefaultValue("false")]
        public bool? Situacao { get; set; }


        //ref.Tabela CONSULTA
        [Required(ErrorMessage = "A Consulta é obrigatória!")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }


    }
}
