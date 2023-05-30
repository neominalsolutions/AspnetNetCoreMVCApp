using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspnetNetCoreMVCApp.Migrations
{
    public partial class ManyToMany1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ATable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AB",
                columns: table => new
                {
                    AListId = table.Column<int>(type: "int", nullable: false),
                    BListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AB", x => new { x.AListId, x.BListId });
                    table.ForeignKey(
                        name: "FK_AB_ATable_AListId",
                        column: x => x.AListId,
                        principalTable: "ATable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AB_BTable_BListId",
                        column: x => x.BListId,
                        principalTable: "BTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AB_BListId",
                table: "AB",
                column: "BListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AB");

            migrationBuilder.DropTable(
                name: "ATable");

            migrationBuilder.DropTable(
                name: "BTable");
        }
    }
}
