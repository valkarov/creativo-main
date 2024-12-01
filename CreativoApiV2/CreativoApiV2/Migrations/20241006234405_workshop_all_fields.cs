using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class workshop_all_fields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Workshops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Workshops",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Workshops");
        }
    }
}
