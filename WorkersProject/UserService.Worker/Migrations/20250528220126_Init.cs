using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserService.Worker.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("8ad503c2-b7b4-4b32-90a5-ecb0fc734d89"), new DateTime(2025, 5, 28, 22, 1, 26, 76, DateTimeKind.Utc).AddTicks(4912), "bob@example.com", "Bob", "Admin" },
                    { new Guid("a2d1e9e9-89b6-40c8-a66e-5417c92fdd63"), new DateTime(2025, 5, 28, 22, 1, 26, 76, DateTimeKind.Utc).AddTicks(4914), "carol@example.com", "Carol", "User" },
                    { new Guid("f9a64b46-2633-4ac1-8a5b-0bb1fd6d64ef"), new DateTime(2025, 5, 28, 22, 1, 26, 76, DateTimeKind.Utc).AddTicks(4908), "alice@example.com", "Alice", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
