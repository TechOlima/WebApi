using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addstorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Product");

            migrationBuilder.DropTable(
                name: "Supply_Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    SupplyID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageID);
                    table.ForeignKey(
                        name: "FK_Storage_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK_Storage_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Storage_Supply_SupplyID",
                        column: x => x.SupplyID,
                        principalTable: "Supply",
                        principalColumn: "SupplyID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Storage_OrderID",
                table: "Storage",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_ProductID",
                table: "Storage",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_SupplyID",
                table: "Storage",
                column: "SupplyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order_Product",
                columns: table => new
                {
                    Order_ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Product", x => x.Order_ProductID);
                    table.ForeignKey(
                        name: "FK_Order_Product_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Product_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supply_Product",
                columns: table => new
                {
                    Supply_ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    SupplyID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Order_Product_OrderID",
                table: "Order_Product",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Product_ProductID",
                table: "Order_Product",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_Product_ProductID",
                table: "Supply_Product",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_Product_SupplyID",
                table: "Supply_Product",
                column: "SupplyID");
        }
    }
}
