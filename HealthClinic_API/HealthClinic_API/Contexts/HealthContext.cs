using HealthClinic_API.Domains;
using Microsoft.EntityFrameworkCore;

namespace HealthClinic_API.Contexts
{
    public class HealthContext : DbContext
    {
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<ComentariosConsulta> ComentariosConsultas { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<TiposDeUsuario> TiposDeUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public object ComentariosConsulta { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= NOTE17-S15; Initial Catalog= HealthClinic_Gabriel; User Id= sa; pwd = Senai@134; TrustServerCertificate = true;");
           // optionsBuilder.UseSqlServer("Data Source= GCRUSSO; Initial Catalog= HealthClinic_Gabriel; Integrated Security = true; TrustServerCertificate = true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

