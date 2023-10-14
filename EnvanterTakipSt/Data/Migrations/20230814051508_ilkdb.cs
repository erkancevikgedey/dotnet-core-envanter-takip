using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterTakipSt.Data.Migrations
{
    public partial class ilkdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departman",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departman", x => x.DepartmanId);
                });

            migrationBuilder.CreateTable(
                name: "Malzeme",
                columns: table => new
                {
                    MalzemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzeme", x => x.MalzemeId);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<int>(type: "int", nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false),
                    Durumu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.PersonelId);
                    table.ForeignKey(
                        name: "FK_Personel_Departman_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departman",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gecmis",
                columns: table => new
                {
                    GecmisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    MalzemeId = table.Column<int>(type: "int", nullable: false),
                    GuncelTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GecmisZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SistemKullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gecmis", x => x.GecmisId);
                    table.ForeignKey(
                        name: "FK_Gecmis_Malzeme_MalzemeId",
                        column: x => x.MalzemeId,
                        principalTable: "Malzeme",
                        principalColumn: "MalzemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gecmis_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zimmet",
                columns: table => new
                {
                    ZimmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MalzemeId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    ZimmetTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zimmet", x => x.ZimmetId);
                    table.ForeignKey(
                        name: "FK_Zimmet_Malzeme_MalzemeId",
                        column: x => x.MalzemeId,
                        principalTable: "Malzeme",
                        principalColumn: "MalzemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zimmet_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gecmis_MalzemeId",
                table: "Gecmis",
                column: "MalzemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Gecmis_PersonelId",
                table: "Gecmis",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_DepartmanId",
                table: "Personel",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmet_MalzemeId",
                table: "Zimmet",
                column: "MalzemeId");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmet_PersonelId",
                table: "Zimmet",
                column: "PersonelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gecmis");

            migrationBuilder.DropTable(
                name: "Zimmet");

            migrationBuilder.DropTable(
                name: "Malzeme");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Departman");
        }
    }
}
