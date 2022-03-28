using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KapsamliProje.Dal.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FatDetails_Products_ProductId",
                table: "FatDetails");

            migrationBuilder.DropIndex(
                name: "IX_FatDetails_ProductId",
                table: "FatDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "FatDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FatDetails_ProductsId",
                table: "FatDetails",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_FatDetails_Products_ProductsId",
                table: "FatDetails",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FatDetails_Products_ProductsId",
                table: "FatDetails");

            migrationBuilder.DropIndex(
                name: "IX_FatDetails_ProductsId",
                table: "FatDetails");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "FatDetails");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FatDetails_ProductId",
                table: "FatDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FatDetails_Products_ProductId",
                table: "FatDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
