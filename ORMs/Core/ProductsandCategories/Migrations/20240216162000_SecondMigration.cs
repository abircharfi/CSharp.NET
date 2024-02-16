using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsandCategories.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Products_AssociatedProductProductId",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_AssociatedProductProductId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "AssociatedProductProductId",
                table: "Associations");

            migrationBuilder.RenameColumn(
                name: "ProdutcId",
                table: "Associations",
                newName: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Associations_ProductId",
                table: "Associations",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Products_ProductId",
                table: "Associations");

            migrationBuilder.DropIndex(
                name: "IX_Associations_ProductId",
                table: "Associations");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Associations",
                newName: "ProdutcId");

            migrationBuilder.AddColumn<int>(
                name: "AssociatedProductProductId",
                table: "Associations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Associations_AssociatedProductProductId",
                table: "Associations",
                column: "AssociatedProductProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Products_AssociatedProductProductId",
                table: "Associations",
                column: "AssociatedProductProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
