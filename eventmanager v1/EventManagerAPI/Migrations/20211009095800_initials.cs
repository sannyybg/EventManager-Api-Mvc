using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManagerAPI.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(unicode: false, fixedLength: true, maxLength: 20, nullable: false),
                    Description = table.Column<string>(unicode: false, fixedLength: true, maxLength: 80, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    isPublished = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "StartDate", "Title", "isPublished" },
                values: new object[] { 1, "descr", new DateTime(2021, 10, 9, 13, 58, 0, 70, DateTimeKind.Local).AddTicks(7897), "titletest", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
