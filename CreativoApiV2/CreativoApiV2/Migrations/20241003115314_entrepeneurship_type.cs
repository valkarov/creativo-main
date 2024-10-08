using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class entrepeneurship_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntrepeneurshipTypeId",
                table: "Entrepeneurships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EntrepeneurshipType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrepeneurshipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrepeneurships_EntrepeneurshipTypeId",
                table: "Entrepeneurships",
                column: "EntrepeneurshipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepeneurships_EntrepeneurshipType_EntrepeneurshipTypeId",
                table: "Entrepeneurships",
                column: "EntrepeneurshipTypeId",
                principalTable: "EntrepeneurshipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepeneurships_EntrepeneurshipType_EntrepeneurshipTypeId",
                table: "Entrepeneurships");

            migrationBuilder.DropTable(
                name: "EntrepeneurshipType");

            migrationBuilder.DropIndex(
                name: "IX_Entrepeneurships_EntrepeneurshipTypeId",
                table: "Entrepeneurships");

            migrationBuilder.DropColumn(
                name: "EntrepeneurshipTypeId",
                table: "Entrepeneurships");
        }
    }
}
