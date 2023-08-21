using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infrastructure.Migrations
{
    public partial class ItemWarehouseIDNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Warehouses_WarehousesId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "WarehousesId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Warehouses_WarehousesId",
                table: "Items",
                column: "WarehousesId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Warehouses_WarehousesId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "WarehousesId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Warehouses_WarehousesId",
                table: "Items",
                column: "WarehousesId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
