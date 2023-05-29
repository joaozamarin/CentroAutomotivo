using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentroAutomotivo.Migrations
{
    public partial class PecaOrdem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "PecaOrdem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "113bc5ee-0ec1-4912-86a7-e00b8a4c2928", "62230542-ce47-4e47-b607-65e264b008e6", "Usuário", "USUÁRIO" },
                    { "bda19fc2-b020-44de-9072-9bd8b0cb4df2", "67963d74-e0cc-4421-9468-bdae104e3bdc", "Administrador", "ADMINISTRADOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FotoPerfil", "IsAdmin", "LockoutEnabled", "LockoutEnd", "Nome", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "020b89d9-34a5-4b90-a248-d668c524bb8c", 0, "8f7893bf-8429-4bba-a9d3-8f479a9da848", "admin@javacentroautomotivo.com", true, "\\avatars\\01.png", true, false, null, "Administrador", "ADMIN@JAVACENTROAUTOMOTIVO.COM", "ADMIN@JAVACENTROAUTOMOTIVO.COM", "AQAAAAEAACcQAAAAEHRss1qkBu5KiQ44zoL/hqbCyqrPsQevuUlIVhKMAS4Edcfz4NHVh9U/uuavNkniyw==", null, false, "36793414", false, "admin@javacentroautomotivo.com" },
                    { "0f449177-c420-4f79-be6a-0c98dc11cdd0", 0, "9624dbce-1566-4964-b49f-b9b3858169b4", "cliente@javacentroautomotivo.com", true, "\\avatars\\06.png", false, false, null, "Cliente", "CLIENTE@JAVACENTROAUTOMOTIVO.COM", "CLIENTE@JAVACENTROAUTOMOTIVO.COM", "AQAAAAEAACcQAAAAENFc5oXD23GPj8ZrsB23tvGb4qH4nSa3B+livdBQklJE/5iHPgDanSiMklhQiR5r1w==", null, false, "62705275", false, "cliente@javacentroautomotivo.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bda19fc2-b020-44de-9072-9bd8b0cb4df2", "020b89d9-34a5-4b90-a248-d668c524bb8c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "113bc5ee-0ec1-4912-86a7-e00b8a4c2928", "0f449177-c420-4f79-be6a-0c98dc11cdd0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bda19fc2-b020-44de-9072-9bd8b0cb4df2", "020b89d9-34a5-4b90-a248-d668c524bb8c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "113bc5ee-0ec1-4912-86a7-e00b8a4c2928", "0f449177-c420-4f79-be6a-0c98dc11cdd0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "113bc5ee-0ec1-4912-86a7-e00b8a4c2928");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda19fc2-b020-44de-9072-9bd8b0cb4df2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "020b89d9-34a5-4b90-a248-d668c524bb8c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f449177-c420-4f79-be6a-0c98dc11cdd0");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "PecaOrdem");

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
    }
}
