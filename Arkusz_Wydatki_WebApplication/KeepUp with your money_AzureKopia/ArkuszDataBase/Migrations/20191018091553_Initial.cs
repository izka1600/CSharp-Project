using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArkuszDataBase.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaportFromMonths",
                columns: table => new
                {
                    DateOfTransaction = table.Column<DateTime>(nullable: false),
                    Kategoria = table.Column<string>(nullable: true),
                    Podkategoria = table.Column<string>(nullable: true),
                    Kwota = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaportFromMonths", x => x.DateOfTransaction);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    Uzyt_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(maxLength: 30, nullable: true),
                    Nazwisko = table.Column<string>(maxLength: 50, nullable: true),
                    Nick = table.Column<string>(maxLength: 30, nullable: true),
                    e_mail = table.Column<string>(maxLength: 50, nullable: true),
                    DataDodania = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    OstatnieLogowanie = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataUsuniecia = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Uzytkown__866806738B051B36", x => x.Uzyt_ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Kat_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kategoria = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    UzId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Kategori__87B3726890867C4A", x => x.Kat_Id);
                    table.ForeignKey(
                        name: "FKUzytkownik_K",
                        column: x => x.UzId,
                        principalTable: "Uzytkownik",
                        principalColumn: "Uzyt_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Plan_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Miesiąc = table.Column<DateTime>(type: "date", nullable: true),
                    ZalozonaKwota = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    FaktycznaKwota = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    IdUzytkownika = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    Warning = table.Column<int>(nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Plan_ID);
                    table.ForeignKey(
                        name: "FKPlanUzytkownik",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "Uzyt_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Podkategorie",
                columns: table => new
                {
                    Pod_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdKategorii = table.Column<int>(nullable: true),
                    Podkategoria = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Podkateg__6680BE6EF145A89C", x => x.Pod_ID);
                    table.ForeignKey(
                        name: "FKPKategoria",
                        column: x => x.IdKategorii,
                        principalTable: "Kategorie",
                        principalColumn: "Kat_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transakcje",
                columns: table => new
                {
                    Trans_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IdUzytkownika = table.Column<int>(nullable: false),
                    IdKategorii = table.Column<int>(nullable: false),
                    IdPodkategorii = table.Column<int>(nullable: false),
                    Kwota = table.Column<double>(nullable: true),
                    PlanId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Transakc__7B615C8D012D977A", x => x.Trans_ID);
                    table.ForeignKey(
                        name: "FKKategoria",
                        column: x => x.IdKategorii,
                        principalTable: "Kategorie",
                        principalColumn: "Kat_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKPodKategoria",
                        column: x => x.IdPodkategorii,
                        principalTable: "Podkategorie",
                        principalColumn: "Pod_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKUzytkownik",
                        column: x => x.IdUzytkownika,
                        principalTable: "Uzytkownik",
                        principalColumn: "Uzyt_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "KatName",
                table: "Kategorie",
                column: "Kategoria",
                unique: true,
                filter: "[Kategoria] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorie_UzId",
                table: "Kategorie",
                column: "UzId");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_IdUzytkownika",
                table: "Plan",
                column: "IdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "PlanUnique",
                table: "Plan",
                columns: new[] { "Miesiąc", "ZalozonaKwota", "FaktycznaKwota", "IdUzytkownika" },
                unique: true,
                filter: "[Miesiąc] IS NOT NULL AND [ZalozonaKwota] IS NOT NULL AND [FaktycznaKwota] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Podkategorie_IdKategorii",
                table: "Podkategorie",
                column: "IdKategorii");

            migrationBuilder.CreateIndex(
                name: "PodName",
                table: "Podkategorie",
                column: "Podkategoria",
                unique: true,
                filter: "[Podkategoria] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_IdKategorii",
                table: "Transakcje",
                column: "IdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_IdPodkategorii",
                table: "Transakcje",
                column: "IdPodkategorii");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcje_IdUzytkownika",
                table: "Transakcje",
                column: "IdUzytkownika");

            migrationBuilder.CreateIndex(
                name: "TranUnique",
                table: "Transakcje",
                columns: new[] { "Data", "IdUzytkownika", "IdKategorii", "IdPodkategorii", "Kwota" },
                unique: true,
                filter: "[Data] IS NOT NULL AND [Kwota] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "U_Email",
                table: "Uzytkownik",
                column: "e_mail",
                unique: true,
                filter: "[e_mail] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "RaportFromMonths");

            migrationBuilder.DropTable(
                name: "Transakcje");

            migrationBuilder.DropTable(
                name: "Podkategorie");

            migrationBuilder.DropTable(
                name: "Kategorie");

            migrationBuilder.DropTable(
                name: "Uzytkownik");
        }
    }
}
