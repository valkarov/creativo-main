using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class workshop_client_remove_owner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "owner",
                table: "WorkShopClients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "owner",
                table: "WorkShopClients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
