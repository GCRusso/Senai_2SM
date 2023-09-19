using Microsoft.EntityFrameworkCore;
using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Contexts
{
    public class EventoContext : DbContext
    {
        public DbSet<TiposUsuarioDomain> TiposUsuario { get; set; }
        public DbSet<UsuarioDomain> Usuario { get; set; }
        public DbSet<TiposEventoDomain> TiposEvento { get; set; }
        public DbSet<EventoDomain> Evento { get; set; }
        public DbSet<ComentariosEventoDomain> ComentariosEvento { get; set; }
        public DbSet<InstituicaoDomain> Instituicao { get; set; }
        public DbSet<PresencasEventoDomain> PresencasEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
        optionsBuilder.UseSqlServer("Data Source= NOTE17-S15; Initial Catalog= Event+_Manha; User Id= sa; pwd = Senai@134; TrustServerCertificate = true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
