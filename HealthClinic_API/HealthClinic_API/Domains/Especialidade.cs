﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_API.Domains
{
    [Table(nameof(Especialidade))]
    [Index(nameof(NomeEspecialidade), IsUnique = true)]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "A Especialidade é obrigatório!")]
        public string? NomeEspecialidade { get; set; }
    }
}
