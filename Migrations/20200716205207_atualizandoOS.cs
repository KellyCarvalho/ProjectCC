using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemCC.Migrations
{
    public partial class atualizandoOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "os",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    clienteID = table.Column<int>(nullable: true),
                    servicoID = table.Column<int>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_os", x => x.ID);
                    table.ForeignKey(
                        name: "FK_os_clientes_clienteID",
                        column: x => x.clienteID,
                        principalTable: "clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_os_servicos_servicoID",
                        column: x => x.servicoID,
                        principalTable: "servicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_os_clienteID",
                table: "os",
                column: "clienteID");

            migrationBuilder.CreateIndex(
                name: "IX_os_servicoID",
                table: "os",
                column: "servicoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "os");
        }
    }
}
