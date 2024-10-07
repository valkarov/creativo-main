using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class add_workshop_entrepeneurship_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntrepeneurshipId",
                table: "Workshops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_EntrepeneurshipId",
                table: "Workshops",
                column: "EntrepeneurshipId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workshops_Entrepeneurships_EntrepeneurshipId",
                table: "Workshops",
                column: "EntrepeneurshipId",
                principalTable: "Entrepeneurships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workshops_Entrepeneurships_EntrepeneurshipId",
                table: "Workshops");

            migrationBuilder.DropIndex(
                name: "IX_Workshops_EntrepeneurshipId",
                table: "Workshops");

            migrationBuilder.DropColumn(
                name: "EntrepeneurshipId",
                table: "Workshops");
        }
    }
}
