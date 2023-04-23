using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addproductinsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insert_Product_ProductID",
                table: "Insert");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Product_ProductID",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Photo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "photoUrl",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Insert",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insert_Product_ProductID",
                table: "Insert",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Product_ProductID",
                table: "Photo",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insert_Product_ProductID",
                table: "Insert");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Product_ProductID",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "photoUrl",
                table: "Photo");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Photo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Insert",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Insert_Product_ProductID",
                table: "Insert",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Product_ProductID",
                table: "Photo",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID");
        }
    }
}
