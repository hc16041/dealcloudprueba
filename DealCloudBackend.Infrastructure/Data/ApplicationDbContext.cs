// Infrastructure/Data/ApplicationDbContext.cs
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DealCloudBackend.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Entidades Principales
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Lawyer> Lawyers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<ProBono> ProBonos { get; set; }
        public DbSet<Reference> References { get; set; }

        // Entidades de Catálogo
        public DbSet<Position> Positions { get; set; }
        public DbSet<PracticeArea> PracticeAreas { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Industry> Industries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configurar Multi-Tenancy (Filtro Global)
            // Esto asegura que NUNCA se muestren datos de otra firma.
            builder.Entity<Lawyer>().HasQueryFilter(e => e.FirmId == _tenantId);
            builder.Entity<Client>().HasQueryFilter(e => e.FirmId == _tenantId);
            builder.Entity<Deal>().HasQueryFilter(e => e.FirmId == _tenantId);
            builder.Entity<ProBono>().HasQueryFilter(e => e.FirmId == _tenantId);
            builder.Entity<Reference>().HasQueryFilter(e => e.FirmId == _tenantId);
            builder.Entity<Position>().HasQueryFilter(e => e.FirmId == _tenantId);
            builder.Entity<PracticeArea>().HasQueryFilter(e => e.FirmId == _tenantId);
            builder.Entity<Industry>().HasQueryFilter(e => e.FirmId == _tenantId);

            // Configurar relaciones Muchos a Muchos

            // Abogado <-> Área de Práctica
            builder.Entity<Lawyer>()
                .HasMany(l => l.PracticeAreas)
                .WithMany(); // EF Core 8 crea la tabla de unión implícitamente

            // Abogado <-> Industria
            builder.Entity<Lawyer>()
                .HasMany(l => l.Industries)
                .WithMany();

            // Abogado <-> Cliente
            builder.Entity<Lawyer>()
                .HasMany(l => l.Clients)
                .WithMany(c => c.Lawyers);

            // Abogado (Equipo) <-> Caso (Deal)
            builder.Entity<Deal>()
                .HasMany(d => d.Team)
                .WithMany(l => l.DealsAsTeamMember);
        }

        // Deberás inyectar y establecer esta variable (ej. desde el HttpContext)
        private int _tenantId;

        public void SetTenantId(int tenantId)
        {
            _tenantId = tenantId;
        }

        // ... (Aquí iría la lógica para guardar cambios, etc.)
    }
}