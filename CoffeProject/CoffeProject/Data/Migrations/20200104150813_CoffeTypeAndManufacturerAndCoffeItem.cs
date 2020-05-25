using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeProject.Data.Migrations
{
    public partial class CoffeTypeAndManufacturerAndCoffeItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    CoffeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoffeItem_CoffeType_CoffeTypeId",
                        column: x => x.CoffeTypeId,
                        principalTable: "CoffeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeItem_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CoffeType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ziarnista" },
                    { 2, "Mielona" },
                    { 3, "Cafissimo" },
                    { 4, "Tassimo" },
                    { 5, "Senseo" },
                    { 6, "Dolce Gusto" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lavazza" },
                    { 2, "Dallmayr" },
                    { 3, "Segafredo" },
                    { 4, "Gimoka" },
                    { 5, "Tchibo" },
                    { 6, "Jacobs" },
                    { 7, "Nescafe" }
                });

            migrationBuilder.InsertData(
                table: "CoffeItem",
                columns: new[] { "Id", "CoffeTypeId", "Description", "ManufacturerId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "kupuj i się nie zastanawiaj", 1, "Kawa ziarnista idealna dla każdego :)", 20.199999999999999, 10 },
                    { 2, 2, "kupuj bo tania, cena za 1kg", 1, "Kawa mielona :)", 10.699999999999999, 10 },
                    { 7, 1, "Nie wiem czemu taka droga, raczej nie warta swojej ceny", 1, "Kawa super droga", 999.89999999999998, 10 },
                    { 5, 5, "kupuj", 2, "Saszetki Senseo", 70.200000000000003, 10 },
                    { 4, 4, "kupuj", 5, "Kapsułki Tassimo", 23.140000000000001, 10 },
                    { 3, 3, "kupuj", 6, "Kapsułki Cafissimo", 30.600000000000001, 10 },
                    { 6, 6, "kupuj", 7, "Kapsułki Dolce Gusto", 66.599999999999994, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeItem_CoffeTypeId",
                table: "CoffeItem",
                column: "CoffeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeItem_ManufacturerId",
                table: "CoffeItem",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeItem");

            migrationBuilder.DropTable(
                name: "CoffeType");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
