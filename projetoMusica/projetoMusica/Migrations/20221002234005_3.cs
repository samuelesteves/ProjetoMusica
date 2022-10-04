using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoMusica.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    artistName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    mainInstrument = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    mainGenre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    born = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    group = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artists", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "artists");
        }
    }
}
