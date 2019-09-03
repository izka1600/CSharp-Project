using Microsoft.EntityFrameworkCore.Migrations;

namespace ArkuszDataBase.Migrations
{
    public partial class IdUzyt_in_KatTab_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<int> (
				name: "UzId",
				table: "Kategorie",
				nullable: true);
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
