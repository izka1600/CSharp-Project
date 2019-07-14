using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArkuszDataBase.Migrations
{
    public partial class DodajkolumnedoUzytkownika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataUsuniecia",
                table: "Uzytkownik",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUsuniecia",
                table: "Uzytkownik");
        }
    }
}
