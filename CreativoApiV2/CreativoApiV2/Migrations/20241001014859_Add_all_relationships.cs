using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreativoApiV2.Migrations
{
    /// <inheritdoc />
    public partial class Add_all_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryManId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryManId",
                table: "Orders",
                column: "DeliveryManId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_DeliveryManId",
                table: "Orders",
                column: "DeliveryManId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_DeliveryManId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryManId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryManId",
                table: "Orders");
        }
    }
}
