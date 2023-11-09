using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginForm.Data.Migrations
{
    public partial class UpperidtoLowerid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PlayDate",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlayDate",
                newName: "ID");
        }
    }
}
