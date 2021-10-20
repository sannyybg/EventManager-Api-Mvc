using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagerAPI.Migrations
{
    public partial class initial23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAchieved",
                table: "Events",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 10, 13, 26, 23, 556, DateTimeKind.Local).AddTicks(1731));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2021, 10, 10, 13, 26, 23, 557, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2021, 10, 10, 13, 26, 23, 557, DateTimeKind.Local).AddTicks(4371));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAchieved",
                table: "Events");

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
    }
}
