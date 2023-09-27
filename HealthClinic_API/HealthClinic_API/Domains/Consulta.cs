using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClinic_API.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage ="A Data da consulta é obrigatória!")]
        public DateTime? DataConsulta { get; set;}

        [Column (TypeName ="SMALLDATETIME")]
        [Required(ErrorMessage = "O Horário da consulta é obrigatório!")]
        public DateTime? HorarioConsulta { get; set;}

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A Descrição da consulta é obrigatória!")]
        public string? Descricao { get; set; }


        //ref.Tabela MEDICO
        [Required(ErrorMessage = "Informe o médico!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }



        //ref.Tabela PACIENTE
        [Required(ErrorMessage = "Informe o paciente!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

    }
}
