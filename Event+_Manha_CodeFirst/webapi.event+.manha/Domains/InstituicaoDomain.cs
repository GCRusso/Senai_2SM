using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static webapi.event_.manha.Domains.UsuarioDomain;

namespace webapi.event_.manha.Domains
{
        [Table(nameof(InstituicaoDomain))]
        [Index(nameof(CNPJ), IsUnique = true)]
        public class InstituicaoDomain
        {
            [Key]
            public Guid IdInstituicao { get; set; } = Guid.NewGuid();

            [Column(TypeName = "CHAR(14)")]
            [Required(ErrorMessage = "CNPJ Obrigatório!")]
            //maximo de tamanho da string
            [StringLength(14)]
            public string? CNPJ { get; set; }

            [Column(TypeName = "VARCHAR(150)")]
            [Required(ErrorMessage = "O Endereço é obrigatório!")]
            public string? Endereco { get; set; }

            [Column(TypeName = "VARCHAR(100)")]
            [Required (ErrorMessage = "O Nome fantasia é obrigatório!")]
            public string? NomeFantasia { get; set; }    
        }
    }

