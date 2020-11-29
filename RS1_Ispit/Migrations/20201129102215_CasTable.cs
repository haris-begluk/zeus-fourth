using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_Ispit_asp.net_core.Migrations
{
    public partial class CasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OdrzanCas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    NastavnikId = table.Column<int>(nullable: false),
                    OdjeljenjeId = table.Column<int>(nullable: false),
                    PredmetId = table.Column<int>(nullable: false),
                    SadrzajCasa = table.Column<string>(nullable: true),
                    SkolaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdrzanCas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdrzanCas_Nastavnik_NastavnikId",
                        column: x => x.NastavnikId,
                        principalTable: "Nastavnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdrzanCas_Odjeljenje_OdjeljenjeId",
                        column: x => x.OdjeljenjeId,
                        principalTable: "Odjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OdrzanCas_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdrzanCas_Skola_SkolaId",
                        column: x => x.SkolaId,
                        principalTable: "Skola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OdrzanCasDetalji",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Napomena = table.Column<string>(nullable: true),
                    Ocjena = table.Column<int>(nullable: false),
                    OdjeljenjeStavkaId = table.Column<int>(nullable: false),
                    OdrzanCasId = table.Column<int>(nullable: false),
                    OpravdanoOdsutan = table.Column<bool>(nullable: false),
                    Prisutan = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdrzanCasDetalji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OdrzanCasDetalji_OdjeljenjeStavka_OdjeljenjeStavkaId",
                        column: x => x.OdjeljenjeStavkaId,
                        principalTable: "OdjeljenjeStavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OdrzanCasDetalji_OdrzanCas_OdrzanCasId",
                        column: x => x.OdrzanCasId,
                        principalTable: "OdrzanCas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCas_NastavnikId",
                table: "OdrzanCas",
                column: "NastavnikId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCas_OdjeljenjeId",
                table: "OdrzanCas",
                column: "OdjeljenjeId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCas_PredmetId",
                table: "OdrzanCas",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCas_SkolaId",
                table: "OdrzanCas",
                column: "SkolaId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCasDetalji_OdjeljenjeStavkaId",
                table: "OdrzanCasDetalji",
                column: "OdjeljenjeStavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_OdrzanCasDetalji_OdrzanCasId",
                table: "OdrzanCasDetalji",
                column: "OdrzanCasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OdrzanCasDetalji");

            migrationBuilder.DropTable(
                name: "OdrzanCas");
        }
    }
}
