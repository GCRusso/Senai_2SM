using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_API.Domains
{
    [Table(nameof(Medico))]
    [Index(nameof(CRM), IsUnique = true)]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; }

        [Column(TypeName = "VARCHAR(8)")]
        [Required(ErrorMessage = "O CRM é obrigatório!")]
        public string? CRM { get; set; }




        //ref.Tabela ESPECIALIDADE
        [Required(ErrorMessage = "Informe a especialidade!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }



        //ref.Tabela CLINICA
        [Required(ErrorMessage = "Informe a clinica!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }



        //ref.Tabela USUARIO
        [Required(ErrorMessage = "Informe o usuário!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
