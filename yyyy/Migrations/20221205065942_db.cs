using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yyyy.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomStock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndexShortCut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixActuel = table.Column<decimal>(type: "decimal(20,6)", precision: 20, scale: 6, nullable: false),
                    PrixInitial = table.Column<decimal>(type: "decimal(20,6)", precision: 20, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
