using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class add_supply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supply",
                columns: table => new
                {
                    SupplyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceivingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsReceived = table.Column<bool>(type: "bit", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply", x => x.SupplyID);
                });

            migrationBuilder.CreateTable(
                name: "Supply_Product",
                columns: table => new
                {
                    Supply_ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplyID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply_Product", x => x.Supply_ProductID);
                    table.ForeignKey(
                        name: "FK_Supply_Product_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supply_Product_Supply_SupplyID",
                        column: x => x.SupplyID,
                        principalTable: "Supply",
                        principalColumn: "SupplyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supply_Product_ProductID",
                table: "Supply_Product",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_Product_SupplyID",
                table: "Supply_Product",
                column: "SupplyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supply_Product");

            migrationBuilder.DropTable(
                name: "Supply");
        }
    }
}
