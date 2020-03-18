using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Context.Migrations
{
    public partial class AdvertisementWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Advertisements",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisements",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Advertisements");
        }
    }
}
