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

            #region Seed Serviços
            List<Servico> servicos = new()
            {
                new Servico
                {
                    Id = 1,
                    Nome = "Trocar Pneu",
                    Preco = 65.00M
                },
                new Servico
                {
                    Id = 2,
                    Nome = "Trocar Vela",
                    Preco = 30.00M
                },
                new Servico
                {
                    Id = 3,
                    Nome = "Trocar Óleo do Motor",
                    Preco = 150.00M
                },
                new Servico
                {
                    Id = 4,
                    Nome = "Trocar Amortecedor",
                    Preco = 350.00M
                }
            };
            builder.Entity<Servico>().HasData(servicos);
            #endregion

            #region Seed Peças
            List<Peca> pecas = new()
            {
                new Peca
                {
                    Id = 1,
                    Nome = "Kit Amortecedor Cofap",
                    Quantidade = 10,
                    Preco = 800.00M
                },
                new Peca
                {
                    Id = 2,
                    Nome = "Sensor de Temperatura",
                    Quantidade = 15,
                    Preco = 90.00M
                },
                new Peca
                {
                    Id = 3,
                    Nome = "Pinça Freio",
                    Quantidade = 10,
                    Preco = 250.00M
                },
                new Peca
                {
                    Id = 4,
                    Nome = "Correia Dentada",
                    Quantidade = 15,
                    Preco = 105.0M
                },
                new Peca
                {
                    Id = 5,
                    Nome = "Kit 4 Buchas Bandeja",
                    Quantidade = 10,
                    Preco = 165.00M
                },
                new Peca
                {
                    Id = 6,
                    Nome = "Vela de Ignição",
                    Quantidade = 15,
                    Preco = 100.00M
                }
            };
            builder.Entity<Peca>().HasData(pecas);
            #endregion

            #region Seed Marcas
            List<Marca> marcas = new()
            {
                new Marca
                {
                    Id = 1,
                    Nome = "Chevrolet"
                },
                new Marca
                {
                    Id = 2,
                    Nome = "Fiat"
                },
                new Marca
                {
                    Id = 3,
                    Nome = "Volkswagen"
                },
                new Marca
                {
                    Id = 4,
                    Nome = "Hyundai"
                },
                new Marca
                {
                    Id = 5,
                    Nome = "Toyota"
                }
            };
            builder.Entity<Marca>().HasData(marcas);
            #endregion

            #region Seed Modelos
            List<Modelo> modelos = new()
            {
                new Modelo
                {
                    Id = 1,
                    Nome = "Chevrolet Cruze LT",
                    Ano = 2020,
                    MarcaId = 1
                },
                new Modelo
                {
                    Id = 2,
                    Nome = "Fiat Argo",
                    Ano = 2017,
                    MarcaId = 2
                },
                new Modelo
                {
                    Id = 3,
                    Nome = "Volkswagen Jetta",
                    Ano = 2021,
                    MarcaId = 3
                },
                new Modelo
                {
                    Id = 4,
                    Nome = "Hyundai HB20",
                    Ano = 2012,
                    MarcaId = 4
                },
                new Modelo
                {
                    Id = 5,
                    Nome = "Corolla",
                    Ano = 2020,
                    MarcaId = 5
                }
            };
            builder.Entity<Modelo>().HasData(modelos);
            #endregion

            #region Seed Status
            List<StatusOrdemServico> status = new()
            {
                new StatusOrdemServico
                {
                    Id = 1,
                    Nome = "Aguardando Manutenção",
                    Cor = "#CA2222"
                },
                new StatusOrdemServico
                {
                    Id = 2,
                    Nome = "Em Andamento",
                    Cor = "#DDCB21"
                },
                new StatusOrdemServico
                {
                    Id = 3,
                    Nome = "Concluído",
                    Cor = "#26CE1D"
                }
            };
            builder.Entity<StatusOrdemServico>().HasData(status);
            #endregion
        }
    }
}