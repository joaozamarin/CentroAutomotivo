using CentroAutomotivo.Models;
using Microsoft.AspNetCore.Identity;
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

            #region Seed Roles
            List<IdentityRole> listRoles = new()
            {
                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },

                new IdentityRole{
                    Id = Guid.NewGuid().ToString(),
                    Name = "Usuário",
                    NormalizedName = "USUÁRIO"
                },
            };
            builder.Entity<IdentityRole>().HasData(listRoles);
            #endregion

            #region Seed ApplicationUser - Admin
            var userId = Guid.NewGuid().ToString();
            var hash = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = userId,
                    Nome = "Administrador",
                    UserName = "admin@javacentroautomotivo.com",
                    NormalizedUserName = "ADMIN@JAVACENTROAUTOMOTIVO.COM",
                    Email = "admin@javacentroautomotivo.com",
                    NormalizedEmail = "ADMIN@JAVACENTROAUTOMOTIVO.COM",
                    EmailConfirmed = true,
                    PasswordHash = hash.HashPassword(null, "admin"),
                    SecurityStamp = hash.GetHashCode().ToString(),
                    FotoPerfil = @"\avatars\01.png",
                    IsAdmin = true,
                    CPF = "281.372.540-48"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = userId,
                    RoleId = listRoles[0].Id
                }
            );
            #endregion

            #region Seed ApplicationUser - Usuário
            var userClienteId = Guid.NewGuid().ToString();
            var hashCliente = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = userClienteId,
                    Nome = "Cliente",
                    UserName = "cliente@javacentroautomotivo.com",
                    NormalizedUserName = "CLIENTE@JAVACENTROAUTOMOTIVO.COM",
                    Email = "cliente@javacentroautomotivo.com",
                    NormalizedEmail = "CLIENTE@JAVACENTROAUTOMOTIVO.COM",
                    EmailConfirmed = true,
                    PasswordHash = hashCliente.HashPassword(null, "cliente"),
                    SecurityStamp = hashCliente.GetHashCode().ToString(),
                    FotoPerfil = @"\avatars\06.png",
                    IsAdmin = false,
                    CPF = "538.229.810-60"
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = userClienteId,
                    RoleId = listRoles[1].Id
                }
            );
            #endregion
        }
    }
}