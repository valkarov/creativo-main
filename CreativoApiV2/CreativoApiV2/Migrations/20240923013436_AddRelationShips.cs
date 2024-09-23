using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationShips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Entrepeneurships_EntrepeneurshipId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopPhotos_Workshops_WorkshopId",
                table: "WorkshopPhotos");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Entrepeneurships_EntrepeneurshipId",
                table: "Orders",
                column: "EntrepeneurshipId",
                principalTable: "Entrepeneurships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopPhotos_Workshops_WorkshopId",
                table: "WorkshopPhotos",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Entrepeneurships_EntrepeneurshipId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkshopPhotos_Workshops_WorkshopId",
                table: "WorkshopPhotos");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Entrepeneurships_EntrepeneurshipId",
                table: "Orders",
                column: "EntrepeneurshipId",
                principalTable: "Entrepeneurships",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkshopPhotos_Workshops_WorkshopId",
                table: "WorkshopPhotos",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
