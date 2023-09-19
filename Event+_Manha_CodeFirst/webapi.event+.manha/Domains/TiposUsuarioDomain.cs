using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static webapi.event_.manha.Domains.UsuarioDomain;

namespace webapi.event_.manha.Domains
{
    [Table(nameof(TiposUsuarioDomain))]
    public class TiposUsuarioDomain
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Titulo do tipo usuário é obrigatório!")]
        public string? Titulo { get; set; }
    }
}
