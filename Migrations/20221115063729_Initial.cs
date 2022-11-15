using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAuto.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutoSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineVolume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomsCleared = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoSales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoSales");
        }
    }
}
