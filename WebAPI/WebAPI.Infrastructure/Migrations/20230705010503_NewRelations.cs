using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Infrastructure.Migrations
{
    public partial class NewRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Warehouses_WarehouseId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "MerchantWarehouse");

            migrationBuilder.DropIndex(
                name: "IX_Items_WarehouseId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "WarehousesId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_MerchantId",
                table: "Warehouses",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_WarehousesId",
                table: "Items",
                column: "WarehousesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Warehouses_WarehousesId",
                table: "Items",
                column: "WarehousesId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Merchants_MerchantId",
                table: "Warehouses",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Warehouses_WarehousesId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Merchants_MerchantId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_MerchantId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Items_WarehousesId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WarehousesId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MerchantWarehouse",
                columns: table => new
                {
                    MerchantsId = table.Column<int>(type: "int", nullable: false),
                    WarehousesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantWarehouse", x => new { x.MerchantsId, x.WarehousesId });
                    table.ForeignKey(
                        name: "FK_MerchantWarehouse_Merchants_MerchantsId",
                        column: x => x.MerchantsId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchantWarehouse_Warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_WarehouseId",
                table: "Items",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantWarehouse_WarehousesId",
                table: "MerchantWarehouse",
                column: "WarehousesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Warehouses_WarehouseId",
                table: "Items",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }
    }
}
