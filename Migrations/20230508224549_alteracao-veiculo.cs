using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroAutomotivo.Migrations
{
    public partial class alteracaoveiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "947b775b-e4b2-483e-8492-8744dff12e2d", "94e45df8-48cd-47a8-9d9e-ceb096b6b40a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc40412e-eaa8-4c04-81c9-5c7d399c13cb", "afb4c13c-b8fc-4496-ba30-c1a3491122f1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947b775b-e4b2-483e-8492-8744dff12e2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc40412e-eaa8-4c04-81c9-5c7d399c13cb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94e45df8-48cd-47a8-9d9e-ceb096b6b40a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afb4c13c-b8fc-4496-ba30-c1a3491122f1");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculo",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(7)",
                oldMaxLength: 7)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "824be1d8-1500-40f2-8a84-085238d97742", "477c9a1f-51c6-4801-9348-6c1ad8c3c1f3", "Usuário", "USUÁRIO" },
                    { "8bd3072f-4967-4319-9525-94e04efbc2c9", "e0723b8a-d87b-4af5-a256-f734bab5ae19", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FotoPerfil", "IsAdmin", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "382e2201-41b7-41c3-9d15-21c4f3e4e932", 0, "44877ff7-75db-4268-934d-073ad3c68731", "cliente@javacentroautomotivo.com", true, "\\avatars\\06.png", false, false, null, "Cliente", "CLIENTE@JAVACENTROAUTOMOTIVO.COM", "CLIENTE@JAVACENTROAUTOMOTIVO.COM", "AQAAAAEAACcQAAAAEHpj81oNrDI1eD2U+YrzgYG/mRL6Z/kZra18LUAFm/Y+NXunzWO7buvN2+jlLlzfBQ==", null, false, "36793414", false, "cliente@javacentroautomotivo.com" },
                    { "f23d171b-a6ee-43ba-9032-709f9fff6803", 0, "602deff6-db29-494c-af71-597e88749c2a", "admin@javacentroautomotivo.com", true, "\\avatars\\01.png", true, false, null, "Administrador", "ADMIN@JAVACENTROAUTOMOTIVO.COM", "ADMIN@JAVACENTROAUTOMOTIVO.COM", "AQAAAAEAACcQAAAAEFDrfj8Y34Qxwsg3a3QMyE03aPbE2UD2sS8sMdzdYoNH/6Nh+BO6m84i4ETEEwYpYw==", null, false, "26457778", false, "admin@javacentroautomotivo.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "824be1d8-1500-40f2-8a84-085238d97742", "382e2201-41b7-41c3-9d15-21c4f3e4e932" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8bd3072f-4967-4319-9525-94e04efbc2c9", "f23d171b-a6ee-43ba-9032-709f9fff6803" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "824be1d8-1500-40f2-8a84-085238d97742", "382e2201-41b7-41c3-9d15-21c4f3e4e932" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8bd3072f-4967-4319-9525-94e04efbc2c9", "f23d171b-a6ee-43ba-9032-709f9fff6803" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824be1d8-1500-40f2-8a84-085238d97742");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bd3072f-4967-4319-9525-94e04efbc2c9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "382e2201-41b7-41c3-9d15-21c4f3e4e932");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f23d171b-a6ee-43ba-9032-709f9fff6803");

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Veiculo",
                type: "varchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "947b775b-e4b2-483e-8492-8744dff12e2d", "22973331-b968-4ea9-99c0-f971ddb31d66", "Administrador", "ADMINISTRADOR" },
                    { "fc40412e-eaa8-4c04-81c9-5c7d399c13cb", "70d0fc1f-3d5a-456d-b803-5547f7bfadec", "Usuário", "USUÁRIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FotoPerfil", "IsAdmin", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "94e45df8-48cd-47a8-9d9e-ceb096b6b40a", 0, "46ab7d4c-ea90-4cd1-90d4-91df419f2887", "admin@javacentroautomotivo.com", true, "\\avatars\\01.png", true, false, null, "Administrador", "ADMIN@JAVACENTROAUTOMOTIVO.COM", "ADMIN@JAVACENTROAUTOMOTIVO.COM", "AQAAAAEAACcQAAAAECTWkIUNdEkwa5aCqxS7YgMmFEWMRecl+QrAgw3wlRmpX74xsWWJyqG+in3iLS5XbQ==", null, false, "1807185", false, "admin@javacentroautomotivo.com" },
                    { "afb4c13c-b8fc-4496-ba30-c1a3491122f1", 0, "fb60fc31-8459-4d5f-8b2f-cf787378313f", "cliente@javacentroautomotivo.com", true, "\\avatars\\06.png", false, false, null, "Cliente", "CLIENTE@JAVACENTROAUTOMOTIVO.COM", "CLIENTE@JAVACENTROAUTOMOTIVO.COM", "AQAAAAEAACcQAAAAEMXLygp6sSX4XvctFGGLc23qHHhl396Jl1+vpfa+ZSD6qDimePq9oqiVtBkSMCXPFA==", null, false, "16264673", false, "cliente@javacentroautomotivo.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "947b775b-e4b2-483e-8492-8744dff12e2d", "94e45df8-48cd-47a8-9d9e-ceb096b6b40a" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc40412e-eaa8-4c04-81c9-5c7d399c13cb", "afb4c13c-b8fc-4496-ba30-c1a3491122f1" });
        }
    }
}
