using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginService.Infrastructure.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Firstname = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ObjectId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ObjectId", "Address", "Email", "Firstname", "Password", "Phone", "Surname", "Username" },
                values: new object[,]
                {
                    { new Guid("692e130a-2486-4565-a886-7476d1182d85"), null, "admin@outlook.com", "admin", "admin", null, null, null },
                    { new Guid("3b1400bb-7c3d-4426-8b9c-d169b32848a1"), null, "emretuna@outlook.com", "emre", "emre", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
