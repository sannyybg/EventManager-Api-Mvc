using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagerAPI.Migrations
{
    public partial class initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChangePossibility",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 48, 52, 332, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 48, 52, 334, DateTimeKind.Local).AddTicks(657));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 48, 52, 334, DateTimeKind.Local).AddTicks(729));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePossibility",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 35, 21, 504, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 35, 21, 506, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 35, 21, 506, DateTimeKind.Local).AddTicks(915));
        }
    }
}
