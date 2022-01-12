using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelTravelMemories.Data.Migrations
{
    public partial class CheckoutId_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Checkouts_CheckoutId",
                table: "Reservas");

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Checkouts_CheckoutId",
                table: "Reservas",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Checkouts_CheckoutId",
                table: "Reservas");

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Checkouts_CheckoutId",
                table: "Reservas",
                column: "CheckoutId",
                principalTable: "Checkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
