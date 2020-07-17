using Microsoft.EntityFrameworkCore.Migrations;

namespace SystemCC.Migrations
{
    public partial class atualizandoOS02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idServico",
                table: "os",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idcliente",
                table: "os",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idServico",
                table: "os");

            migrationBuilder.DropColumn(
                name: "idcliente",
                table: "os");
        }
    }
}
