using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagerAPI.Migrations
{
    public partial class initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 11, 13, 25, 23, 721, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartDate",
                value: new DateTime(2021, 10, 11, 13, 25, 23, 722, DateTimeKind.Local).AddTicks(9205));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartDate",
                value: new DateTime(2021, 10, 11, 13, 25, 23, 722, DateTimeKind.Local).AddTicks(9271));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "Users");

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
    }
}
