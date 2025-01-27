using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class CreateDocumento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    DocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioEventoId = table.Column<long>(type: "bigint", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false),
                    DataHoraEvento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoEventoId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjCpfEmitente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CnpjCpfDestinatario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoVerificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHoraEmissao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.DocumentoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");
        }
    }
}
