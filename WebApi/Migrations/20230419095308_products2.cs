using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class products2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Is_Deleted",
                table: "Product",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorCode",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Is_Cover = table.Column<bool>(type: "bit", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoID);
                    table.ForeignKey(
                        name: "FK_Photo_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "StoneType",
                columns: table => new
                {
                    StoneTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoneType", x => x.StoneTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Insert",
                columns: table => new
                {
                    InsertID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StoneTypeID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insert", x => x.InsertID);
                    table.ForeignKey(
                        name: "FK_Insert_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_Insert_StoneType_StoneTypeID",
                        column: x => x.StoneTypeID,
                        principalTable: "StoneType",
                        principalColumn: "StoneTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insert_ProductID",
                table: "Insert",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Insert_StoneTypeID",
                table: "Insert",
                column: "StoneTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_ProductID",
                table: "Photo",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insert");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "StoneType");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Is_Deleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "VendorCode",
                table: "Product");
        }
    }
}
