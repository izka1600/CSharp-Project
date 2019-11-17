using Microsoft.EntityFrameworkCore.Migrations;

namespace ArkuszDataBase.Migrations
{
    public partial class FilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SciezkaDoZdjecia",
                table: "Kategorie",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SciezkaDoZdjecia",
                table: "Kategorie");
        }
    }
}
