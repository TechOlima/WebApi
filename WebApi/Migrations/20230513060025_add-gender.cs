using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class addgender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Product",
                newName: "GenderTypeID");

            migrationBuilder.CreateTable(
                name: "GenderType",
                columns: table => new
                {
                    GenderTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderType", x => x.GenderTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_GenderTypeID",
                table: "Product",
                column: "GenderTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_GenderType_GenderTypeID",
                table: "Product",
                column: "GenderTypeID",
                principalTable: "GenderType",
                principalColumn: "GenderTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_GenderType_GenderTypeID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "GenderType");

            migrationBuilder.DropIndex(
                name: "IX_Product_GenderTypeID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "GenderTypeID",
                table: "Product",
                newName: "Gender");
        }
    }
}
