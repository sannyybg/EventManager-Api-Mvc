using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagerAPI.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 14, 4, 20, 782, DateTimeKind.Local).AddTicks(5840));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 13, 58, 0, 70, DateTimeKind.Local).AddTicks(7897));
        }
    }
}
