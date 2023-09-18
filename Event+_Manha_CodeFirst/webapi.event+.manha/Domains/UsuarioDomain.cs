using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.manha.Domains
{
    public class UsuarioDomain
    {
        //Criando a tabela no BD
        [Table (nameof(Usuario))]
        //Para deixar o Email UNICO
        [Index(nameof(Email), IsUnique = true)]
        public class Usuario 
        {
            [Key]
            //Guid para criar a hash
            public Guid IdUsuario { get; set; } = Guid.NewGuid();

            [Column (TypeName = "VARCHAR(100)")]
            [Required(ErrorMessage = "O Nome do usuário é obrigatório!")]
            public string? Nome { get; set; }

            [Column(TypeName = "VARCHAR(100)")]
            [Required(ErrorMessage = "O Email do usuário é obrigatório!")]
            public string? Email { get; set; }

            [Column(TypeName = "CHAR(60)")]
            [Required(ErrorMessage = "A Senha do usuário é obrigatória!")]
            [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
            public string? Senha { get; set; }

            //ref.Tabela TiposUsuario = FK
            [Required(ErrorMessage = "Informe o tipo do usuário!")]
            public Guid IdTipoUsuario { get; set; }

            [ForeignKey(nameof(IdTipoUsuario))]
            //[ForeignKey("IdTipoUsuario")] ambos fazem o mesmo papel
            public TiposUsuario? TiposUsuario { get; set; }
        }
    }
}
