using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderService.Infrastructure.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogBrands",
                columns: table => new
                {
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrands", x => x.ObjectId);
                });

            migrationBuilder.CreateTable(
                name: "CatalogTypes",
                columns: table => new
                {
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTypes", x => x.ObjectId);
                });

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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uuid", nullable: false),
                    City = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: true),
                    CardHolderName = table.Column<string>(type: "text", nullable: true),
                    CardExpiration = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CardSecurityNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ObjectId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCarts",
                columns: table => new
                {
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderItemObjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCarts", x => x.ObjectId);
                    table.ForeignKey(
                        name: "FK_CustomerCarts_OrderItems_OrderItemObjectId",
                        column: x => x.OrderItemObjectId,
                        principalTable: "OrderItems",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerCarts_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                columns: table => new
                {
                    ObjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: true),
                    PictureUri = table.Column<string>(type: "text", nullable: true),
                    CatalogTypeId = table.Column<int>(type: "integer", nullable: true),
                    CatalogTypeObjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    CatalogBrandId = table.Column<int>(type: "integer", nullable: true),
                    CatalogBrandObjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    AvailableStock = table.Column<int>(type: "integer", nullable: false),
                    RestockThreshold = table.Column<int>(type: "integer", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "integer", nullable: false),
                    OnReorder = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerCartObjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.ObjectId);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogBrands_CatalogBrandObjectId",
                        column: x => x.CatalogBrandObjectId,
                        principalTable: "CatalogBrands",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogTypes_CatalogTypeObjectId",
                        column: x => x.CatalogTypeObjectId,
                        principalTable: "CatalogTypes",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CustomerCarts_CustomerCartObjectId",
                        column: x => x.CustomerCartObjectId,
                        principalTable: "CustomerCarts",
                        principalColumn: "ObjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CatalogBrands",
                columns: new[] { "ObjectId", "Brand" },
                values: new object[,]
                {
                    { new Guid("b643f7a0-152a-4eae-bc62-65a545e86414"), "1.STATE" },
                    { new Guid("ffe44bbd-4067-4df4-9951-af18bb4de897"), "1017 ALYX 9SM" },
                    { new Guid("99f300f4-b1a6-46c1-a051-28041c01cf27"), "108 STITCHES" },
                    { new Guid("5b75ea9f-15b5-4a98-83d0-9bcb92968bc6"), "11 Honoré" },
                    { new Guid("2c24445f-d667-40e7-bf14-a5756ddc55eb"), "111SKIN" },
                    { new Guid("7028248c-898c-4556-88ef-5a97c8bd832f"), "1822 Denim" },
                    { new Guid("20bcdb70-79f5-435d-aa47-d0b8ac3cb1af"), "19 Cooper" },
                    { new Guid("bcc0e013-2dfb-44ba-b62b-9a0291ad1bea"), "1901" },
                    { new Guid("7091c3b2-af12-4f06-bac6-6b1f5429eadc"), "2 MONCLER 1952" }
                });

            migrationBuilder.InsertData(
                table: "CatalogItems",
                columns: new[] { "ObjectId", "AvailableStock", "CatalogBrandId", "CatalogBrandObjectId", "CatalogTypeId", "CatalogTypeObjectId", "CustomerCartObjectId", "Description", "MaxStockThreshold", "Name", "OnReorder", "PictureFileName", "PictureUri", "Price", "RestockThreshold" },
                values: new object[,]
                {
                    { new Guid("ec6d438c-baa5-411f-86fc-5b9d4826ee52"), 499, null, null, null, null, null, "Books", 0, "The Fallen Stones", false, null, null, 0m, 0 },
                    { new Guid("9d543736-0b47-439f-971f-f3eef007c97e"), 5100, null, null, null, null, null, "Books", 0, "North to Paradise", false, null, null, 0m, 0 },
                    { new Guid("52f8b963-32c9-4e8f-92f7-8ba1dedf1633"), 1500, null, null, null, null, null, "Books", 0, "A Train to Moscow", false, null, null, 0m, 0 },
                    { new Guid("5128152e-91a7-4a97-a791-f498d3df0188"), 500, null, null, null, null, null, "Books", 0, "The Quarter Storm", false, null, null, 0m, 0 },
                    { new Guid("6b2c1aff-6fcc-4f58-887b-4ae03b707ddd"), 2500, null, null, null, null, null, "Books", 0, "Like Me", false, null, null, 0m, 0 }
                });

            migrationBuilder.InsertData(
                table: "CatalogTypes",
                columns: new[] { "ObjectId", "Type" },
                values: new object[,]
                {
                    { new Guid("26d4cfc2-b7c2-44a1-ad8b-ae4a65ee6b52"), "Automotive" },
                    { new Guid("ab84e035-f725-45ec-9610-0d9146086a50"), "Baby" },
                    { new Guid("5c42326c-2cad-4b54-8082-265831d6608f"), "Books" },
                    { new Guid("35eecd4f-4b4e-4f7a-a302-4b912e4d91c7"), "Computers" },
                    { new Guid("0faf2591-97cc-46f3-91d7-ad121ac3d819"), "Electronics" },
                    { new Guid("8a1f8803-2c7a-476f-87f7-5b730eff1ca9"), "Men's Fashion" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ObjectId", "Address", "Email", "Firstname", "Password", "Phone", "Surname", "Username" },
                values: new object[,]
                {
                    { new Guid("e0a07b35-e930-48dd-8629-abd8998b1dcb"), null, "admin@outlook.com", "admin", "admin", null, null, null },
                    { new Guid("03e1e7f3-8dd3-4c4f-a381-672b3b7416f9"), null, "emretuna@outlook.com", "emre", "emre", null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogBrandObjectId",
                table: "CatalogItems",
                column: "CatalogBrandObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogTypeObjectId",
                table: "CatalogItems",
                column: "CatalogTypeObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CustomerCartObjectId",
                table: "CatalogItems",
                column: "CustomerCartObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCarts_BuyerId",
                table: "CustomerCarts",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCarts_OrderItemObjectId",
                table: "CustomerCarts",
                column: "OrderItemObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BuyerId",
                table: "OrderItems",
                column: "BuyerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItems");

            migrationBuilder.DropTable(
                name: "CatalogBrands");

            migrationBuilder.DropTable(
                name: "CatalogTypes");

            migrationBuilder.DropTable(
                name: "CustomerCarts");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
