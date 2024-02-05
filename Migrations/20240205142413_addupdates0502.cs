using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayLess.Migrations
{
    /// <inheritdoc />
    public partial class addupdates0502 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstoqueLojaId",
                table: "Produtos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstoqueLojas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdLoja = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueLojas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstoqueLojaId",
                table: "Produtos",
                column: "EstoqueLojaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_EstoqueLojas_EstoqueLojaId",
                table: "Produtos",
                column: "EstoqueLojaId",
                principalTable: "EstoqueLojas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_EstoqueLojas_EstoqueLojaId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "EstoqueLojas");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_EstoqueLojaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EstoqueLojaId",
                table: "Produtos");
        }
    }
}
