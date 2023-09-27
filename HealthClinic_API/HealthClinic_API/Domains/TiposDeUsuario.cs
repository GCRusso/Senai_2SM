using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_API.Domains
{
    [Table (nameof(TiposDeUsuario))]
    [Index(nameof(Titulo), IsUnique = true)]
    public class TiposDeUsuario
    {
        [Key]
        public Guid IdTipoDeUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Tipo de usuário obrigatório!")]
        public string? Titulo { get; set; }
    }
}
