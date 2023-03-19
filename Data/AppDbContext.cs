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
    }
}