using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeProject.Data.Migrations
{
    public partial class updatedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CoffeItem",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CoffeItem",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "MinimumBestBeforeDate",
                value: new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "MinimumBestBeforeDate",
                value: new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "MinimumBestBeforeDate",
                value: new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "MinimumBestBeforeDate",
                value: new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "MinimumBestBeforeDate",
                value: new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "MinimumBestBeforeDate",
                value: new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1990, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CoffeItem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CoffeItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 4,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 5,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 6,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CoffeItem",
                keyColumn: "Id",
                keyValue: 7,
                column: "MinimumBestBeforeDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
