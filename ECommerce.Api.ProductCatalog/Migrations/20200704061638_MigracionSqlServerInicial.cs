using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Api.ProductCatalog.Migrations
{
    public partial class MigracionSqlServerInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                  Id = table.Column<Guid>(nullable: false),
                  Description = table.Column<string>(nullable: true),
                  DateCreated = table.Column<DateTime>(nullable: true),
                  Category = table.Column<string>(nullable: true),
                  Price = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
