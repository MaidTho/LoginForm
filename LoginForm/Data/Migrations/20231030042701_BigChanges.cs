using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoginForm.Data.Migrations
{
    public partial class BigChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayDate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserCreator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateForPlayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayDateAccepted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayDate", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayDate");
        }
    }
}
