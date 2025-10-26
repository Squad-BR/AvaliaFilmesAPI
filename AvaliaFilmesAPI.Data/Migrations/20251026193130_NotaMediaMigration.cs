using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaliaFilmesAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class NotaMediaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NotaMedia",
                table: "Filmes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaMedia",
                table: "Filmes");
        }
    }
}
