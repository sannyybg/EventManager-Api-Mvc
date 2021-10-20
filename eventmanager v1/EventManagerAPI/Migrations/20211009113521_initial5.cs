using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagerAPI.Migrations
{
    public partial class initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 35, 21, 504, DateTimeKind.Local).AddTicks(8962));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 3, "lmessi@gmail.com", "leo", "messi", "test1234" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 2, "james@gmail.com", "james", "smith", "test1234" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "StartDate", "Title", "UserId", "isPublished" },
                values: new object[] { 6, "descr", new DateTime(2021, 10, 9, 15, 35, 21, 506, DateTimeKind.Local).AddTicks(804), "EventTitle", 2, false });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "StartDate", "Title", "UserId", "isPublished" },
                values: new object[] { 7, "description", new DateTime(2021, 10, 9, 15, 35, 21, 506, DateTimeKind.Local).AddTicks(915), "FootballMatch", 3, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartDate",
                value: new DateTime(2021, 10, 9, 15, 33, 7, 212, DateTimeKind.Local).AddTicks(5700));
        }
    }
}
