using Microsoft.EntityFrameworkCore;
using Multas.Models;

public class AppDbContext : DbContext
{
    public DbSet<Usuario>? usuarios { get; set; }
    public DbSet<Tarifas> tarifas { get; set; }
    public DbSet<Tipos_nov> tipos_nov { get; set; }
    public DbSet<Sanciones> sanciones { get; set; }
    public DbSet<Resoluciones> resoluciones { get; set; }
    public DbSet<Recibos> recibos { get; set; }    
    public DbSet<Procesos> procesos { get; set; }
    public DbSet<Persuasivos> persuasivos { get; set; }
    public DbSet<Parametros> parametros { get; set; }
    public DbSet<Liquidaciones> liquidaciones { get; set; }
    public DbSet<Intereses> intereses { get; set; }
    public DbSet<Infractores> infractores { get; set; }
    public DbSet<Infracciones> infracciones { get; set; }
    public DbSet<Comparendos> comparendos { get; set; }
    public DbSet<Coactivos> coactivos { get; set; }
    
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // ...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura la cadena de conexión a tu base de datos PostgreSQL

            optionsBuilder.UseNpgsql("Host=localhost;Database=multas;Username=postgres;Password=1098825894");
        }
}
