﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterTakipSt.Data.Migrations
{
    public partial class turdegisimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SistemKullaniciId",
                table: "Gecmis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SistemKullaniciId",
                table: "Gecmis",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
