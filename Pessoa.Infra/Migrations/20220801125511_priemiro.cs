using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pessoa.Infra.Migrations
{
    public partial class priemiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Idade = table.Column<int>(type: "INTEGER", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: false),
                    Pais = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    CEP = table.Column<string>(type: "TEXT", nullable: false),
                    Rua = table.Column<string>(type: "TEXT", nullable: false),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    PessoaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaId",
                table: "Enderecos",
                column: "PessoaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
