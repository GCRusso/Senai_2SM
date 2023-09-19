using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.event_.manha.Migrations
{
    /// <inheritdoc />
    public partial class BD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstituicaoDomain",
                columns: table => new
                {
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "CHAR(14)", maxLength: 14, nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituicaoDomain", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "TiposEventoDomain",
                columns: table => new
                {
                    IdTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEventoDomain", x => x.IdTipoEvento);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarioDomain",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarioDomain", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "EventoDomain",
                columns: table => new
                {
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEvento = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    IdTipoEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdInstituicao = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoDomain", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_EventoDomain_InstituicaoDomain_IdInstituicao",
                        column: x => x.IdInstituicao,
                        principalTable: "InstituicaoDomain",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoDomain_TiposEventoDomain_IdTipoEvento",
                        column: x => x.IdTipoEvento,
                        principalTable: "TiposEventoDomain",
                        principalColumn: "IdTipoEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDomain",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "CHAR(60)", maxLength: 60, nullable: false),
                    IdTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDomain", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_UsuarioDomain_TiposUsuarioDomain_IdTipoUsuario",
                        column: x => x.IdTipoUsuario,
                        principalTable: "TiposUsuarioDomain",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosEventoDomain",
                columns: table => new
                {
                    IdComentarioEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Exibe = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosEventoDomain", x => x.IdComentarioEvento);
                    table.ForeignKey(
                        name: "FK_ComentariosEventoDomain_EventoDomain_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "EventoDomain",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentariosEventoDomain_UsuarioDomain_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "UsuarioDomain",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresencasEventoDomain",
                columns: table => new
                {
                    IdPresencasEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Situacao = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEvento = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresencasEventoDomain", x => x.IdPresencasEvento);
                    table.ForeignKey(
                        name: "FK_PresencasEventoDomain_EventoDomain_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "EventoDomain",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresencasEventoDomain_UsuarioDomain_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "UsuarioDomain",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosEventoDomain_IdEvento",
                table: "ComentariosEventoDomain",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosEventoDomain_IdUsuario",
                table: "ComentariosEventoDomain",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EventoDomain_IdInstituicao",
                table: "EventoDomain",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_EventoDomain_IdTipoEvento",
                table: "EventoDomain",
                column: "IdTipoEvento");

            migrationBuilder.CreateIndex(
                name: "IX_InstituicaoDomain_CNPJ",
                table: "InstituicaoDomain",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresencasEventoDomain_IdEvento",
                table: "PresencasEventoDomain",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_PresencasEventoDomain_IdUsuario",
                table: "PresencasEventoDomain",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDomain_Email",
                table: "UsuarioDomain",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDomain_IdTipoUsuario",
                table: "UsuarioDomain",
                column: "IdTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentariosEventoDomain");

            migrationBuilder.DropTable(
                name: "PresencasEventoDomain");

            migrationBuilder.DropTable(
                name: "EventoDomain");

            migrationBuilder.DropTable(
                name: "UsuarioDomain");

            migrationBuilder.DropTable(
                name: "InstituicaoDomain");

            migrationBuilder.DropTable(
                name: "TiposEventoDomain");

            migrationBuilder.DropTable(
                name: "TiposUsuarioDomain");
        }
    }
}
