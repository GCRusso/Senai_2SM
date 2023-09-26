using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_API.Domains
{
    [[Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome fantasia é obrigatório!")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage ="O Endereço é obrigatório!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "A Razão social é obrigatória!")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "SMALLDATETIME")]
        [Required(ErrorMessage ="O Horário de abertura é obrigatório!")]
        public DateTime? HorarioAbertura { get; set; }

        [Column(TypeName = "SMALLDATETIME")]
        [Required(ErrorMessage = "O Horário de fechamento é obrigatório!")]
        public DateTime? HorarioFechamento { get; set; }

        [Column(TypeName = "VARCHAR(14)")]
        [Required(ErrorMessage = "O CNPJ é obrigatório!")]
        public string? CNPJ { get; set; }

    }
}
