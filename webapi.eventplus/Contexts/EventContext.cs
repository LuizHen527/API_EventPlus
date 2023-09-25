using Microsoft.EntityFrameworkCore;
using webapi.eventplus.Domains;

namespace webapi.eventplus.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario>? TiposUsuario { get; set; }
        public DbSet<Usuario>? Usuario { get; set; }
        public DbSet<TiposEvento>? TiposEvento { get; set; }
        public DbSet<Evento>? Evento { get; set; }
        public DbSet<ComentarioEvento>? ComentarioEvento { get; set; }
        public DbSet<Instituicao>? Instituicao { get; set; }
        public DbSet<PresencasEvento>? PresencasEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SENAI Conection
            //optionsBuilder.UseSqlServer("Server=NOTE22-S15;Database=EventPlus_Manha;User Id=sa; Pwd = Senai@134; TrustServerCertificate=True;");

            //HOME Conection
            optionsBuilder.UseSqlServer("Server=DESKTOP-C6SOG6K\\SQLEXPRESS;Database=EventPlus_Manha;User Id=sa; Pwd = pPtA3002; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);

        }
    }
}
