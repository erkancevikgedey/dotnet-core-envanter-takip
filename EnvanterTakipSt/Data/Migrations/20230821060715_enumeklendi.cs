using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvanterTakipSt.Data.Migrations
{
    public partial class enumeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Islem",
                table: "Gecmis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Islem",
                table: "Gecmis");
        }
    }
}
