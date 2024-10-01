using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class Add_forum_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "ForumComments");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Forums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ForumComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Forums_AuthorId",
                table: "Forums",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumComments_AuthorId",
                table: "ForumComments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumComments_Users_AuthorId",
                table: "ForumComments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Users_AuthorId",
                table: "Forums",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumComments_Users_AuthorId",
                table: "ForumComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Users_AuthorId",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Forums_AuthorId",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_ForumComments_AuthorId",
                table: "ForumComments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Forums");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ForumComments");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Forums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "ForumComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
