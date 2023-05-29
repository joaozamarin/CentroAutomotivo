﻿// <auto-generated />
using System;
using CentroAutomotivo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CentroAutomotivo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CentroAutomotivo.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FotoPerfil")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "020b89d9-34a5-4b90-a248-d668c524bb8c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8f7893bf-8429-4bba-a9d3-8f479a9da848",
                            Email = "admin@javacentroautomotivo.com",
                            EmailConfirmed = true,
                            FotoPerfil = "\\avatars\\01.png",
                            IsAdmin = true,
                            LockoutEnabled = false,
                            Nome = "Administrador",
                            NormalizedEmail = "ADMIN@JAVACENTROAUTOMOTIVO.COM",
                            NormalizedUserName = "ADMIN@JAVACENTROAUTOMOTIVO.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHRss1qkBu5KiQ44zoL/hqbCyqrPsQevuUlIVhKMAS4Edcfz4NHVh9U/uuavNkniyw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "36793414",
                            TwoFactorEnabled = false,
                            UserName = "admin@javacentroautomotivo.com"
                        },
                        new
                        {
                            Id = "0f449177-c420-4f79-be6a-0c98dc11cdd0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9624dbce-1566-4964-b49f-b9b3858169b4",
                            Email = "cliente@javacentroautomotivo.com",
                            EmailConfirmed = true,
                            FotoPerfil = "\\avatars\\06.png",
                            IsAdmin = false,
                            LockoutEnabled = false,
                            Nome = "Cliente",
                            NormalizedEmail = "CLIENTE@JAVACENTROAUTOMOTIVO.COM",
                            NormalizedUserName = "CLIENTE@JAVACENTROAUTOMOTIVO.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAENFc5oXD23GPj8ZrsB23tvGb4qH4nSa3B+livdBQklJE/5iHPgDanSiMklhQiR5r1w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "62705275",
                            TwoFactorEnabled = false,
                            UserName = "cliente@javacentroautomotivo.com"
                        });
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.OrdemServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataSaida")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("StatusOrdemServicoId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusOrdemServicoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("OrdemServico");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Peca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Peca");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.PecaOrdem", b =>
                {
                    b.Property<int>("OrdemServicoId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("PecaId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("OrdemServicoId", "PecaId");

                    b.HasIndex("PecaId");

                    b.ToTable("PecaOrdem");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.ServicoOrdem", b =>
                {
                    b.Property<int>("OrdemServicoId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("ServicoId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("OrdemServicoId", "ServicoId");

                    b.HasIndex("ServicoId");

                    b.ToTable("ServicoOrdem");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.StatusOrdemServico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("StatusOrdemServico");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Imagem")
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("ModeloId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "bda19fc2-b020-44de-9072-9bd8b0cb4df2",
                            ConcurrencyStamp = "67963d74-e0cc-4421-9468-bdae104e3bdc",
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = "113bc5ee-0ec1-4912-86a7-e00b8a4c2928",
                            ConcurrencyStamp = "62230542-ce47-4e47-b607-65e264b008e6",
                            Name = "Usuário",
                            NormalizedName = "USUÁRIO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "020b89d9-34a5-4b90-a248-d668c524bb8c",
                            RoleId = "bda19fc2-b020-44de-9072-9bd8b0cb4df2"
                        },
                        new
                        {
                            UserId = "0f449177-c420-4f79-be6a-0c98dc11cdd0",
                            RoleId = "113bc5ee-0ec1-4912-86a7-e00b8a4c2928"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Modelo", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.OrdemServico", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.StatusOrdemServico", "StatusOrdemServico")
                        .WithMany("OrdensServico")
                        .HasForeignKey("StatusOrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentroAutomotivo.Models.Veiculo", "Veiculo")
                        .WithMany("OrdensServico")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusOrdemServico");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.PecaOrdem", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.OrdemServico", "OrdemServico")
                        .WithMany("PecasOrdem")
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentroAutomotivo.Models.Peca", "Peca")
                        .WithMany("PecasOrdem")
                        .HasForeignKey("PecaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdemServico");

                    b.Navigation("Peca");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.ServicoOrdem", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.OrdemServico", "OrdemServico")
                        .WithMany("ServicosOrdem")
                        .HasForeignKey("OrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentroAutomotivo.Models.Servico", "Servico")
                        .WithMany("ServicosOrdem")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdemServico");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Veiculo", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.AppUser", "AppUser")
                        .WithMany("Veiculos")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentroAutomotivo.Models.Modelo", "Modelo")
                        .WithMany("Veiculos")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CentroAutomotivo.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CentroAutomotivo.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CentroAutomotivo.Models.AppUser", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Modelo", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.OrdemServico", b =>
                {
                    b.Navigation("PecasOrdem");

                    b.Navigation("ServicosOrdem");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Peca", b =>
                {
                    b.Navigation("PecasOrdem");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Servico", b =>
                {
                    b.Navigation("ServicosOrdem");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.StatusOrdemServico", b =>
                {
                    b.Navigation("OrdensServico");
                });

            modelBuilder.Entity("CentroAutomotivo.Models.Veiculo", b =>
                {
                    b.Navigation("OrdensServico");
                });
#pragma warning restore 612, 618
        }
    }
}
