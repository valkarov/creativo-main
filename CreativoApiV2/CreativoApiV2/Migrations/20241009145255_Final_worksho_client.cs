using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class Final_worksho_client : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "WorkShopClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastDigits",
                table: "WorkShopClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "owner",
                table: "WorkShopClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "WorkShopClients",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "WorkShopClients");

            migrationBuilder.DropColumn(
                name: "lastDigits",
                table: "WorkShopClients");

            migrationBuilder.DropColumn(
                name: "owner",
                table: "WorkShopClients");

            migrationBuilder.DropColumn(
                name: "price",
                table: "WorkShopClients");
        }
    }
}
