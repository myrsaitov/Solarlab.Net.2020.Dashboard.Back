using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Context.Migrations
{
    public partial class AdvertTagsWereAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertTag_Advertisements_AdvertId",
                table: "AdvertTag");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertTag_Tags_TagId",
                table: "AdvertTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertTag",
                table: "AdvertTag");

            migrationBuilder.RenameTable(
                name: "AdvertTag",
                newName: "AdvertTags");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertTag_TagId",
                table: "AdvertTags",
                newName: "IX_AdvertTags_TagId");

            migrationBuilder.AlterColumn<string>(
                name: "TagText",
                table: "Tags",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertTags",
                table: "AdvertTags",
                columns: new[] { "AdvertId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertTags_Advertisements_AdvertId",
                table: "AdvertTags",
                column: "AdvertId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertTags_Tags_TagId",
                table: "AdvertTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdvertTags_Advertisements_AdvertId",
                table: "AdvertTags");

            migrationBuilder.DropForeignKey(
                name: "FK_AdvertTags_Tags_TagId",
                table: "AdvertTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdvertTags",
                table: "AdvertTags");

            migrationBuilder.RenameTable(
                name: "AdvertTags",
                newName: "AdvertTag");

            migrationBuilder.RenameIndex(
                name: "IX_AdvertTags_TagId",
                table: "AdvertTag",
                newName: "IX_AdvertTag_TagId");

            migrationBuilder.AlterColumn<string>(
                name: "TagText",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdvertTag",
                table: "AdvertTag",
                columns: new[] { "AdvertId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertTag_Advertisements_AdvertId",
                table: "AdvertTag",
                column: "AdvertId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdvertTag_Tags_TagId",
                table: "AdvertTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
