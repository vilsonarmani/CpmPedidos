﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CpmPedidos.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categoria_produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categoria_produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_imagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nome_arquivo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    principal = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_categoria_produto_id_categoria",
                        column: x => x.id_categoria,
                        principalTable: "tb_categoria_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    id_cidade = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_endereco_tb_cidade_id_cidade",
                        column: x => x.id_cidade,
                        principalTable: "tb_cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_combo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    id_imagem = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_combo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_combo_tb_imagem_id_imagem",
                        column: x => x.id_imagem,
                        principalTable: "tb_imagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_imagem_produto",
                columns: table => new
                {
                    id_imagem = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_imagem_produto", x => new { x.id_imagem, x.id_produto });
                    table.ForeignKey(
                        name: "FK_tb_imagem_produto_tb_imagem_id_imagem",
                        column: x => x.id_imagem,
                        principalTable: "tb_imagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_imagem_produto_tb_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "tb_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_promocao_produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    id_imagem = table.Column<int>(type: "int", nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_promocao_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_promocao_produto_tb_imagem_id_imagem",
                        column: x => x.id_imagem,
                        principalTable: "tb_imagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_promocao_produto_tb_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "tb_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    id_endereco = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_cliente_tb_endereco_id_endereco",
                        column: x => x.id_endereco,
                        principalTable: "tb_endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto_combo",
                columns: table => new
                {
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    id_combo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto_combo", x => new { x.id_produto, x.id_combo });
                    table.ForeignKey(
                        name: "FK_tb_produto_combo_tb_combo_id_combo",
                        column: x => x.id_combo,
                        principalTable: "tb_combo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_combo_tb_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "tb_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    entrega = table.Column<TimeSpan>(type: "time", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_pedido_tb_cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "tb_cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto_pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(type: "int", precision: 2, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    id_pedido = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_produto_pedido_tb_pedido_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "tb_pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_produto_pedido_tb_produto_id_produto",
                        column: x => x.id_produto,
                        principalTable: "tb_produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_cliente_id_endereco",
                table: "tb_cliente",
                column: "id_endereco",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_combo_id_imagem",
                table: "tb_combo",
                column: "id_imagem");

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_id_cidade",
                table: "tb_endereco",
                column: "id_cidade");

            migrationBuilder.CreateIndex(
                name: "IX_tb_imagem_produto_id_produto",
                table: "tb_imagem_produto",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pedido_id_cliente",
                table: "tb_pedido",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_id_categoria",
                table: "tb_produto",
                column: "id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_combo_id_combo",
                table: "tb_produto_combo",
                column: "id_combo");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_pedido_id_pedido",
                table: "tb_produto_pedido",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_pedido_id_produto",
                table: "tb_produto_pedido",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promocao_produto_id_imagem",
                table: "tb_promocao_produto",
                column: "id_imagem");

            migrationBuilder.CreateIndex(
                name: "IX_tb_promocao_produto_id_produto",
                table: "tb_promocao_produto",
                column: "id_produto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_imagem_produto");

            migrationBuilder.DropTable(
                name: "tb_produto_combo");

            migrationBuilder.DropTable(
                name: "tb_produto_pedido");

            migrationBuilder.DropTable(
                name: "tb_promocao_produto");

            migrationBuilder.DropTable(
                name: "tb_combo");

            migrationBuilder.DropTable(
                name: "tb_pedido");

            migrationBuilder.DropTable(
                name: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_imagem");

            migrationBuilder.DropTable(
                name: "tb_cliente");

            migrationBuilder.DropTable(
                name: "tb_categoria_produto");

            migrationBuilder.DropTable(
                name: "tb_endereco");

            migrationBuilder.DropTable(
                name: "tb_cidade");
        }
    }
}
