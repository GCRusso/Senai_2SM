using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_API.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(CPF), IsUnique = true)]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; }

        [Column(TypeName = "VARCHAR(13)")]
        [Required(ErrorMessage = "Telefone é obrigatório!")]
        public string? Telefone { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "CPF é obrigatório!")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Gênero é obrigatório!")]
        public string? Genero { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A Data de nascimento é obrigatório!")]
        public DateTime? DataNascimento { get; set; }

        //ref.Tabela TiposUsuario = FK
        [Required(ErrorMessage = "Informe o usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        //[ForeignKey("IdTipoUsuario")] ambos fazem o mesmo papel
        public Usuario? Usuario { get; set; }
    }
}
