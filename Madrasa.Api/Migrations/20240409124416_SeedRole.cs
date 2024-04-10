using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Madrasa.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "239f527f-7a0d-40be-9511-2dc6399f8069");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "798a0afe-6efe-43bf-9b10-980d46c6d544");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ceca4dff-b86c-4be2-867b-7bd4e0299c6d", null, "User", "USER" },
                    { "d5cf3836-8cdd-4f1d-97b8-aba653e24dc4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceca4dff-b86c-4be2-867b-7bd4e0299c6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5cf3836-8cdd-4f1d-97b8-aba653e24dc4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "239f527f-7a0d-40be-9511-2dc6399f8069", null, "Admin", "ADMIN" },
                    { "798a0afe-6efe-43bf-9b10-980d46c6d544", null, "User", "USER" }
                });
        }
    }
}
