using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Vize_Proje.Migrations
{
    public partial class VeritabanininKurulmasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duyurular",
                columns: table => new
                {
                    DuyuruID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuyuruBasligi = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DuyuruAciklamasi = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    DuyuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurular", x => x.DuyuruID);
                });

            migrationBuilder.CreateTable(
                name: "Yoneticiler",
                columns: table => new
                {
                    YoneticiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YoneticiKullanıcıAdi = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    YoneticiSifre = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yoneticiler", x => x.YoneticiID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duyurular");

            migrationBuilder.DropTable(
                name: "Yoneticiler");
        }
    }
}
