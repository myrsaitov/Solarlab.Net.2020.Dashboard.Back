using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Context.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Advertisements_ParentAdvertisementId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentAdvertisementId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentAdvertisementId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AdvertisementId",
                table: "Comments",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Advertisements_AdvertisementId",
                table: "Comments",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Advertisements_AdvertisementId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AdvertisementId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "ParentAdvertisementId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentAdvertisementId",
                table: "Comments",
                column: "ParentAdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Advertisements_ParentAdvertisementId",
                table: "Comments",
                column: "ParentAdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
