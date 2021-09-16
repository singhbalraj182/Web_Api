using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace SI_Web_API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimpleInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Principal = table.Column<float>(nullable: false),
                    Rate = table.Column<float>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Interest = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleInterests", x => x.Id);
                });
            var sqlFile = Path.Combine(".\\Scripts", @"backup.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimpleInterests");
        }
    }
}
