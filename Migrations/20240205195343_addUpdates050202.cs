using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayLess.Migrations
{
    /// <inheritdoc />
    public partial class addUpdates050202 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_EstoqueLojas_EstoqueLojaId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_EstoqueLojaId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lojas",
                table: "Lojas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstoqueLojas",
                table: "EstoqueLojas");

            migrationBuilder.DropColumn(
                name: "Estoque",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EstoqueLojaId",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Lojas",
                newName: "Loja");

            migrationBuilder.RenameTable(
                name: "EstoqueLojas",
                newName: "EstoqueLoja");

            migrationBuilder.RenameColumn(
                name: "IdLoja",
                table: "EstoqueLoja",
                newName: "Quantidade");

            migrationBuilder.AddColumn<int>(
                name: "LojaId",
                table: "EstoqueLoja",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "EstoqueLoja",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Loja",
                table: "Loja",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstoqueLoja",
                table: "EstoqueLoja",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueLoja_LojaId",
                table: "EstoqueLoja",
                column: "LojaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueLoja_ProdutoId",
                table: "EstoqueLoja",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLoja_Loja_LojaId",
                table: "EstoqueLoja",
                column: "LojaId",
                principalTable: "Loja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLoja_Produtos_ProdutoId",
                table: "EstoqueLoja",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLoja_Loja_LojaId",
                table: "EstoqueLoja");

            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLoja_Produtos_ProdutoId",
                table: "EstoqueLoja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Loja",
                table: "Loja");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstoqueLoja",
                table: "EstoqueLoja");

            migrationBuilder.DropIndex(
                name: "IX_EstoqueLoja_LojaId",
                table: "EstoqueLoja");

            migrationBuilder.DropIndex(
                name: "IX_EstoqueLoja_ProdutoId",
                table: "EstoqueLoja");

            migrationBuilder.DropColumn(
                name: "LojaId",
                table: "EstoqueLoja");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "EstoqueLoja");

            migrationBuilder.RenameTable(
                name: "Loja",
                newName: "Lojas");

            migrationBuilder.RenameTable(
                name: "EstoqueLoja",
                newName: "EstoqueLojas");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "EstoqueLojas",
                newName: "IdLoja");

            migrationBuilder.AddColumn<int>(
                name: "Estoque",
                table: "Produtos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstoqueLojaId",
                table: "Produtos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lojas",
                table: "Lojas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstoqueLojas",
                table: "EstoqueLojas",
                column: "Id");

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
    }
}
