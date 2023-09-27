using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_API.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Email obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Senha obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string? Nome { get; set; }



        //ref.Tabela TIPOS DE USUARIO
        [Required(ErrorMessage = "Informe o tipo do usuário!")]
        public Guid IdTipoDeUsuario { get; set; }

        [ForeignKey(nameof(IdTipoDeUsuario))]
        public TiposDeUsuario? TiposDeUsuario { get; set; }

    }
}
