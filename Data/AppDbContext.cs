using CentroAutomotivo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CentroAutomotivo.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<StatusOrdemServico> StatusOrdensServico { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<OrdemServico> OrdensServico { get; set; }
        public DbSet<ServicoOrdem> ServicosOrdem { get; set; }
        public DbSet<PecaOrdem> PecasOrdem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region N : N - ServicoOrdem
            builder.Entity<ServicoOrdem>()
                .HasKey(so => new { so.OrdemServicoId, so.ServicoId });

            builder.Entity<ServicoOrdem>()
                .HasOne(so => so.OrdemServico)
                .WithMany(so => so.ServicosOrdem)
                .HasForeignKey(so => so.OrdemServicoId);
            
            builder.Entity<ServicoOrdem>()
                .HasOne(so => so.Servico)
                .WithMany(so => so.ServicosOrdem)
                .HasForeignKey(so => so.ServicoId);
            #endregion

            #region N : N - PecaOrdem
            builder.Entity<PecaOrdem>()
                .HasKey(po => new { po.OrdemServicoId, po.PecaId });
            
            builder.Entity<PecaOrdem>()
                .HasOne(po => po.OrdemServico)
                .WithMany(po => po.PecasOrdem)
                .HasForeignKey(po => po.OrdemServicoId);
            
            builder.Entity<PecaOrdem>()
                .HasOne(po => po.Peca)
                .WithMany(po => po.PecasOrdem)
                .HasForeignKey(po => po.PecaId);
            #endregion
        }
    }
}